using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp
{
    public class Forecast
    {

        public Forecast(string desc, string tempc, string tempf, DateTime date)
        {
            Description = desc;
            Tempc = tempc;
            Tempf = tempf;
            Date = date;
        }

        public short ID { get; set; }
        public string PictureURL { get; set; }
        public string Description { get; set; }
        public string Tempc { get; set; }
        public string Tempf { get; set; }
        public DateTime Date { get; set; }
    }
}