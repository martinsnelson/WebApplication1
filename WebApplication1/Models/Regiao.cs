using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Regiao
    {
        public Regiao()
        {
            Sensor = new HashSet<Sensor>();
        }

        public int IdRegiao { get; set; }
        public string Nome { get; set; }
        public int CdPais { get; set; }

        public Pais CdPaisNavigation { get; set; }
        public ICollection<Sensor> Sensor { get; set; }
    }
}
