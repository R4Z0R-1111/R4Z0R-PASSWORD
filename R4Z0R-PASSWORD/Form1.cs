using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace R4Z0R_PASSWORD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string topic = textBox1.Text;
            string email = textBox2.Text;
            string password = textBox3.Text;
            string createManager = topic + " - " + email + " - " + password;

            File.AppendAllText("manager.txt", createManager+ "\r\n");
            listBox1.Items.Clear();
            comboBox1.Items.Clear();

            string[] lines = System.IO.File.ReadAllLines("manager.txt");
            // Display the file contents by using a foreach loop.
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                listBox1.Items.Add(line);
                comboBox1.Items.Add(line);
                comboBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            comboBox1.Items.Clear();
            string[] lines = System.IO.File.ReadAllLines("manager.txt");
            // Display the file contents by using a foreach loop.
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                listBox1.Items.Add(line);
                comboBox1.Items.Add(line);
                comboBox1.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tempFile = Path.GetTempFileName();
            string removeline = comboBox1.Text;
            using (var sr = new StreamReader("manager.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line != removeline)
                        sw.WriteLine(line);
                }
            }

            File.Delete("manager.txt");
            File.Move(tempFile, "manager.txt");

            listBox1.Items.Clear();
            comboBox1.Items.Clear();

            string[] lines = System.IO.File.ReadAllLines("manager.txt");
            // Display the file contents by using a foreach loop.
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                listBox1.Items.Add(line);
                comboBox1.Items.Add(line);
                comboBox1.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(string.Join(Environment.NewLine, listBox1.SelectedItems.OfType<string>()));
        }
    }
}
