namespace Курсач
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string user = "";
        string job = "";
        private void какАптекарьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Вход newMDIChild = new Вход();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void авторизацияToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void какАдминистраторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Вход_администратора newMDIChild = new Вход_администратора();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void какТовароведToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Вход_товароведа newMDIChild = new Вход_товароведа();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void историяToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void историяПроToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ИсторияПродуктов newMDIChild = new ИсторияПродуктов();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}