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

namespace WCL_Facker
{
    public partial class fmMain : Form
    {
        List<LineObj> lineObjs = new List<LineObj>();
        TimeSpan totalTimeSpan;
        public fmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择WCL文件路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetLogFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "WCL文件(*.txt)|*.txt";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.tbxLogFilePath.Text = ofd.FileName;
                }
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            List<string> lines = this.ReadWclFile(this.tbxLogFilePath.Text);
            for (int i = 0; i < lines.Count; i++)
            {
                this.lineObjs.Add(new LineObj(lines[i]));
            }
            if (this.lineObjs != null)
            {
                this.totalTimeSpan = this.lineObjs[this.lineObjs.Count - 1].DT - this.lineObjs[0].DT;
            }
            MessageBox.Show(this.totalTimeSpan.ToString());
        }


        private List<string> ReadWclFile(string logFilePath)
        {
            List<string> lines;
            using (StreamReader sr = new StreamReader(this.tbxLogFilePath.Text, Encoding.UTF8))
            {
                string a = sr.ReadToEnd();
                string[] all = a.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                lines = all.ToList();
            }
            return lines;
        }

        private void btnFacker_Click(object sender, EventArgs e)
        {
            double totalSeconds = this.totalTimeSpan.TotalSeconds;
            int divider = int.Parse(this.tbxDivider.Text);
            for (int i = 0; i < this.lineObjs.Count; i++)
            {
                DateTime dt = this.lineObjs[i].DT;
                TimeSpan ts = this.lineObjs[i].DT - this.lineObjs[0].DT;
                ts = new TimeSpan(ts.Ticks / divider);
                this.lineObjs[i].DT = this.lineObjs[0].DT + ts;
            }
            string all = "";
            for (int i = 0; i < lineObjs.Count; i++)
            {
                all = all + lineObjs[i].Date + ' ' + lineObjs[i].Time + "  " + lineObjs[i].ACT + Environment.NewLine;
            }
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "WCL文件(*.txt)|*.txt";
                if (sfd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(sfd.FileName))
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        sw.Write(all);
                    }
                    MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            int divider = int.Parse(this.tbxDivider.Text);
            if (divider <= 2)
            {
                ;
            }
            else
            {
                this.tbxDivider.Text = (divider - 1).ToString();
            }
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            int divider = int.Parse(this.tbxDivider.Text);
            if (divider >= int.MaxValue)
            {
                ;
            }
            else
            {
                this.tbxDivider.Text = (divider + 1).ToString();
            }
        }
    }
}
