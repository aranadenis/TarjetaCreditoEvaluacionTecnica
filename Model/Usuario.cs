using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioID { get; set; }

       
        public string PrimerNombre { get; set; }

       
        public string SegundoNombre { get; set; }

        
        public string PrimerApellido { get; set; }

       
        public string SegundoApellido { get; set; }

        
        public string Dui { get; set; }

        
        public string CorreoElectronico { get; set; }

        
        public string Telefono { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaRegistro { get; set; }

        // Relaciones
        public ICollection<Tarjeta> Tarjetas { get; set; }
    }
}
