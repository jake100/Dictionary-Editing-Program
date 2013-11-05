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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private string[] words;
        private string file, wordToAdd = "";
        private int lineCount, num;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string path = "dictionary.txt";
                file = File.ReadAllText(path);
                richTextBox1.Text = file;
                using (StreamReader sr = File.OpenText(path))
                {
                    lineCount = File.ReadLines(path).Count();
                    words = new string[lineCount];
                    for (var i = 0; i < lineCount;i++)
                    {
                        words[i] = sr.ReadLine();
                    }
                }
            }
            catch(Exception ex)
            {
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addWord(textBox1.Text, true);
        }
        private void addWord(string text, bool isShow)
        {
            bool isInFile = false;
            wordToAdd = text;
            num = 0;
            for (var i = 0; i < lineCount; i++)
            {
                if (text == words[i])
                {
                    isInFile = true;
                    num = i;
                }
            }
            if (isShow) show(text, isInFile);
        }
        private void show(string text, bool isInFile)
        {
            if (wordToAdd == "")
            {
                toolStripStatusLabel1.Text = "nothing typed.";
            }
            else
            {
                if (isInFile)
                {
                    toolStripStatusLabel1.Text = text + " is in dictionary already #" + num + ".";
                    textBox1.Text = "";
                }
                else
                {
                    toolStripStatusLabel1.Text = text + " added.";
                    file += Environment.NewLine + text;
                    richTextBox1.Text = file;
                }
            }
        }
        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog1.FileName, file);
                }
                catch (Exception ex) {}

                System.IO.StreamReader sr = new System.IO.StreamReader(saveFileDialog1.FileName);
                sr.Close();
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(openFileDialog1.FileName, file);
                }
                catch (Exception ex) {}

                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                sr.Close();
            }
        }
    }
}
