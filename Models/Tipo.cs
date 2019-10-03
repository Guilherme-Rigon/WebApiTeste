using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Tipo
    {
        [Key]
        public int Id { get; set; }
        public string TipoNome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; } 
    }
}
