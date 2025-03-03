using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DataAccess.Concrete.EntityFramework
{
    // Db tablolari ile proje classlari iliskisi
    public class SouthwindContext : DbContext
    {
        //proje-veritabani iliskisini belirtir
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\localDB1;Database=Southwind;Trusted_Connection=true");
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Menu - Restaurant ilişkisi (bir Restaurant'ın birden fazla Menüsü olabilir)
            modelBuilder.Entity<Menu>()
                .HasOne(m => m.Restaurant)
                .WithMany(r => r.Menus)
                .HasForeignKey(m => m.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            // MenuItem - Menu ilişkisi
            modelBuilder.Entity<MenuItem>()
                .HasOne(mi => mi.Menu)
                .WithMany(m => m.MenuItems)
                .HasForeignKey(mi => mi.MenuId);

            // Order - User ilişkisi
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId);
                


            // Order - Restaurant ilişkisi
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Restaurant)
                .WithMany()  // Restaurant entity’sinde Order ile ilgili koleksiyon tanımlıysa: .WithMany(r => r.Orders)
                .HasForeignKey(o => o.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            // OrderItem - Order ilişkisi
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            // OrderItem - MenuItem ilişkisi
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.MenuItem)
                .WithMany()
                .HasForeignKey(oi => oi.MenuItemId);

            //Review - User ilişkisi
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews) // veya eğer User sınıfında Reviews adında bir koleksiyon varsa: .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);
                


            // Review - Restaurant ilişkisi
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Restaurant)
                .WithMany(re => re.Reviews) // Restaurant tarafında Reviews koleksiyonu varsa : WithMany(r => r.Reviews) 
                .HasForeignKey(r => r.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);


            // Restaurant - Owner (User) ilişkisi
            modelBuilder.Entity<Restaurant>()
                .HasOne(r => r.Owner)
                .WithMany(u => u.OwnedRestaurants)
                .HasForeignKey(r => r.OwnerId);
                
                

            // Payment - Order iliskisi
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithMany()
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            

            base.OnModelCreating(modelBuilder);
        }

    }
}
