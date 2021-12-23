using Klir.Application.Calculate;
using Klir.Domain.Entities.ViewModel;
using Klir.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.Application.Data {
    public class CheckoutApp {
        public void CalculateCart(ref List<ProductCartViewModel> list) {
            foreach (var item in list) {
                IPromotion promotion = item.idpromotion switch {
                    1 => new PromotionQuantityEntity(item.quantity, item.price),
                    2 => new PromotionPriceEntity(item.quantity, item.price),
                    _ => null
                };
                if (promotion is not null) {
                    item.quantitypromotion = promotion.Quantity();
                    item.discount = promotion.Price();
                }
                item.total = ((item.quantity) * item.price) - item.discount;
            }
        }
    }
}
