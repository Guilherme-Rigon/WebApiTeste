using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public int TipoId { get; set; }
        public virtual Tipo Tipo { get; set; }
    }
}
