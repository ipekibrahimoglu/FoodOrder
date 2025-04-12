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
        public SouthwindContext()
        {
            //bos ctor
        }
        //WebAPI'da AddDbContext() fonksiyonunu calistirabilmek icin ctor overload edildi.
        public SouthwindContext(DbContextOptions<SouthwindContext> options)
            : base(options)
        {
        }

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

        //DTOlari da eklemek gerekli olacak mi?
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.UserId)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<Restaurant>()
                .Property(r => r.RestaurantId)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<Menu>()
                .Property(m => m.MenuId)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<MenuItem>()
                .Property(mi => mi.MenuItemId)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderId)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.OrderItemId)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentId)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<Review>()
                .Property(r => r.ReviewId)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            //----------------------------------------------------------------------------
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

            modelBuilder.Entity<Review>().ToTable(x=>x.HasCheckConstraint("CK_Review_Rating", "[Rating] >= 1 AND [Rating] <= 5"));

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

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            //------------------------------------------------------------------------------------------

            modelBuilder.Entity<MenuItem>()
                .Property(mi => mi.Price)
                .HasColumnType("decimal(18,2)");

            // Order.TotalPrice için
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalPrice)
                .HasColumnType("decimal(18,2)");

            // OrderItem.Price için
            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Price)
                .HasColumnType("decimal(18,2)");

            // Payment.Amount için
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");
            //-----------------------------------Data Seeding--------------------------------------------

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    FullName = "Basak Selin Sertel",
                    Email = "basak@gmail.com",
                    PasswordHash = "hashedPwd1",
                    Role = "RestaurantOwner",
                    PhoneNumber = "555-000-1111"
                },
                new User
                {
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    FullName = "Muratcan Kara",
                    Email = "muratfivem@gmail.com",
                    PasswordHash = "hashedPwd2",
                    Role = "Customer",
                    PhoneNumber = null
                }
            );

            
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    RestaurantId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    OwnerId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Dish up!",
                    Description = "Türk mutfağından seçkin lezzetler",
                    Address = "Muh fakultesi",
                    PhoneNumber = "0212-000-0000"
                }
            );

            
            modelBuilder.Entity<Menu>().HasData(
                new Menu
                {
                    MenuId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    RestaurantId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    Name = "Ana Yemekler",
                    Description = "Et ve tavuk çeşitleri"
                }
            );

            
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem
                {
                    MenuItemId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    MenuId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Adana Kebap",
                    Price = 85.00m, // sayisal sabit turu m ile belirtilir ( implicitly double -> decimal )
                    Description = "Acılı acısız seçenekleriyle",
                    ImageUrl = null
                },
                new MenuItem
                {
                    MenuItemId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    MenuId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Tavuk Şiş",
                    Price = 75.00m,
                    Description = "Özel marinasyonlu tavuk",
                    ImageUrl = null
                }
            );

            
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    RestaurantId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    OrderDate = DateTime.Parse("2025-04-10T12:00:00"),
                    TotalPrice = 160.00m,
                    Status = "Pending" // status booldan stringe cekildi
                }
            );

            
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    OrderItemId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    OrderId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    MenuItemId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    Quantity = 1,
                    Price = 85.00m
                },
                new OrderItem
                {
                    OrderItemId = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                    OrderId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    MenuItemId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    Quantity = 1,
                    Price = 75.00m
                }
            );

            
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    PaymentId = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                    OrderId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    PaymentDate = DateTime.Parse("2025-04-10T12:05:00"),
                    Amount = 160.00m,
                    PaymentMethod = "CreditCard",
                    IsSuccessful = true
                }
            );

            
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    ReviewId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    RestaurantId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    Rating = 5
                }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
