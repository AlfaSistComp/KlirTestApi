using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.Domain.Entities.ViewModel {
    public class ProductCartViewModel {
        public int id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public int quantitypromotion { get; set; }
        public double price { get; set; }
        public double discount { get; set; }
        public double total { get; set; }
        public int idpromotion { get; set; }
        public string promotion { get; set; }
    }
}
