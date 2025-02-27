using System.Diagnostics.Eventing.Reader;

namespace Tutorial_4_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculatebutton_Click(object sender, EventArgs e)
        {
            double distance, gas, average;
            if (double.TryParse(distancetextbox.Text, out distance))
            {
                if (double.TryParse(gastextbox.Text, out gas))
                {
                    average = distance / gas; // 計算平均油耗
                    averagelabel.Text = "平均油耗:" + average.ToString("f2") + "公里/公升"; //f2表示小數點後兩位
                    loglistbox.Items.Add(average.ToString("f2") + "公里/公升"); // 將平均油耗加入loglistbox
                }
                else
                {
                    MessageBox.Show("油耗請輸入數字");
                    gastextbox.Focus(); // 游標移到gastextbox
                    gastextbox.Text = ""; // 清空
                }
            }
            else
            {
                MessageBox.Show("請輸入有效數字");
                distancetextbox.Focus(); // 游標移到distancetextbox
                distancetextbox.Text = ""; // 清空
            }
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            this.Close(); // 關閉視窗
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loglistbox.Items.Clear(); // 清空loglistbox
            loglistbox.Items.Add("平均油耗紀錄:");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double sum = 0;
            if (loglistbox.Items.Count > 1)
            {
                for (int i = 1; i < loglistbox.Items.Count; i++)
                {
                    sum += double.Parse(loglistbox.Items[i].ToString().Replace("公里/公升", "")); // 將公里/公升去掉再加總
                }
                loglistbox.Items.Add("平均油耗:\n" + (sum/(loglistbox.Items.Count-1)).ToString("f2") + "公里/公升");
            }
            else
            {
                MessageBox.Show("沒有紀錄");
            }
        }
    }
}
