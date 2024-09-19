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
    public partial class ИсторияПродуктов : Form
    {

        Logs log = new Logs();

        public ИсторияПродуктов()
        {
            InitializeComponent();
        }

        private void ИсторияПродуктов_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            // Таблица Фармацевтов

            dt.Columns.Add("Действия", typeof(string));
            dt.Columns.Add("ID работника", typeof(string));
            dt.Columns.Add("Фамилия работника", typeof(string));
            dt.Columns.Add("ID продукта", typeof(string));
            dt.Columns.Add("Названия продукта", typeof(string));
            dt.Columns.Add("Количество продукта", typeof(string));
            dt.Columns.Add("Цена продукта", typeof(string));

            List<string> logs = log.GetLogs();

            for (int i = 0; i < logs.Count; i++)
            {
                dt.Rows.Add(
                    logs[i].Split(":")[0],
                    logs[i].Split(":")[1],
                    logs[i].Split(":")[2],
                    logs[i].Split(":")[3],
                    logs[i].Split(":")[4],
                    logs[i].Split(":")[5],
                    logs[i].Split(":")[5]
                    );
            }

            dataGridView1.DataSource = dt;
        }
    }
}
