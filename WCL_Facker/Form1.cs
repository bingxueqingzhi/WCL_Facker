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
using System.Runtime.CompilerServices;

namespace WCL_Facker
{
    public partial class fmMain : Form
    {
        List<LineObj> lineObjs = new List<LineObj>();
        TimeSpan totalTimeSpan;
        Action<string> writeNewWCL;
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
            this.lineObjs.Clear();
            List<string> lines = this.ReadWclFile(this.tbxLogFilePath.Text);
            for (int i = 0; i < lines.Count; i++)
            {
                this.lineObjs.Add(new LineObj(lines[i]));
            }
            if (this.lineObjs != null)
            {
                this.totalTimeSpan = this.lineObjs[this.lineObjs.Count - 1].DT - this.lineObjs[0].DT;
            }
            this.pbProgress1.Maximum = this.lineObjs.Count;
            this.lblProgress.Text = "0/" + this.lineObjs.Count.ToString();
            MessageBox.Show("Total WCL Timespan: " + this.totalTimeSpan.ToString());
        }

        /// <summary>
        /// 读WCL文件
        /// </summary>
        /// <param name="logFilePath">WCL文件路径</param>
        /// <returns></returns>
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
            int divider = int.Parse(this.tbxDivider.Text);
            for (int i = 0; i < this.lineObjs.Count; i++)
            {
                TimeSpan ts = this.lineObjs[i].DT - this.lineObjs[0].DT;
                ts = new TimeSpan(ts.Ticks / divider);
                this.lineObjs[i].DT = this.lineObjs[0].DT + ts;
            }
            string path = "";
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "WCL文件(*.txt)|*.txt";
                if (sfd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(sfd.FileName))
                {
                    path = sfd.FileName;
                    this.btnFacker.Enabled = this.btnRead.Enabled = this.btnM.Enabled = this.btnP.Enabled = this.btnGetLogFilePath.Enabled = false;
                    this.writeNewWCL = this.WriteNewWCL;
                    this.writeNewWCL.BeginInvoke(path, null, null);
                }
            }
        }

        private void WriteNewWCL(string path)
        {
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8))
            {
                for (int i = 0; i < lineObjs.Count; i++)
                {
                    sw.WriteLine(lineObjs[i].Date + ' ' + lineObjs[i].Time + "  " + lineObjs[i].ACT);
                    if (this.pbProgress1.InvokeRequired)
                    {
                        Action<ProgressBar, int> action = this.ChangeProgressBar;
                        this.pbProgress1.Invoke(action, this.pbProgress1, i);
                    }
                    else
                    {
                        this.pbProgress1.Value = i;
                    }
                }
            }
            this.ChangeBtnEnable(this.btnGetLogFilePath, true);
            this.ChangeBtnEnable(this.btnRead, true);
            this.ChangeBtnEnable(this.btnFacker, true);
            this.ChangeBtnEnable(this.btnM, true);
            this.ChangeBtnEnable(this.btnP, true);
        }
        private void ChangeProgressBar(ProgressBar pb, int value)
        {
            pb.Value = value;
        }
        private void ChangeBtnEnable(Button btn, bool enable)
        {
            if (btn.InvokeRequired)
            {
                Action<Button, bool> action = (btn1, enable1) => btn1.Enabled = enable1;
                btn.BeginInvoke(action, btn, enable);
            }
            else
            {
                btn.Enabled = enable;
            }
        }
        private void ChangeLblText(Label lbl, string txt)
        {
            lbl.Text = txt;
        }
        private void btnM_Click(object sender, EventArgs e)
        {
            int divider = int.Parse(this.tbxDivider.Text);
            if (divider <= 1)
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
