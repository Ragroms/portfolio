using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач
{
    public partial class Удаление_рабочего : Form
    {

        WarehouseWorker warehouseWorker = new WarehouseWorker();
        Pharmacists pharmacists = new Pharmacists();

        string temp_job = "pharmacist";

        public Удаление_рабочего()
        {
            InitializeComponent();
        }
        public Удаление_рабочего(string job)
        {
            InitializeComponent();
            temp_job = job;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;

            if (temp_job == "pharmacist")
            {
                if (pharmacists.ExaminationId(id))
                {
                    List<string> temp = pharmacists.GetPharmacistID(id);

                    string rabotnic = "ID: " + temp[0] + " - (" + temp[2] + " " + temp[3] + " " + temp[4] + ")";

                    DialogResult result = MessageBox.Show(
                        "Будет удалён: " + rabotnic,
                        "Внимание",
                        MessageBoxButtons.YesNo
                        );

                    if (result == DialogResult.Yes)
                    {
                        pharmacists.DeletePharmacists(id);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Такого ID не существует", "Ошибка");
                }
            }

            else if (temp_job == "warehouseWorker")
            {
                if (warehouseWorker.ExaminationId(id))
                {
                    List<string> temp = warehouseWorker.GetWarehouseWorkerID(id);

                    string rabotnic = "ID: " + temp[0] + " - (" + temp[2] + " " + temp[3] + " " + temp[4] + ")";

                    DialogResult result = MessageBox.Show(
                        "Будет удалён: " + rabotnic,
                        "Внимание",
                        MessageBoxButtons.YesNo
                        );

                    if (result == DialogResult.Yes)
                    {
                        warehouseWorker.DeleteWarehouseWorker(id);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Такого ID не существует", "Ошибка");
                }
            }
        }

        private void Удаление_рабочего_Load(object sender, EventArgs e)
        {

        }
    }
}
