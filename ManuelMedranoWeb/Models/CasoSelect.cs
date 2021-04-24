using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ManuelMedranoWeb.Models
{
    [Table("casoselect")]
    public partial class Casoselect
    {
        public Casoselect()
        {
            Caso = new HashSet<Caso>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column("nombre", TypeName = "varchar(45)")]
        public string Nombre { get; set; }

        [InverseProperty("IdCasoSelectNavigation")]
        public virtual ICollection<Caso> Caso { get; set; }
    }
}
