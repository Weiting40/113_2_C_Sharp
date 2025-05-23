namespace ArrayEquality
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] array1= {1,2,3,4,5};
            int[] array2= {1,2,3,4,5};

            //Check if the arrays are equal
            bool arraysEqual= isArrayEqual(array1, array2);
            if (arraysEqual)
            {
                MessageBox.Show("兩個陣列相等");
            }
            else
            {
                MessageBox.Show("兩個陣列不相等");
            }
        }
        private bool isArrayEqual(int[] array1, int[] array2)
        {
            //檢查陣列長度是否相等
            if (array1.Length != array2.Length)
            {
                return false;
            }
            //檢查陣列元素是否相等
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;

        }
    }
}
