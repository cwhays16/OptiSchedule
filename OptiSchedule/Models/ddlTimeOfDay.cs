using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptiSchedule.Models
{
    public class ddlTimeOfDay
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public static List<ddlTimeOfDay> GetAll()
        {
            List<ddlTimeOfDay> list = new List<ddlTimeOfDay>();
            list.Add(new ddlTimeOfDay { ID = "AM", Name = "AM" });
            list.Add(new ddlTimeOfDay { ID = "PM", Name = "PM" });
            return list;
        }
    }
}