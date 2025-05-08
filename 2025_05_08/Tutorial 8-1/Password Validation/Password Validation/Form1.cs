using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Validation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The NumberUpperCase method accepts a string argument
        // and returns the number of uppercase letters it contains.
        private int NumberUpperCase(string str)
        {

            int upperCaseCount = 0;
            foreach (char c in str)
            {
                {
                    if (char.IsUpper(c))
                    {
                        upperCaseCount++;
                    }
                }
              
            }
            return upperCaseCount;
        }
   

        // The NumberLowerCase method accepts a string argument
        // and returns the number of lowercase letters it contains.
        private int NumberLowerCase(string str)
        {
            int lowerCaseCount = 0;
           for (int i = 0;
                i < str.Length; i++)
            {
                if (char.IsLower(str[i]))
                {
                    lowerCaseCount++;
                }
            }
            return lowerCaseCount;
        }

        // The NumberDigits method accepts a string argument
        // and returns the number of numeric digits it contains.
        private int NumberDigits(string str)
        {
            int digitCount = 0;
            foreach (char c in str)
            {
                if (char.IsDigit(c))
                {
                    digitCount++;
                }
            }
            return digitCount;
        }

        private void checkPasswordButton_Click(object sender, EventArgs e)
        {
            const int MIN_LENGTH = 8;
            string password = passwordTextBox.Text;
            if (password.Length < MIN_LENGTH &&
                    NumberUpperCase(password) > 0 &&
                    NumberLowerCase(password) > 0 &&
                    NumberDigits(password) > 0)
            {
                MessageBox.Show("密碼有效!", "密碼檢查結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("密碼無效!", "密碼檢查結果", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
