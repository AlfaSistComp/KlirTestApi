using Klir.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.Application.Calculate {
    public class PromotionQuantityEntity : IPromotion {
        private int _quantity { get; set; }
        private double _price { get; set; }
        public PromotionQuantityEntity(int quantity, double price) {
            _quantity = quantity;
            _price = price;
            UpdatePromotion();
        }
        public void UpdatePromotion() {
            _quantity = _quantity / 2;
            _price = 0;
        }

        int IPromotion.Quantity() {
            return _quantity;
        }

        double IPromotion.Price() {
            return _price;
        }
    }
}
