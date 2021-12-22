using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.Domain.Entities.Model {
    [Table("Product")]
    public class Product {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? FKPromotion { get; set; }

        [ForeignKey("FKPromotion")]
        public Promotion Promotion { get; set; }
    }
}
