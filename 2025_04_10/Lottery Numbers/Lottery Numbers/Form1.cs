using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery_Numbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 5;//產生5個隨機數字
            int[]lotteryNumbers= new int[SIZE];//宣告一個陣列儲存樂透號碼
            Random random = new Random();//創建一個Random物件，用於生成隨機數

            for (int i = 0; i < lotteryNumbers.Length; i++)
            {
                int number;
                do
                {
                    number = random.Next(1, 43);//產生1~42的隨機數字
                } while (lotteryNumbers.Contains(number));//檢查是否已經存在於陣列中
                lotteryNumbers[i] = number;//將隨機數字存入陣列
            }
            //將lotteryNumbers陣列中的數字由小到大排序
            Array.Sort(lotteryNumbers);//使用Array.Sort方法將lotteryNumbers陣列中的數字進行排序
            //註解掉的原始程式碼，逐一將樂透號碼顯示在對應的標籤上
            //firstLabel.Text = lotteryNumbers[0].ToString();
            //secondLabel.Text = lotteryNumbers[1].ToString();
            //thirdLabel.Text = lotteryNumbers[2].ToString();
            //fourthLabel.Text = lotteryNumbers[3].ToString();
            //fifthLabel.Text = lotteryNumbers[4].ToString();

            Label[]showLabels = { firstLabel, secondLabel, thirdLabel, fourthLabel, fifthLabel };
            for (int i = 0; i < lotteryNumbers.Length; i++)
            {
                showLabels[i].Text = lotteryNumbers[i].ToString();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
