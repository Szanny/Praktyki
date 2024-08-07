using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wielowątkowosc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Komponenty();
        }
        public void Komponenty()
        {
            button1.Text = "Generuj";
            numericUpDown1.Minimum = 3;
            numericUpDown1.Maximum = 6;
            listBox2.ScrollAlwaysVisible = true;
            label1.Text = "Progres: 0/1000";
            label2.Text = "Długość permutacji";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var wybranyElement =  int.Parse(numericUpDown1.Value.ToString());
            int maksymalnaWielkoscPermutacji = WielkoscPermutacji(wybranyElement);

            progressBar1.Maximum = maksymalnaWielkoscPermutacji;
            progressBar1.Value = 0;
            label1.Text = $"Progres: 0/{maksymalnaWielkoscPermutacji}";

            int[] permutacja = new int[wybranyElement];

            for (int i = 0; i < maksymalnaWielkoscPermutacji; i++)
            {
                listBox2.Items.Add(string.Join("", permutacja));
                progressBar1.Value++;
                label1.Text = $"Progres: {progressBar1.Value}/{maksymalnaWielkoscPermutacji}";
                await Task.Delay(100);

                WykonaniePermutacji(permutacja);
            }

        }
        private void WykonaniePermutacji(int[] permutacjaa)
        {
                int index = permutacjaa.Length - 1;
                while (index >= 0)
                {
                    permutacjaa[index]++;
                    if (permutacjaa[index] < 10)
                    {
                        break;
                    }
                    permutacjaa[index] = 0;
                    index--;
                }
                
            }
        private int WielkoscPermutacji(int element)
        {
            if (element == 3)
            {
                return 1000;
            }
            if (element == 4)
            {
                return 10000;
            }
            if (element == 5)
            {
                return 100000;
            }
            if (element == 6)
            {
                return 1000000;
            }
            else 
                return 0;
        }

    }
}
