using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataViewGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Podstawa();
            Suma();
        }
        private void Podstawa()
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "A";
            dataGridView1.Columns[1].Name = "B";
            dataGridView1.Columns[2].Name = "C";
            dataGridView1.Columns[3].Name = "D";

            for (int i = 0; i < 4; i++)
            {
                dataGridView1.Rows.Add();
            }

            dataGridView1.Rows[0].DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
            dataGridView1.Rows[0].ReadOnly = true;

            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }
        private void Suma()
        {
            for (int c = 0; c < dataGridView1.ColumnCount; c++)
            {
                int sum = 0;
                for(int r = 1; r < dataGridView1.RowCount; r++)
                {
                    if (dataGridView1.Rows[r].Cells[c].Value != null)
                    {
                        if (int.TryParse(dataGridView1.Rows[r].Cells[c].Value.ToString(), out int liczba))
                        {
                            sum += liczba;
                        }
                    }
                }
                //if sum > 1000 blad ma sie wyswietlic
                dataGridView1.Rows[0].Cells[c].Value = sum;
            }
        }
        public void Okno()
        {
            Form prompt = new Form();
            {

            };
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                Suma();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
