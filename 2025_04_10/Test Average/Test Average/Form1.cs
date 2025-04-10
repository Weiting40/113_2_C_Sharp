using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int Highest(int[] scores)
        {
            int highScore = [0];
            foreach (int score in scores)
            {
                if (score > highScore)
                {
                    highScore = score;
                }
            }
        }
        private double Average(int[] scores)
        {
            double total = 0.0;
            foreach (int score in scores)
            {
                total += score;
            }
            return total / scores.Length;
        }
        private int Lowest( int[] scores  )
        {
            int lowScore = [0];
            foreach (int score in scores)
            {
                if (score < lowScore)
                {
                    lowScore = score;
                }
            }
        }
        private void getScoresButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 48;
            int[] testScores = new int[SIZE];
            int index = 0;
            int highScore = 0;
            int lowScore = 100;
            double averageScore = 0.0;
            StreamReader inputFile;
            try
            {
                if(openFile.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFile.FileName);
                    while (!inputFile.EndOfStream)
                    {
                        testScores[index] = Convert.ToInt32(inputFile.ReadLine());
                        index++;
                    }
                    inputFile.Close();
                }
                else
                {
                    MessageBox.Show("No file selected.", "Error");
                }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {

        }
    }
}
