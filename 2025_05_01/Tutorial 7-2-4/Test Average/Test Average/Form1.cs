using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Test_Average
{
    public partial class Form1 : Form
    {
        private List<int> testScores = new List<int>(); // 儲存測試分數的清單

        public Form1()
        {
            InitializeComponent();
        }

        // 計算平均分數
        private double Average(List<int> scores)
        {
            int total = 0;
            foreach (int score in scores)
            {
                total += score;
            }
            return (double)total / scores.Count;
        }

        // 找出最高分數
        private int Highest(List<int> scores)
        {
            int highest = scores[0];
            for (int i = 1; i < scores.Count; i++)
            {
                if (scores[i] > highest)
                {
                    highest = scores[i];
                }
            }
            return highest;
        }

        // 找出最低分數
        private int Lowest(List<int> scores)
        {
            int lowest = scores[0];
            foreach (int score in scores)
            {
                if (score < lowest)
                {
                    lowest = score;
                }
            }
            return lowest;
        }

        // 取得分數按鈕事件
        private void getScoresButton_Click(object sender, EventArgs e)
        {
            int highestScore = 0;
            int lowestScore = 0;
            double averageScore = 0.0;
            StreamReader inputFile;

            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFile.FileName);
                    testScoresListBox.Items.Clear();
                    testScores.Clear();

                    while (!inputFile.EndOfStream)
                    {
                        int score = int.Parse(inputFile.ReadLine());
                        testScores.Add(score);
                        testScoresListBox.Items.Add(score);
                    }
                    inputFile.Close();

                    averageScore = Average(testScores);
                    highestScore = Highest(testScores);
                    lowestScore = Lowest(testScores);

                    averageScoreLabel.Text = averageScore.ToString("n1");
                    highScoreLabel.Text = highestScore.ToString();
                    lowScoreLabel.Text = lowestScore.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤");
            }
        }

        // 排序按鈕事件
        private void sortButton_Click(object sender, EventArgs e)
        {
            sortedScoresListBox.Items.Clear(); // 清空排序後的 ListBox

            // 將分數排序
            List<int> sortedScores = new List<int>(testScores);
            sortedScores.Sort();

            // 將排序後的分數顯示在 ListBox 中
            foreach (int score in sortedScores)
            {
                sortedScoresListBox.Items.Add(score);
            }
        }

        // 刪除按鈕事件
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (testScoresListBox.SelectedIndex != -1)
            {
                int selectedIndex = testScoresListBox.SelectedIndex;
                testScores.RemoveAt(selectedIndex);

                testScoresListBox.Items.Clear();
                foreach (int score in testScores)
                {
                    testScoresListBox.Items.Add(score);
                }

                sortedScoresListBox.Items.Clear();
                List<int> sortedScores = new List<int>(testScores);
                sortedScores.Sort();
                foreach (int score in sortedScores)
                {
                    sortedScoresListBox.Items.Add(score);
                }

                if (testScores.Count > 0)
                {
                    averageScoreLabel.Text = Average(testScores).ToString("n1");
                    highScoreLabel.Text = Highest(testScores).ToString();
                    lowScoreLabel.Text = Lowest(testScores).ToString();
                }
                else
                {
                    averageScoreLabel.Text = string.Empty;
                    highScoreLabel.Text = string.Empty;
                    lowScoreLabel.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("請選擇要刪除的分數。", "提示");
            }
        }

        // 退出按鈕事件
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
