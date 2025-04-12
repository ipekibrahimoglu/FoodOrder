
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<SouthwindContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //User
            builder.Services.AddScoped<IUserService, UserManager>();
            builder.Services.AddScoped<IUserDal, EfUserDal>();

            //Menu
            builder.Services.AddScoped<IMenuService, MenuManager>();
            builder.Services.AddScoped<IMenuDal, EfMenuDal>();

            //MenuItem
            builder.Services.AddScoped<IMenuItemService, MenuItemManager>();
            builder.Services.AddScoped<IMenuItemDal, EfMenuItemDal>();

            //Order
            builder.Services.AddScoped<IOrderService, OrderManager>();
            builder.Services.AddScoped<IOrderDal, EfOrderDal>();

            //OrderItem
            builder.Services.AddScoped<IOrderItemService, OrderItemManager>();
            builder.Services.AddScoped<IOrderItemDal, EfOrderItemDal>();

            //Payment
            builder.Services.AddScoped<IPaymentService, PaymentManager>();
            builder.Services.AddScoped<IPaymentDal, EfPaymentDal>();

            //Restaurant
            builder.Services.AddScoped<IRestaurantService, RestaurantManager>();
            builder.Services.AddScoped<IRestaurantDal, EfRestaurantDal>();

            //Review
            builder.Services.AddScoped<IReviewService, ReviewManager>();
            builder.Services.AddScoped<IReviewDal, EfReviewDal>();

            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
