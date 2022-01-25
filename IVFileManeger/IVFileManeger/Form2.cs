using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IVFileManeger
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            save.Click += TextBox_TextChanged;
        }
        public string changeName;

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            changeName = textBox1.Text;
            textBox1.Clear();
            Close();
        }
    }
}
