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
                    average = distance / gas; // �p�⥭���o��
                    averagelabel.Text = "�����o��:" + average.ToString("f2") + "����/����"; //f2��ܤp���I����
                    loglistbox.Items.Add(average.ToString("f2") + "����/����"); // �N�����o�ӥ[�Jloglistbox
                }
                else
                {
                    MessageBox.Show("�o�ӽп�J�Ʀr");
                    gastextbox.Focus(); // ��в���gastextbox
                    gastextbox.Text = ""; // �M��
                }
            }
            else
            {
                MessageBox.Show("�п�J���ļƦr");
                distancetextbox.Focus(); // ��в���distancetextbox
                distancetextbox.Text = ""; // �M��
            }
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            this.Close(); // ��������
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loglistbox.Items.Clear(); // �M��loglistbox
            loglistbox.Items.Add("�����o�Ӭ���:");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double sum = 0;
            if (loglistbox.Items.Count > 1)
            {
                for (int i = 1; i < loglistbox.Items.Count; i++)
                {
                    sum += double.Parse(loglistbox.Items[i].ToString().Replace("����/����", "")); // �N����/���ɥh���A�[�`
                }
                loglistbox.Items.Add("�����o��:\n" + (sum/(loglistbox.Items.Count-1)).ToString("f2") + "����/����");
            }
            else
            {
                MessageBox.Show("�S������");
            }
        }
    }
}
