using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public List<Class1> classes { get; set; }
        public Form1()
        {
            classes = GetClasses();
            InitializeComponent();
        }
        private List<Class1> GetClasses()
        {
            var list = new List<Class1>();
            list.Add(new Class1() { sum = 0, firstbox = 2, secondbox = 4 });
            list.Add(new Class1() { sum = 3, firstbox = 4, secondbox = 5 });
            return list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var classes = this.classes;
            dataGridView1.DataSource = classes;
        }
    }
}
