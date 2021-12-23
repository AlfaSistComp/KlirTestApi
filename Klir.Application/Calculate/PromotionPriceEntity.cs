using Klir.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.Application.Calculate {
    public class PromotionPriceEntity : IPromotion {
        private int _quantity { get; set; }
        private double _price { get; set; }
        public PromotionPriceEntity(int quantity, double price) {
            _quantity = quantity;
            _price = price;
            UpdatePromotion();
        }
        public void UpdatePromotion() {
            int _total = _quantity / 3;
            _price = ((_price * 3) - 10) * _total;
            _quantity = 0;
        }

        int IPromotion.Quantity() {
            return _quantity;
        }

        double IPromotion.Price() {
            return _price;
        }
    }
}
