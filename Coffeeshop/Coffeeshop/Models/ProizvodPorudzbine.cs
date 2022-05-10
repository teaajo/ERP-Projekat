using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Coffeeshop.Models
{
    public partial class ProizvodPorudzbine
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("IdProizvod")]
        public int? IdProizvod { get; set; }
        [ForeignKey("IdProizvod")]
        public Proizvod Proizvod { get; set; }
        [ForeignKey("IdPorudzbine")]
        public int? IdPorudzbine { get; set; }
        public virtual Porudzbine IdPorudzbineNavigation { get; set; }
        public virtual Proizvod IdProizvodNavigation { get; set; }

    }
}
