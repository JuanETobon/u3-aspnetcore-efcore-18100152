using System;
using System.Collections.Generic;

#nullable disable

namespace u3_aspnetcore_efcore_18100152.Models
{
    public partial class Marca
    {
        public int Id { get; set; }
        public int? IdModelo { get; set; }
        public string NombreDeMarca { get; set; }

        public virtual Modelo IdModeloNavigation { get; set; }
    }
}
