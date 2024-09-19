using Microsoft.VisualBasic.Logging;
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
    public partial class УдаленияТовараСоСклада : Form
    {
        Logs log = new Logs();
        Supplies supplies = new Supplies();
        WarehouseWorker warehouseWorker = new WarehouseWorker();
        string job_id;

        public УдаленияТовараСоСклада()
        {
            InitializeComponent();
        }
        public УдаленияТовараСоСклада(string id)
        {
            InitializeComponent();
            job_id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;          

            if (supplies.ExaminationId(id))
            {
                List<string> sup = supplies.GetSuppliceID(id);
                List<string> job_info = warehouseWorker.GetWarehouseWorkerID(job_id);

                DialogResult result = MessageBox.Show(
                "Будет удалён: ID: " + sup[0] + " - " + sup[1],
                "Внимание",
                MessageBoxButtons.YesNo
                );

                if (result == DialogResult.Yes)
                {
                    supplies.DeleteSupplice(id);


                    log.CreateLogProduct(
                            "Товар списан со склада",
                            job_info[0],
                            job_info[2],
                            sup[0],
                            sup[1],
                            sup[2],
                            sup[3]
                            );

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Такого ID не существует!");
            }

        }

        private void УдаленияТовараСоСклада_Load(object sender, EventArgs e)
        {

        }
    }
}
