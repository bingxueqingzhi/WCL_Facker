using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCL_Facker
{
    class LineObj
    {
        public string Date { set; get; }
        public string Time { set; get; }
        public string Motion { set; get; }//动作
        public string CasterID { set; get; }//动作执行人ID
        public string CasterName { set; get; }//动作执行人名字
        public string TargetID { set; get; }//动作被执行人ID
        public string TargetName { set; get; }//动作被执行人名字
        public string SpellID { set; get; }//法术ID
        public string SpellName { set; get; }//法术名称

        public LineObj(string line)
        {
            string[] s = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            this.Date = s[0];
            this.Time = s[1];
            this.Motion = s[2];
            this.CasterID = s[3];
            this.CasterName = s[4];
            if (s.Length >= 9)
            {
                this.TargetID = s[7];
                this.TargetName = s[8];
            }
            if (s.Length >= 13)
            {
                this.SpellID = s[11];
                this.SpellName = s[12];
            }
        }
        public DateTime DT
        {
            get
            {
                string[] date = this.Date.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                string[] time = this.Time.Split(new char[] { ':', '.' }, StringSplitOptions.RemoveEmptyEntries);
                int year = 2020;
                int month = int.Parse(date[0]);
                int day = int.Parse(date[1]);
                int hour = int.Parse(time[0]);
                int minute = int.Parse(time[1]);
                int second = int.Parse(time[2]);
                int milisecond = int.Parse(time[3]);
                DateTime dt = new DateTime(year, month, day, hour, minute, second, milisecond, DateTimeKind.Utc);
                return dt;
            }
            set
            {
                this.Date = value.Month.ToString() + '/' + value.Day.ToString();
                this.Time = value.Hour.ToString() + ':' + value.Minute.ToString() + ':' + value.Second.ToString() + '.' + value.Millisecond.ToString();
            }
        }
    }
}
