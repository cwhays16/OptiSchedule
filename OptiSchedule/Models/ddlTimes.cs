using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptiSchedule.Models
{
    public class ddlTimes
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public static List<ddlTimes> GetAll()
        {
            List<ddlTimes> list = new List<ddlTimes>();
            list.Add(new ddlTimes { ID = "12:00", Name = "12:00" });
            list.Add(new ddlTimes { ID = "12:15", Name = "12:15" });
            list.Add(new ddlTimes { ID = "12:30", Name = "12:30" });
            list.Add(new ddlTimes { ID = "12:45", Name = "12:45" });
            list.Add(new ddlTimes { ID = "1:00", Name = "1:00" });
            list.Add(new ddlTimes { ID = "1:15", Name = "1:15" });
            list.Add(new ddlTimes { ID = "1:30", Name = "1:30" });
            list.Add(new ddlTimes { ID = "1:45", Name = "1:45" });
            list.Add(new ddlTimes { ID = "2:00", Name = "2:00" });
            list.Add(new ddlTimes { ID = "2:15", Name = "2:15" });
            list.Add(new ddlTimes { ID = "2:30", Name = "2:30" });
            list.Add(new ddlTimes { ID = "2:45", Name = "2:45" });
            list.Add(new ddlTimes { ID = "3:00", Name = "3:00" });
            list.Add(new ddlTimes { ID = "3:15", Name = "3:15" });
            list.Add(new ddlTimes { ID = "3:30", Name = "3:30" });
            list.Add(new ddlTimes { ID = "3:45", Name = "3:45" });
            list.Add(new ddlTimes { ID = "4:00", Name = "4:00" });
            list.Add(new ddlTimes { ID = "4:15", Name = "4:15" });
            list.Add(new ddlTimes { ID = "4:30", Name = "4:30" });
            list.Add(new ddlTimes { ID = "4:45", Name = "4:45" });
            list.Add(new ddlTimes { ID = "5:00", Name = "5:00" });
            list.Add(new ddlTimes { ID = "5:15", Name = "5:15" });
            list.Add(new ddlTimes { ID = "5:30", Name = "5:30" });
            list.Add(new ddlTimes { ID = "5:45", Name = "5:45" });
            list.Add(new ddlTimes { ID = "6:00", Name = "6:00" });
            list.Add(new ddlTimes { ID = "6:15", Name = "6:15" });
            list.Add(new ddlTimes { ID = "6:30", Name = "6:30" });
            list.Add(new ddlTimes { ID = "6:45", Name = "6:45" });
            list.Add(new ddlTimes { ID = "7:00", Name = "7:00" });
            list.Add(new ddlTimes { ID = "7:15", Name = "7:15" });
            list.Add(new ddlTimes { ID = "7:30", Name = "7:30" });
            list.Add(new ddlTimes { ID = "7:45", Name = "7:45" });
            list.Add(new ddlTimes { ID = "8:00", Name = "8:00" });
            list.Add(new ddlTimes { ID = "8:15", Name = "8:15" });
            list.Add(new ddlTimes { ID = "8:30", Name = "8:30" });
            list.Add(new ddlTimes { ID = "8:45", Name = "8:45" });
            list.Add(new ddlTimes { ID = "9:00", Name = "9:00" });
            list.Add(new ddlTimes { ID = "9:15", Name = "9:15" });
            list.Add(new ddlTimes { ID = "9:30", Name = "9:30" });
            list.Add(new ddlTimes { ID = "9:45", Name = "9:45" });
            list.Add(new ddlTimes { ID = "10:00", Name = "10:00" });
            list.Add(new ddlTimes { ID = "10:15", Name = "10:15" });
            list.Add(new ddlTimes { ID = "10:30", Name = "10:30" });
            list.Add(new ddlTimes { ID = "10:45", Name = "10:45" });
            list.Add(new ddlTimes { ID = "11:00", Name = "11:00" });
            list.Add(new ddlTimes { ID = "11:15", Name = "11:15" });
            list.Add(new ddlTimes { ID = "11:30", Name = "11:30" });
            list.Add(new ddlTimes { ID = "11:45", Name = "11:45" });
            return list;
        }
    }
}