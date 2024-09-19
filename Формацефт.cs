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
    public partial class Формацефт : Form
    {

        Medicine medicine = new Medicine();
        string job_id;

        public Формацефт()
        {
            InitializeComponent();
        }
        public Формацефт(string job)
        {
            InitializeComponent();
            job_id = job;
        }

        private void Формацефт_Load(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            // Таблица Фармацевтов

            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Название", typeof(string));
            dt.Columns.Add("Количество товара", typeof(string));
            dt.Columns.Add("Цена(в рублях)", typeof(string));

            List<string> med = medicine.GetMedicine();

            for (int i = 0; i < med.Count; i++)
            {
                dt.Rows.Add(
                    med[i].Split(":")[0],
                    med[i].Split(":")[1],
                    med[i].Split(":")[2],
                    med[i].Split(":")[3]
                    );
            }

            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            УдалениеТовара newMDIChild = new УдалениеТовара(job_id);
            newMDIChild.MdiParent = Form1.ActiveForm;
            newMDIChild.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ПринятиеТовара newMDIChild = new ПринятиеТовара(job_id);
            newMDIChild.MdiParent = Form1.ActiveForm;
            newMDIChild.Show();
        }
    }
}
