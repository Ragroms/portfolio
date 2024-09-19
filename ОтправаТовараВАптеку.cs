using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Курсач
{
    public partial class ОтправаТовараВАптеку : Form
    {
        Logs log = new Logs();
        Medicine medicine = new Medicine();
        Supplies supplies = new Supplies();
        IntermediateProduct product = new IntermediateProduct();
        WarehouseWorker worker = new WarehouseWorker();
        string job_id;

        public ОтправаТовараВАптеку()
        {
            InitializeComponent();
        }
        public ОтправаТовараВАптеку(string id)
        {
            InitializeComponent();
            job_id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            List<string> job_info = worker.GetWarehouseWorkerID(job_id);

            if (supplies.ExaminationId(id))
            {
                string sup_name = supplies.GetSuppliceID(id)[1];
                if (!(medicine.CheckMedicineName(sup_name)))
                {
                    List<string> temp = supplies.GetSuppliceID(id);
                    product.CreateNewIntermediateProduct(temp[0], temp[1], temp[2], temp[3]);

                    log.CreateLogProduct(
                        "Отправка в аптеку",
                        job_info[0],
                        job_info[2],
                        temp[0],
                        temp[1],
                        temp[2],
                        temp[3]
                        );
                    this.Close();
                }

                else
                {
                    List<string> temp_sup = supplies.GetSuppliceID(id);
                    List<string> temp_med = medicine.GetMedicinetID(medicine.GetIDMedicineName(sup_name));
                    DialogResult result = MessageBox.Show(
                        "Такой товар уже есть в аптеке! Хотитие добавить ещё?",
                        "Внимание",
                        MessageBoxButtons.YesNo
                         );
                    if (result == DialogResult.Yes)
                    {
                        product.CreateNewIntermediateProduct(
                            temp_sup[0],
                            temp_sup[1],
                            temp_sup[2],
                            temp_sup[3]
                            );
                        log.CreateLogProduct(
                        "Отправка в аптеку",
                        job_info[0],
                        job_info[2],
                        temp_sup[0],
                        temp_sup[1],
                        temp_sup[2],
                        temp_sup[3]
                        );

                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Отравляймого вами ID не существует!", "Внимание");
            }
        }
        private void ОтправаТовараВАптеку_Load(object sender, EventArgs e)
        {

        }
    }
}
