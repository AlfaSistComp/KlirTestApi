using Klir.Domain.Base;
using Klir.Domain.Entities.Model;
using Klir.Domain.Entities.ViewModel;
using Klir.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.Application.Data {
    public class ProductApp {
        ProductContext db;
        public ProductApp(ProductContext _db) {
            db = _db;
        }
        public async Task<List<ProductViewModel>> GetAsync() {
            try {
                var _return = db.Product.Include(i=>i.Promotion).Select(i=> new ProductViewModel{ 
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    Idpromotion = (i.Promotion == null ? 0 : i.Promotion.Id) ,
                    Promotion = (i.Promotion == null ? "" : i.Promotion.Name)
                }).AsQueryable();
                return await _return.ToListAsync();
            } catch {
                return null;
            }
        }
        public async Task<Product> GetAsync(int id) {
            try {
                return await db.Product.AsNoTracking().Where(i => i.Id == id).FirstOrDefaultAsync();
            } catch {
                return null;
            }
        }
        public bool BindProductPromotion(int idProduct, int idPromotion) {
            var _prod = db.Product.Where(i => i.Id == idProduct).FirstOrDefault();
            if (_prod is null) {
                return false;
            } else {
                if (idPromotion == 0) {
                    _prod.FKPromotion = null;
                } else {
                    _prod.FKPromotion = idPromotion;
                }
                try {
                    db.SaveChanges();
                    return true;
                } catch {
                    return false;
                }
            }
        }
    }
}
