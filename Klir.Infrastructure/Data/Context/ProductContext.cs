using Klir.Domain.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.Infrastructure.Data.Context {
    public class ProductContext : DbContext {
        public IConfiguration Configuration {
            get;
        }
        public ProductContext(DbContextOptions<ProductContext> options, IConfiguration configuration) : base(options) {
            Configuration = configuration;
            if (this.Promotion.Count() == 0) {
                this.Promotion.Add(new Domain.Entities.Model.Promotion() { Name = "Buy 1 Get 1 Free" });
                this.Promotion.Add(new Domain.Entities.Model.Promotion() { Name = "3 for 10 Euro" });
                this.SaveChanges();
            }
            if (this.Product.Count() == 0) {
                this.Product.Add(new Domain.Entities.Model.Product() { Name = "Product A", Price = 20, FKPromotion = null });
                this.Product.Add(new Domain.Entities.Model.Product() { Name = "Product B", Price = 4, FKPromotion = null });
                this.Product.Add(new Domain.Entities.Model.Product() { Name = "Product C", Price = 2, FKPromotion = null });
                this.Product.Add(new Domain.Entities.Model.Product() { Name = "Product D", Price = 4, FKPromotion = null });
                this.SaveChanges();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Promotion>().HasMany(i => i.Product).WithOne(i => i.Promotion);
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }

    }
}
