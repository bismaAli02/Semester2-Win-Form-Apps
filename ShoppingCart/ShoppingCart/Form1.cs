using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingCart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void label15_Click(object sender, EventArgs e)
        {

        }
        private void label16_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            double price;
            if (textBox3.Text == "")
            {
                price = 0;
                label14.Text = price.ToString();
            }
            else
            {
                price = int.Parse(textBox3.Text) * 14.95;
                label14.Text = price.ToString();
            }
            printTotal();

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double price;
            if (textBox1.Text == "")
            {
                price = 0;
                label9.Text = price.ToString();

            }
            else
            {
                price = int.Parse(textBox1.Text) * 9.95;
                label9.Text = price.ToString();

            }
            printTotal();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double price;
            if (textBox2.Text == "")
            {
                price = 0;
                label11.Text = price.ToString();
            }
            else
            {
                price = int.Parse(textBox2.Text) * 19.95;
                label11.Text = price.ToString();
            }
            printTotal();
        }

        private double totalPrice()
        {
            double price = 0;
            if (label11.Text != "")
            {
                price += double.Parse(label11.Text);
            }
            if (label9.Text != "")
            {
                price += double.Parse(label9.Text);
            }
            if (label14.Text != "")
            {
                price += double.Parse(label14.Text);
            }
            return price;
        }
        private void printTotal()
        {
            label15.Text = "$" + totalPrice();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }
    }
}