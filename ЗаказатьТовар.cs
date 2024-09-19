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
    public partial class ЗаказатьТовар : Form
    {
        string job_id;

        static bool IsDigitString(string str)
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

        Logs log = new Logs();
        Supplies supplies = new Supplies();
        Medicine medicine = new Medicine();
        WarehouseWorker warehouse = new WarehouseWorker();

        public ЗаказатьТовар()
        {
            InitializeComponent();
        }
        public ЗаказатьТовар(string id)
        {
            InitializeComponent();
            job_id = id;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> job_info = warehouse.GetWarehouseWorkerID(job_id);

            string id = textBox1.Text;
            string name = textBox2.Text;
            string quantity = textBox3.Text;
            string price = textBox4.Text;
            double total_price;

            if (IsDigitString(id) && (id.Length == 6))
            {
                if ((!supplies.ExaminationId(id)) && (!supplies.CheckSuppliceName(name)) && !(medicine.ExaminationId(id)))
                {
                    if (IsDigitString(quantity))
                    {
                        if (IsDigitString(price))
                        {
                            total_price = Convert.ToDouble(quantity) * Convert.ToDouble(price);
                            supplies.CreateNewSupplice(id, name, quantity, Convert.ToString(total_price));

                            log.CreateLogProduct(
                                "Заказ товара",
                                job_info[0],
                                job_info[2],
                                id,
                                name,
                                quantity,
                                price
                                );

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Не коректная цена", "Внимание");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не коректное количество товара", "Внимание");
                    }
                }
                else if (supplies.CheckSuppliceName(name) && !(medicine.ExaminationId(id)))
                {

                    if (IsDigitString(quantity))
                    {
                        if (IsDigitString(price))
                        {
                            // добовляем товар на складе
                            string old_id = supplies.GetIDSuppliceName(name);
                            List<string> temp = supplies.GetSuppliceID(old_id);
                            supplies.DeleteSupplice(old_id);

                            total_price = Convert.ToDouble(quantity) * Convert.ToDouble(price);

                            string t_id = temp[0];
                            string t_name = temp[1];
                            string t_quantity = Convert.ToString(
                                Convert.ToDouble(temp[2]) + Convert.ToDouble(quantity)
                                );
                            string t_total_price = Convert.ToString(
                                Convert.ToDouble(temp[3]) + total_price
                                );

                            DialogResult result = MessageBox.Show(
                                "Такой товар уже на складе! Хотите добавить ещё? - (" + temp[0] + " " + temp[1] + " " + temp[2] + " " + temp[3],
                                "Внимание",
                                MessageBoxButtons.YesNo
                                );

                            if (result == DialogResult.Yes)
                            {
                                supplies.CreateNewSupplice(t_id, t_name, t_quantity, t_total_price);
                                log.CreateLogProduct(
                                "Заказ товара",
                                job_info[0],
                                job_info[2],
                                t_id,
                                t_name,
                                t_quantity,
                                price
                                );
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не коректная цена", "Внимание");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не коректное количество товара", "Внимание");
                    }
                }
                else
                {
                    MessageBox.Show("Такой ID уже существует", "Внимание");
                }
            }
            else
            {
                MessageBox.Show("Не коректный ID", "Внимание");
            }
        }
        private void ЗаказатьТовар_Load(object sender, EventArgs e)
        {

        }
    }
}
