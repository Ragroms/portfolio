using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Курсач
{
    public partial class Администратор : Form
    {
        Pharmacists pharmacists = new Pharmacists(); // вызов классов
        WarehouseWorker warehouseWorker = new WarehouseWorker();
        Logs logs = new Logs();

        string job = "pharmacist";

        public Администратор()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e) // обновление
        {
            DataTable dt = new DataTable(); // создание таблицы

            // Таблица Фармацевтов

            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Пароль", typeof(string));
            dt.Columns.Add("Фамилия", typeof(string));
            dt.Columns.Add("Имя", typeof(string));
            dt.Columns.Add("Отчество", typeof(string));

            List<string> pharm = pharmacists.GetPharmacists();

            for (int i = 0; i < pharm.Count; i++)
            {
                dt.Rows.Add(
                    pharm[i].Split(":")[0],
                    pharm[i].Split(":")[1],
                    pharm[i].Split(":")[2],
                    pharm[i].Split(":")[3],
                    pharm[i].Split(":")[4]
                    );
            }

            dataGridView1.DataSource = dt; // загрузка таблици на форму

            DataTable dt2 = new DataTable(); // Таблица Товароведов

            dt2.Columns.Add("ID", typeof(string));
            dt2.Columns.Add("Пароль", typeof(string));
            dt2.Columns.Add("Фамилия", typeof(string));
            dt2.Columns.Add("Имя", typeof(string));
            dt2.Columns.Add("Отчество", typeof(string));

            List<string> warehouseworker = warehouseWorker.GetWarehouseWorker();

            for (int i = 0; i < warehouseworker.Count; i++)
            {
                dt2.Rows.Add(
                    warehouseworker[i].Split(":")[0],
                    warehouseworker[i].Split(":")[1],
                    warehouseworker[i].Split(":")[2],
                    warehouseworker[i].Split(":")[3],
                    warehouseworker[i].Split(":")[4]
                    );
            }

            dataGridView2.DataSource = dt2;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Добавление_рабочего newMDIChild = new Добавление_рабочего(job);
            newMDIChild.MdiParent = Form1.ActiveForm;
            newMDIChild.Show();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Удаление_рабочего newMDIChild = new Удаление_рабочего(job);
            newMDIChild.MdiParent = Form1.ActiveForm;
            newMDIChild.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                job = "pharmacist";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                job = "warehouseWorker";
            }

        }

        private void Администратор_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void button4_Click(object sender, EventArgs e) // ичистка истории
        {
            logs.AllDeleteLogs();
        }
    }
}
