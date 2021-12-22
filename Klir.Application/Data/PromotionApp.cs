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
    public class PromotionApp {
        ProductContext db;
        public PromotionApp(ProductContext _db) {
            db = _db;
        }
        public async Task<List<Promotion>> GetAsync() {
            try {
                IQueryable<Promotion> _return = db.Promotion;
                return await _return.AsNoTracking().ToListAsync();
            } catch {
                return null;
            }
        }
    }
}
