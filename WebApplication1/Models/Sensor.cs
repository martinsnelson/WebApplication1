using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Sensor
    {
        public Sensor()
        {
            Metrica = new HashSet<Metrica>();
        }

        public int IdSensor { get; set; }
        public string Nome { get; set; }
        public int CdRegiao { get; set; }

        public Regiao CdRegiaoNavigation { get; set; }
        public ICollection<Metrica> Metrica { get; set; }
    }
}
