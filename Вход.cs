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
    public partial class Вход : Form
    {
        string job_id;

        public Вход()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string password = textBox2.Text;
            Pharmacists pharmacists = new Pharmacists();
            pharmacists.ExaminationId(id);
            if (pharmacists.ExaminationId(id))
            {
                if (password == pharmacists.GetPassword(id))
                {
                    job_id = id;
                    Формацефт newMDIChild = new Формацефт(job_id);
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
                MessageBox.Show("Такого ID не существует или он введен не верно", "Извините");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Вход_Load(object sender, EventArgs e)
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
