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

namespace Unit_35_Computer_Programming
{
    public partial class Form1 : Form
    {
        class row
        {
            public double time;
            public double altimeter;
            public double current;
            public double dCurrent;
        }

        List<row> table = new List<row>();
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateDCurrent()
        {
            for (int i=1; 1 < table.Count; i++)
            {
                double dI = table[i].current - table[i - 1].current;
                double dt = table[i].time - table[i - 1].time;
                table[i].current = dI / dt;
            }
        }
        private void calculateDCalculate()
        {
            for (int i=2; i < table.Count; i++)
            {
                double dI = table[i].current - table[i - 1].current;
                double dt = table[i].time - table[i - 1].time;
                table[i].current = dI / dt;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog2.FileName = "";
            openFileDialog2.Filter = "csv Files|*.csv";
            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(openFileDialog2.FileName))
                    {
                        string line = sr.ReadLine();
                        while (!sr.EndOfStream)
                        {
                            table.Add(new row());
                            string[] r = sr.ReadLine().Split(',');
                            table.Last().time = double.Parse(r[0]);
                            table.Last().altimeter = double.Parse(r[1]);
                        }
                    }
                    calculateCurrent();
                    calculateDCurrent();
                }
                catch (IOException)
                {
                    MessageBox.Show(openFileDiaolog2.FileName + " failed to open. ");
                }
                catch (FormatException)
                {
                    MessageBox.Show(openFileDiaolog2.FileName + " is not in the right format. ");
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show(openFileDiaolog2.FileName + " is not in the right format. ");
                }
                catch (DivideByZeroException)
                {
                    MessageBox.Show(openFileDialog2.FileName + " has rows that have the same time ");
                }
            }
        }
        private void openFile
    }
}
