using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignAPI.Models.Entity
{
    public class CocheEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Periodo { get; set; }
        public string Modelo { get; set; }
        public string Notas { get; set; }
        public string Firma { get; set; }
        public string Imagen { get; set; }
        public double PujaInicial { get; set; }
    }
}
