using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Calc cl;
        bool is_dark = false;
        public Form1()
        {
            InitializeComponent();
            cl = new Calc();
            label1.Text = "";
            label2.Text = "";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            cl.Action("/");
            label1.Text = cl.Print();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cl.Action("7");
            label1.Text = cl.Print();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            cl.Action("1");
            label1.Text = cl.Print();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            cl.Action("0");
            label1.Text = cl.Print();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            cl.Action("2");
            label1.Text = cl.Print();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            cl.Action("3");
            label1.Text = cl.Print();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cl.Action("4");
            label1.Text = cl.Print();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cl.Action("5");
            label1.Text = cl.Print();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cl.Action("6");
            label1.Text = cl.Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cl.Action("8");
            label1.Text = cl.Print();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cl.Action("9");
            label1.Text = cl.Print();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cl.Action("*");
            label1.Text = cl.Print();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            cl.Action("+");
            label1.Text = cl.Print();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cl.Action("-");
            label1.Text = cl.Print();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            cl.Action("=");
            label1.Text = cl.Print();
            label2.Text = cl.PrintRes();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            cl.Action("C");
            label1.Text = cl.Print();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl.Action("9");
            label1.Text = cl.Print();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (is_dark)
            {
                // Тут включаем темную тему
                button17.Text = "Light Theme";
                this.BackColor = Color.Black;
                this.ForeColor = Color.White;
                button1.BackColor = Color.Black;
                button2.BackColor = Color.Black;
                button3.BackColor = Color.Black;
                button4.BackColor = Color.Black;
                button5.BackColor = Color.Black;
                button6.BackColor = Color.Black;
                button7.BackColor = Color.Black;
                button8.BackColor = Color.Black;
                button9.BackColor = Color.Black;
            }
            else
            {
                // Тут включаем светлую тему
                button17.Text = "Dark Theme";
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
                button3.BackColor = Color.White;
                button4.BackColor = Color.White;
                button5.BackColor = Color.White;
                button6.BackColor = Color.White;
                button7.BackColor = Color.White;
                button8.BackColor = Color.White;
                button9.BackColor = Color.White;
            }

            is_dark = !is_dark;
        }

        private void button17_MouseEnter(object sender, EventArgs e)
        {
            button17.BackColor = Color.Violet;
        }

        private void button17_MouseLeave(object sender, EventArgs e)
        {
            if (!is_dark)
            {
                button17.BackColor = Color.Black;
            }
            else
            {
                button17.BackColor = Color.White;
            }
        }
    }

    class Calc
    {
        public float num1 = 0, num2 = 0, res = 0;
        bool r = false;
        string action = "";


        public string Print()
        {
            if (r)
            {
                return Convert.ToString(num1) + action + Convert.ToString(num2);
            }

            else
            {
                return Convert.ToString(num1);
            }
            
        }

        public string PrintRes()
        {
            num1 = res;
            num2 = 0;
            return Convert.ToString(res);
        }

        public void Clear()
        {
            num1 = 0;
            num2 = 0;
            res = 0;
            r = false;
            
        }
        public void Action(string a)
        {
            if (a == "+" || a == "-" || a == "*" || a == "/" || a == "=" || a == "C")
            {
                if (a == "+" || a == "-" || a == "*" || a == "/")
                {
                    action = a;
                    //Print();
                }
                else if (a == "=")
                {
                    if (action == "+")
                    {
                        res = num1 + num2;
                    }
                    else if (action == "-")
                    {
                        res = num1 - num2;
                    }
                    else if(action == "*")
                    {
                        res = num1 * num2;
                    }
                    else if(action == "/")
                    {
                        res = num1 / num2;
                    }
                }

                r = true;

                if (a == "C")
                {
                    Clear();
                }
            }
            else
            {
                try
                {
                    if (r == false)
                    {
                        num1 = Int32.Parse(Convert.ToString(num1) + a);
                    }
                    else
                    {
                        num2 = Int32.Parse(Convert.ToString(num2) + a);
                    }

                    Print();
                }
                catch (Exception)
                {

                }
                
            }
        }
     }
}
