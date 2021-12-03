using System;
using System.Collections.Generic;

#nullable disable

namespace u3_aspnetcore_efcore_18100152.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            Marcas = new HashSet<Marca>();
        }

        public int Id { get; set; }
        public string ModeloDeZapato { get; set; }

        public virtual ICollection<Marca> Marcas { get; set; }
    }
}
