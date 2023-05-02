using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3     
{
    public partial class Form1 : System.Windows.Forms.Form
    {

        Storage initHRD = new Storage();
       



        public Form1()
        {


            InitializeComponent();
            label3.Text = Factory.GetInstance().ToString();
            Factory.GetInstance().factoryParametersChanged += OnFactoryParametersChanged;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Factory.GetInstance().ourFactoryName = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int value) && value >= 0)
            {

            

                    MessageBox.Show(initHRD.Result().ToString(), "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                


                int x = 2;

                ///          MessageBox.Show(x.ToString(), "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);


                //    MessageBox.Show(value.ToString(), "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error); /////////////      value - текущее число в строке кол-ва деталей

                Factory.GetInstance().NumberPartsUp(value);
            } else
            {
                MessageBox.Show("Изменение количества деталей должно быть целым неотрицательным числом!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int value) && value >= 0)
            {
                Factory.GetInstance().NumberPartsDown(value);
            }
            else
            {
                MessageBox.Show("Изменение количества деталей должно быть целым неотрицательным числом!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.TextLength == 0) {
                MessageBox.Show("Укажите название завода!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else {

                if (Factory.GetInstance().CurrentOpeningStatus)
                {
                    Factory.GetInstance().FactoryClose();
                    button3.Text = "Открыть завод";
                    textBox2.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    label4.Enabled = false;
                }
                else
                {
                    Factory.GetInstance().FactoryOpen();
                    button3.Text = "Закрыть завод";
                    textBox2.Enabled = true;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    label4.Enabled = true;
                }
            }
        }

        private void OnFactoryParametersChanged (object sender, EventArgs e)
        {
            label3.Text = Factory.GetInstance().ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch))
            {
                if ((e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
