using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileNames
{
    public partial class Form1 : Form
    {
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        DialogResult result;
        List<String> fileNames = new List<string>();
        String filePath;
        public Form1()
        {
            InitializeComponent();
            }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            result = fbd.ShowDialog();
            //string[] filenames;
            
            string[] files = Directory.GetFiles(fbd.SelectedPath);
            System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine(Path.GetFileName(files[i]));
                fileNames.Add(Path.GetFileName(files[i]));
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = fbd.ShowDialog();
            filePath = fbd.SelectedPath;
            //String fileName = textBox1.Text;
            //Console.WriteLine(filePath);
           // filePath = filePath + "\\" + fileName;
           // Console.WriteLine(filePath);

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String file_Name = textBox1.Text;
            Console.WriteLine(filePath);
            filePath = filePath + "\\" + file_Name;
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            var csv = new StringBuilder();
            fileNames.ForEach(fileName =>
            {
                csv.AppendLine(string.Join(",", fileName));
            });
            File.WriteAllText("C:\\Users\\Varun\\documents\\visual studio 2013\\Projects\\FileNames\\FileNames\\FileNames.csv", csv.ToString());
            File.WriteAllText(filePath, csv.ToString());
            System.Windows.Forms.MessageBox.Show( textBox1.Text + " File Updated", "Message");
            
        }

        }
       

        

    }

