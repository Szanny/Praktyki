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
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Popup);
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
            dataGridView1.RowsRemoved += dataGridView1_RowDeleted;
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
                if (sum >= 0 && sum <= 1000)
                {
                    dataGridView1.Rows[0].Cells[c].Value = sum;
                }
                else
                {
                    dataGridView1.Rows[0].Cells[c].Value = "blad";
                }
            }
        }
        private void Okno()
        {
            Form prompt1 = new Form();
            {
                prompt1.Width = 300;
                prompt1.Height = 200;
            };
            Label textLabel = new Label() { Left = 25, Top = 25, Text = "podaj numer: " };
            TextBox inputBox = new TextBox() { Left = 40, Top = 80, Width = 100};
            Button potwierdz = new Button() { Text = "OK", Left = 50, Top = 100, Width = 30 };
            potwierdz.Click += (sender, e) => { WypelnijTabele(inputBox.Text); prompt1.Close(); };

            prompt1.Controls.Add(textLabel);
            prompt1.Controls.Add(inputBox);
            prompt1.Controls.Add(potwierdz);
            prompt1.ShowDialog();
        }
        public void WypelnijTabele(string input)
        {
            if(int.TryParse(input, out int numer))
            {
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    if(cell.RowIndex != 0)
                    {
                        cell.Value = numer;
                    }
                }
            }
            Suma();
        }
        public void Popup(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.E)
            {
                Okno();
            }
        }

        private void dataGridView1_RowDeleted(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                Suma();
            }
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
