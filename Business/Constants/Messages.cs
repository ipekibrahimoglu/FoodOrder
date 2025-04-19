using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        // Restaurant mesajları
        public static string RestaurantAdded = "Restaurant added successfully.";
        public static string RestaurantUpdated = "Restaurant updated successfully.";
        public static string RestaurantDeleted = "Restaurant deleted successfully.";
        public static string RestaurantsListed = "Restaurants listed successfully.";
        public static string RestaurantNotFound = "Restaurant not found.";

        // Order mesajları
        public static string OrderAdded = "Order added successfully.";
        public static string OrderUpdated = "Order updated successfully.";
        public static string OrderDeleted = "Order deleted successfully.";
        public static string OrdersListed = "Orders listed successfully.";
        public static string OrderNotFound = "Order not found.";

        // Menu mesajları
        public static string MenuAdded = "Menu added successfully.";
        public static string MenuUpdated = "Menu updated successfully.";
        public static string MenuDeleted = "Menu deleted successfully.";
        public static string MenusListed = "Menus listed successfully.";
        public static string MenuNotFound = "Menu not found.";

        // MenuItem mesajları
        public static string MenuItemAdded = "Menu item added successfully.";
        public static string MenuItemUpdated = "Menu item updated successfully.";
        public static string MenuItemDeleted = "Menu item deleted successfully.";
        public static string MenuItemsListed = "Menu items listed successfully.";
        public static string MenuItemNotFound = "Menu item not found.";

        // OrderItem mesajları
        public static string OrderItemAdded = "Order item added successfully.";
        public static string OrderItemUpdated = "Order item updated successfully.";
        public static string OrderItemDeleted = "Order item deleted successfully.";
        public static string OrderItemsListed = "Order items listed successfully.";
        public static string OrderItemNotFound = "Order item not found.";

        // Payment mesajları
        public static string PaymentAdded = "Payment added successfully.";
        public static string PaymentUpdated = "Payment updated successfully.";
        public static string PaymentDeleted = "Payment deleted successfully.";
        public static string PaymentsListed = "Payments listed successfully.";
        public static string PaymentNotFound = "Payment not found.";

        // User mesajları
        public static string UserAdded = "User added successfully.";
        public static string UserUpdated = "User updated successfully.";
        public static string UserDeleted = "User deleted successfully.";
        public static string UsersListed = "Users listed successfully.";
        public static string UserNotFound = "User not found.";

        // Review mesajları
        public static string ReviewAdded = "Review added successfully.";
        public static string ReviewUpdated = "Review updated successfully.";
        public static string ReviewDeleted = "Review deleted successfully.";
        public static string ReviewsListed = "Reviews listed successfully.";
        public static string ReviewNotFound = "Review not found.";

        // User
        public const string UserFullNameRequired = "Ad Soyad boş bırakılamaz!";
        public const string UserEmailRequired = "E-posta adresi boş bırakılamaz!";
        public const string UserEmailInvalid = "Geçerli bir e-posta adresi giriniz!";
        public const string UserPasswordRequired = "Şifre alanı boş bırakılamaz!";
        public const string UserRoleRequired = "Kullanıcı rolü belirtilmelidir!";

        // Restaurant
        public const string RestaurantNameRequired = "Restoran adı boş olamaz!";
        public const string RestaurantAddressRequired = "Adres alanı boş olamaz!";

        // Menu
        public const string MenuNameRequired = "Menü adı boş bırakılamaz!";

        // MenuItem
        public const string MenuItemNameRequired = "Ürün adı boş bırakılamaz!";
        public const string MenuItemPricePositive = "Fiyat 0'dan büyük olmalıdır!";
        public const string MenuItemPricePrecision = "Fiyat en fazla 2 ondalık basamak ve toplam 18 basamak içerebilir.";

        // Order
        public const string OrderStatusRequired = "Sipariş durumu boş bırakılamaz!";
        public const string OrderStatusInvalid = "Geçerli bir sipariş durumu giriniz! (Pending, Preparing, Delivered, Cancelled)";

        // OrderItem
        public const string OrderItemQuantityPositive = "Adet 1 veya daha fazla olmalıdır!";
        public const string OrderItemPricePositive = "Ürün fiyatı 0'dan büyük olmalıdır!";
        public const string OrderItemPricePrecision = "Fiyat en fazla 2 ondalık basamak ve toplam 18 basamak içerebilir.";

        // Review
        public const string ReviewRatingRange = "Puanlama '1' ile '5' arasında yapılmalıdır!";

        // Payment
        public const string PaymentAmountPositive = "Ödeme tutarı 0'dan büyük olmalıdır!";
        public const string PaymentPrecision = "Tutar en fazla 2 ondalık basamak ve toplam 18 basamak içerebilir!";
        public const string PaymentMethodRequired = "Ödeme yöntemi boş olamaz!";
    }
}

