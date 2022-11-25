using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App1
{
    public partial class Form1 : Form
    {
        List<string> split = new List<string>();
        List<string> matchValues = new List<string>();
        public Form1()
        {
            InitializeComponent();
            this.textBox1.TextChanged += TextBox1_TextChanged;
            string readFile = System.IO.File.ReadAllText(@"C:\Users\k.h.panneerselvam\source\repos\App1\App1\ReadInputFile.txt");
            var splitFile = readFile.Split('~');
            split.AddRange(splitFile);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = -1;
            if (!string.IsNullOrEmpty(this.textBox1.Text))
            {
                index = split.FindIndex(x => x.Contains(this.textBox1.Text));
                if(index != -1)
                {
                    this.textBox2.Text = index.ToString();
                }
                else
                {
                    MessageBox.Show("No match data found");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(this.textBox2.Text))
            {
                int lineindex = Convert.ToInt32(this.textBox2.Text);
                int elementIndex = Convert.ToInt32(this.textBox3.Text);
                string line = split[lineindex];
                var splitline = line.Split('*');

                if (splitline.Count() > 0 && splitline.Count() - 1 >= Convert.ToInt32(this.textBox3.Text))
                    this.textBox4.Text = splitline[elementIndex];
            }
        }
    }
}
