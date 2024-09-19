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

    public partial class ПринятиеТовара : Form
    {
        Logs log = new Logs();
        IntermediateProduct prod = new IntermediateProduct();
        Medicine medicine = new Medicine();
        Supplies supplies = new Supplies();
        Pharmacists pharmacists = new Pharmacists();

        string job_id;

        public ПринятиеТовара()
        {
            InitializeComponent();
        }
        public ПринятиеТовара(string job)
        {
            InitializeComponent();
            job_id = job;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            // Таблица Фармацевтов

            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Имя", typeof(string));
            dt.Columns.Add("Количество", typeof(string));
            dt.Columns.Add("Цена", typeof(string));


            List<string> product = prod.GetIntermediateProduct();

            for (int i = 0; i < product.Count; i++)
            {
                dt.Rows.Add(
                    product[i].Split(":")[0],
                    product[i].Split(":")[1],
                    product[i].Split(":")[2],
                    product[i].Split(":")[3]
                    );
            }

            dataGridView1.DataSource = dt;
        }



        private void button1_Click(object sender, EventArgs e) // принятине товара
        {

            List<string> job_info = pharmacists.GetPharmacistID(job_id);

            string id = textBox1.Text;

            string product_name; 




            if (prod.ExaminationId(id))
            {
                product_name = prod.GeIntermediateProducttID(id)[1];

                if (!medicine.CheckMedicineName(product_name))
                {
                    List<string> t_prod = prod.GeIntermediateProducttID(id);
                    prod.DeleteIntermediateProduct(id);
                    supplies.DeleteSupplice(id);
                    medicine.CreateNewMedicine(t_prod[0], t_prod[1], t_prod[2], t_prod[3]);
                    MessageBox.Show("Товар успешно принят!", "Внимание");
                    textBox1.Text = "";

                    log.CreateLogProduct(
                        "Товар был принят",
                        job_info[0],
                        job_info[2],
                        t_prod[0],
                        t_prod[1],
                        t_prod[2],
                        t_prod[3]
                        );
                }
                else
                {
                    List<string> t_prod = prod.GeIntermediateProducttID(id);
                    List<string> temp_med = medicine.GetMedicinetID(medicine.GetIDMedicineName(product_name));

                    double price_sup = (Convert.ToDouble(t_prod[3]) / Convert.ToDouble(t_prod[2])) / 2;
                    double price = Convert.ToDouble(temp_med[3]) + price_sup;
                    double quantity = Convert.ToDouble(temp_med[2]) + Convert.ToDouble(t_prod[2]);

                    medicine.DeleteMedicine(medicine.GetIDMedicineName(product_name));
                    supplies.DeleteSupplice(id);
                    prod.DeleteIntermediateProduct(id);

                    medicine.CreateNewMedicine(
                        t_prod[0],
                        t_prod[1],
                        Convert.ToString(quantity),
                        Convert.ToString(price)
                        );
                    MessageBox.Show("Товар успешно принят!", "Внимание");
                    textBox1.Text = "";



                    log.CreateLogProduct(
                        "Товар был принят",
                        job_info[0],
                        job_info[2],
                        t_prod[0],
                        t_prod[1],
                        t_prod[2],
                        t_prod[3]
                        );

                }
            }
            else
            {
                MessageBox.Show("Такого ID несуществует", "Внимание");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> job_info = pharmacists.GetPharmacistID(job_id);
            DialogResult result = MessageBox.Show(
                        "Вы точно хотите очистить весь товар?",
                        "Внимание",
                        MessageBoxButtons.YesNo
                         );
            if (result == DialogResult.Yes)
            {
                prod.IntermediateProductClear();
                log.CreateLogProduct(
                        "Весь товар был отклонён",
                        job_info[0],
                        job_info[2],
                        "-",
                        "-",
                        "-",
                        "-"
                        );
            }
        }

        private void ПринятиеТовара_Load(object sender, EventArgs e)
        {

        }
    }
}
