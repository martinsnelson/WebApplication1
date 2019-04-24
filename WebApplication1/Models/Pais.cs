using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Pais
    {
        public Pais()
        {
            Regiao = new HashSet<Regiao>();
        }

        public int IdPais { get; set; }
        public string Nome { get; set; }

        public ICollection<Regiao> Regiao { get; set; }
    }
}
