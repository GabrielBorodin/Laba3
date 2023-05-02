using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
            AirportClass station = new AirportClass();

            station.Name = textBox1.Text;

            if (Convert.ToString(textBox1.Text) == "" || Convert.ToString(textBox2.Text) == "" || Convert.ToString(textBox3.Text) == "" || Convert.ToString(textBox4.Text) == "")
            {
                textBox6.Text += "Необходимо заполнить все поля" + Environment.NewLine;
            }

            try
            {
                station.Seat = double.Parse(textBox2.Text);
            }
            catch
            {
                textBox6.Text += "Общее количество мест - число" + Environment.NewLine;
            }

            try
            {
                station.Ticket = double.Parse(textBox3.Text);
            }
            catch
            {
                textBox6.Text += "Количество проданных билетов - число" + Environment.NewLine;
            }

            try
            {
                station.Cost = double.Parse(textBox4.Text);

            }
            catch
            {
                textBox6.Text += "Стоимость билета - число" + Environment.NewLine;
            }



            //station.Seat = double.Parse(textBox2.Text);
            //station.Ticket = double.Parse(textBox3.Text);   
            //station.Cost = double.Parse(textBox4.Text);
            double res = station.Info();


            if (res == -3)
            {
     //    textBox6.Items.Clear();
                if (station.Seat < 0)
                {
                    textBox6.Text += "Количество мест - положительное число" + Environment.NewLine;
                }

                if (station.Seat - Math.Floor(station.Seat) != 0)
                {
                    textBox6.Text += "Количество мест - целое число" + Environment.NewLine;
                }

                if (station.Ticket < 0)
                {
                    textBox6.Text += "Количество билетов - положительное число" + Environment.NewLine;
                }

                if (station.Ticket - Math.Floor(station.Ticket) != 0)
                {
                    textBox6.Text += "Количество билетов - целое число" + Environment.NewLine;
                }
                if (station.Seat < station.Ticket)
                {
                 
                    textBox6.Text +="Количество проданных билетов должно быть" + Environment.NewLine;
                    textBox6.Text += "не больше общего количества мест" + Environment.NewLine;
                }
                if (station.Cost < 0)
                {
                    textBox6.Text += "Стоимость билета должна быть больше нуля" + Environment.NewLine;
                }
            }
            else
            {
               // textBox6.Text = "";
                textBox6.Clear();
                if (Convert.ToString(textBox2.Text) != "" && Convert.ToString(textBox3.Text) != "" && Convert.ToString(textBox4.Text) != "" && Convert.ToString(textBox1.Text) != "" && Convert.ToString(textBox6.Text) == "")
                {
                    
                    textBox5.Text = "Название аэропорта: " + station.Name + ", Общее количество мест: " + station.Seat + Environment.NewLine + "Количество проданных билетов: " + station.Ticket + ", Стоимость билета: " + station.Cost + Environment.NewLine + "Общая стоимость проданных билетов: " + Convert.ToString(res);
                   // textBox5.Text = typeof(station.Cost)
                }
                else { textBox5.Text = ""; }

            }








        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch))
            {
                if ((e.KeyChar != (char)Keys.Back) && e.KeyChar != ',')
                {
                    e.Handled = true;
                }
            }
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
