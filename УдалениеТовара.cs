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
    public partial class УдалениеТовара : Form
    {

        Medicine med = new Medicine();
        Pharmacists pharmacists = new Pharmacists();
        Logs log = new Logs();
        string job_id = "xxxxxx";

        public УдалениеТовара()
        {
            InitializeComponent();
        }
        public УдалениеТовара(string job)
        {
            InitializeComponent();
            job_id = job;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;

            if (med.ExaminationId(id))
            {
                List<string> temp = med.GetMedicinetID(id);



                DialogResult result = MessageBox.Show(
                        "Будет удалена: ID: " + temp[0] + " - " + temp[1],
                        "Внимание",
                        MessageBoxButtons.YesNo
                        );



                if (result == DialogResult.Yes)
                {
                    med.DeleteMedicine(id);
                    List<string> temp2 = pharmacists.GetPharmacistID(job_id);
                    log.CreateLogProduct(
                        "Удалён товар из аптеки",
                        temp2[0],
                        temp2[2],
                        temp[0],
                        temp2[1],
                        temp[2],
                        temp2[3]
                        );
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Такого ID не существует!", "Внимание");
            }
            


        }

        private void УдалениеТовара_Load(object sender, EventArgs e)
        {

        }
    }
}
