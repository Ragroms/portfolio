using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач
{
    public partial class Вход_администратора : Form
    {
        public Вход_администратора()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            if (username == "admin")
            {
                if (password == "5672")
                {
                    Администратор newMDIChild = new Администратор();
                    newMDIChild.MdiParent = Form1.ActiveForm;
                    newMDIChild.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Такого пароля не существует или он введен не верно", "Извините");
                }
            }
            else
            {
                MessageBox.Show("Такого логина не существует или он введен не верно", "Извините");
            }
        }

        private void Вход_администратора_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "Показать пароль")
            {
                textBox2.UseSystemPasswordChar = false;
                label1.Text = "Скрыть пароль";
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                label1.Text = "Показать пароль";
            }
        }
    }
}
