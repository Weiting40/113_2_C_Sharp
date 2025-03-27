namespace NumberFrequency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const int SIZE = 1000;
            int num;
            double frequency;
            Random random = new Random();
            int[] numbers = new int[SIZE];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 101);
            }
            if(int.TryParse(numbertextbox.Text, out num))
            {
               frequency  =(double) frequencyOfNumber(numbers, num)/SIZE;
               MessageBox.Show("�Ʀr" + num + "�X�{�����v��:" + frequency.ToString("P"));
            }
            else
            {
                MessageBox.Show("���A���~;�п�J���!");
            }
        }
        private int frequencyOfNumber(int[] numbers, int num)
        {
            int count = 0;
            foreach (int  number in numbers)
            {
                if (number == num)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
