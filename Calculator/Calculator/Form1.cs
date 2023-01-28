using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {

        private string operand1 = "";
        private string operand2 = "";
        private char operation = ' ';


        public float performAction()
        {
            float value1 = float.Parse(operand1);
            float value2 = float.Parse(operand2);

            if(operation == '+')
            {
                return (value1 + value2);
            }
            else if (operation == '-')
            {
                return (value1 - value2);
            }
            else if (operation == '*')
            {
                return (value1 * value2);
            }
            else if (operation == '/')
            {
                return (value1 / value2);
            }

            return 0;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
                if (textBox2.Text != "")
                {
                    operand2 = textBox2.Text;
                    textBox2.Text = performAction().ToString();
                    textBox1.Text = operand1 + operation + operand2 ;
                    operand1 = textBox1.Text;
                    operation = ' ';
                }
        }
           
                   
  
            

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + "0";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + "1";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + "2";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + "3";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + "4";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + "5";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + "6";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + "7";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + "8";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + "9";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(operation == ' ')
            {
                if(textBox2.Text != "")
                {
                    operation = '/';
                    operand1 = textBox2.Text;
                    textBox1.Text = textBox2.Text + "/";
                    textBox2.Text = " ";
                }
            }
            else
            {
                if (textBox2.Text != "")
                {
                    operand2 = textBox2.Text;
                    operand1 = performAction().ToString();
                    operation = '/';
                    textBox1.Text = operand1 + operation;
                    textBox2.Text = " ";
                }
                else
                {
                    operation = '/';
                    textBox1.Text = operand1 + operation;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (operation == ' ')
            {
                if (textBox2.Text != "")
                {
                    operation = '*';
                    operand1 = textBox2.Text;
                    textBox1.Text = textBox2.Text + "*";
                    textBox2.Text = " ";
                }
            }
            else
            {
                if (textBox2.Text != "")
                {
                    operand2 = textBox2.Text;
                    operation = '*';
                    operand1 = performAction().ToString();
                    textBox1.Text = operand1 + operation;
                    textBox2.Text = " ";
                }
                else
                {
                    operation = '*';
                    textBox1.Text = operand1 + operation;
                }
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (operation == ' ')
            {
                if (textBox2.Text != "")
                {
                    operation = '-';
                    operand1 = textBox2.Text;
                    textBox1.Text = textBox2.Text + "-";
                    textBox2.Text = " ";
                }
            }
            else
            {
                if (textBox2.Text != "")
                {
                    operand2 = textBox2.Text;
                    operation = '-';
                    operand1 = performAction().ToString();
                    textBox1.Text = operand1 + operation;
                    textBox2.Text = " ";
                }
                else
                {
                    operation = '-';
                    textBox1.Text = operand1 + operation;
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (operation == ' ')
            {
                if (textBox2.Text != "")
                {
                    operation = '+';
                    operand1 = textBox2.Text;
                    textBox1.Text = textBox2.Text + "+";
                    textBox2.Text = " ";
                }
            }
            else
            {
                if (textBox2.Text != "")
                {
                    operand2 = textBox2.Text;
                    operation = '+';
                    operand1 = performAction().ToString();
                    textBox1.Text = operand1 + operation;
                    textBox2.Text = " ";
                }
                else
                {
                    operation = '+';
                    textBox1.Text = operand1 + operation;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox1.Text = "0";
            operand1 = "";
            operand2 = "";
            operation = ' ';
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != "")
            {
                string res = textBox2.Text;
                textBox2.Text = "";
                for(int x=0; x < res.Length-1; x++)
                {
                    textBox2.Text = textBox2.Text + res[x];
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + ".";
        }
    }
}
