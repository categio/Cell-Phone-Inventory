using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cell_Phone_Inventory
{
    public partial class Form1 : Form
    {
        //using List to hold CellPhone objects.
        //This will be available to all methods in the class
        List<CellPhone> phoneList = new List<CellPhone>();

        public Form1()
        {
            InitializeComponent();
        }
        //the GetPhoneData method accepts a CellPhone obj
        //as an argument and assignes user entered data to
        //the obj's props
        private void GetPhoneData(CellPhone phone)
        {
            //temp var to hold price data
            decimal price;

            //getters and setters for CellPhone attributes
            phone.Brand = brandTextBox.Text;

            phone.Model = modelTextBox.Text;

            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                phone.Price = price;
            }
            else
            {
                //error message box displays error message
                MessageBox.Show("Invalid price entered.");
            }


        }

        private void addPhoneButton_Click(object sender, EventArgs e)
        {
            //Create CellPhone obj from user entered data
            CellPhone myPhone = new CellPhone();
            //Collect phone data to create CellPhone obj
            GetPhoneData(myPhone);
            //add new CellPhone obj to the List
            phoneList.Add(myPhone);

            //Add new cellphone obj to the listbox
            phoneListBox.Items.Add(myPhone.Brand + " " + myPhone.Model);
            //Clear TextBox controls
            brandTextBox.Clear();
            modelTextBox.Clear();
            priceTextBox.Clear();
            //reset Focus
            brandTextBox.Focus();
        }

        private void phoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get index of selected item in listbox
            int index = phoneListBox.SelectedIndex;
            //Display price of selected item
            MessageBox.Show(phoneList[index].Price.ToString("c"));
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //Close Form/Program
            this.Close();
        }
    }
}
