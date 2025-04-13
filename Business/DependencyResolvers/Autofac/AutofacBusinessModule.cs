using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MenuItemManager>().As<IMenuItemService>().InstancePerLifetimeScope();
            builder.RegisterType<MenuManager>().As<IMenuService>().InstancePerLifetimeScope();
            builder.RegisterType<OrderItemManager>().As<IOrderItemService>().InstancePerLifetimeScope();
            builder.RegisterType<OrderManager>().As<IOrderService>().InstancePerLifetimeScope();
            builder.RegisterType<PaymentManager>().As<IPaymentService>().InstancePerLifetimeScope();
            builder.RegisterType<RestaurantManager>().As<IRestaurantService>().InstancePerLifetimeScope();
            builder.RegisterType<ReviewManager>().As<IReviewService>().InstancePerLifetimeScope();
            builder.RegisterType<UserManager>().As<IUserService>().InstancePerLifetimeScope();

            builder.RegisterType<EfMenuDal>().As<IMenuDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfMenuItemDal>().As<IMenuItemDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfOrderItemDal>().As<IOrderItemDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfPaymentDal>().As<IPaymentDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfRestaurantDal>().As<IRestaurantDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfReviewDal>().As<IReviewDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfUserDal>().As<IUserDal>().InstancePerLifetimeScope();
        }
    }
}
