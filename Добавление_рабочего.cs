using System;
using System.CodeDom.Compiler;
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
    public partial class Добавление_рабочего : Form
    {
        string temp_job = "pharmacist";
        // состоит ли строка только из букв(проверка)
        static bool CheckString(string str)
        {
            bool ans = true;
            for (int i = 0; i < str.Length; i++)
            {
                if (!Char.IsLetter(str[i]))
                {
                    ans = false;
                }
            }
            return ans;
        }

        public Добавление_рабочего()
        {
            InitializeComponent();
        }
        public Добавление_рабочего(string job)
        {
            InitializeComponent();
            temp_job = job;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        static bool IsDigitString(string str) // проверка состоит сторока только из цифры
        {
            bool result = true;
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsDigit(str[i]))
                {
                    result = false;
                }
            }
            return result;
        }

        private void button2_Click(object sender, EventArgs e) // подтверждение
        {
            Pharmacists pharmacists = new Pharmacists();
            WarehouseWorker worker = new WarehouseWorker();
            Администратор admin = new Администратор();

            string id = textBox1.Text;
            string password = textBox2.Text;
            string surname = textBox3.Text;
            string name = textBox4.Text;
            string otchestvo = textBox5.Text;

            if (!pharmacists.ExaminationId(id) && !worker.ExaminationId(id))
            {
                if (temp_job == "pharmacist")
                {
                    if (IsDigitString(id) && id.Length == 6)
                    {
                        if (IsDigitString(password) && password.Length == 4)
                        {
                            if (CheckString(surname) && CheckString(name) && CheckString(otchestvo))
                            {
                                pharmacists.CreateNewPharmacists(id, password, surname, name, otchestvo);
                                this.Close();
                            }

                            else
                            {
                                MessageBox.Show("Не коректный ФИО", "Внимание");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не коректный пароль", "Внимание");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не коректный ID", "Внимание");
                    }
                }
                else if (temp_job == "warehouseWorker")
                {
                    if (IsDigitString(id) && id.Length == 6)
                    {
                        if (IsDigitString(password) && password.Length == 4)
                        {
                            if (CheckString(surname) && CheckString(name) && CheckString(otchestvo))
                            {
                                worker.CreateNewWarehouseWorker(id, password, surname, name, otchestvo);
                                this.Close();
                            }

                            else
                            {
                                MessageBox.Show("Не коректный ФИО", "Внимание");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не коректный пароль", "Внимание");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Не коректный ID", "Внимание");
                    }
                }
            }
            else
            {
                MessageBox.Show("Такой ID уже существует", "Внимание");
            }
        }

        private void Добавление_рабочего_Load(object sender, EventArgs e)
        {

        }
    }
}
