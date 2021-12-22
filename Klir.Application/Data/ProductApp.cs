using Klir.Domain.Base;
using Klir.Domain.Entities.Model;
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
        public async Task<List<Product>> GetAsync() {
            try {
                IQueryable<Product> _return = db.Product;
                return await _return.AsNoTracking().ToListAsync();
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
            if (_prod == null) {
                return false;
            } else {
                _prod.FKPromotion = idPromotion;
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
