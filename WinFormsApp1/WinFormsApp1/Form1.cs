using System.Data;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable table = new DataTable();

            table.Columns.Add("A", typeof(int));
            table.Columns.Add("B", typeof(int));
            table.Columns.Add("C", typeof(int));
            table.Columns.Add("D", typeof(int));

            dataGridView1.DataSource = table;
        }
    }
}