using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ManuelMedranoWeb.Models
{
    [Table("cliente")]
    public partial class Cliente
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column("nombre", TypeName = "varchar(45)")]
        public string Nombre { get; set; }
        [Required]
        [Column("apellido", TypeName = "varchar(45)")]
        public string Apellido { get; set; }
        [Required]
        [Column("email", TypeName = "varchar(45)")]
        public string Email { get; set; }
        [Required]
        [Column("contacto", TypeName = "varchar(45)")]
        public string Contacto { get; set; }
        [Required]
        [Column("direccion", TypeName = "varchar(100)")]
        public string Direccion { get; set; }
    }
}
