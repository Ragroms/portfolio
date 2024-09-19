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
    public partial class Товаровед : Form
    {

        Supplies sup = new Supplies();
        string id;

        public Товаровед()
        {
            InitializeComponent();
        }
        public Товаровед(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Товаровед_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            // Таблица Фармацевтов

            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Название", typeof(string));
            dt.Columns.Add("Количество товара", typeof(string));
            dt.Columns.Add("Общая цена (в рублях)", typeof(string));

            List<string> supplice = sup.GetSupplice();

            double totalSup;

            for (int i = 0; i < supplice.Count; i++)
            {

                dt.Rows.Add(
                    supplice[i].Split(":")[0],
                    supplice[i].Split(":")[1],
                    supplice[i].Split(":")[2],
                    supplice[i].Split(":")[3]
                    );
            }

            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            УдаленияТовараСоСклада newMDIChild = new УдаленияТовараСоСклада(id);
            newMDIChild.MdiParent = Form1.ActiveForm;
            newMDIChild.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ЗаказатьТовар newMDIChild = new ЗаказатьТовар(id);
            newMDIChild.MdiParent = Form1.ActiveForm;
            newMDIChild.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ОтправаТовараВАптеку newMDIChild = new ОтправаТовараВАптеку(id);
            newMDIChild.MdiParent = Form1.ActiveForm;
            newMDIChild.Show();

        }
    }
}
