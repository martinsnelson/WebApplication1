using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Metrica
    {
        public long IdMetrica { get; set; }
        public long? TimeStamp { get; set; }
        public string Valor { get; set; }
        public string Processado { get; set; }
        public int CdSensor { get; set; }

        public Sensor CdSensorNavigation { get; set; }
    }
}
