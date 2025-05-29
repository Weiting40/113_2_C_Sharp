using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The GetPhoneData method accepts a CellPhone object
        // as an argument. It assigns the data entered by the
        // user to the object's properties.
        private void GetPhoneData(CellPhone phone)
        {
            decimal price;
            phone.Brand = brandTextBox.Text;
            phone.Model = modelTextBox.Text;

            if(decimal.TryParse(priceTextBox.Text, out price))
            {
                // If the price is valid, assign it to the phone's Price property.
                phone.Price = price;
            }
            else
            {
                // If the price is not valid, display an error message.
                MessageBox.Show("請輸入有效的價格。","錯誤");
                return;
            }
        }

        private void createObjectButton_Click(object sender, EventArgs e)
        {
            CellPhone myphone = new CellPhone();
            GetPhoneData(myphone);
            brandLabel.Text = myphone.Brand;
            modelLabel.Text = myphone.Model;
            priceLabel.Text = myphone.Price.ToString("C2");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
