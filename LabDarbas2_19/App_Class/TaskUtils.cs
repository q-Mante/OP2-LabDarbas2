using System;

namespace LabDarbas2_19.App_Class
{
    public class TaskUtils
    {
        public static LinkedInformations FindFavorites(LinkedShops linkedShops)
        {
            LinkedInformations Favorites = new LinkedInformations();
            for (linkedShops.Begin(); linkedShops.Exists(); linkedShops.Next())
            {
                Information favorite = linkedShops.Get().FavoriteProduct().Info;
                if (!Favorites.Contains(favorite))
                    Favorites.Add(favorite);
            }
            return Favorites;
        }

        public static LinkedProducts FindProductsThatExpireIn(LinkedShops linkedShops, int days)
        {
            LinkedProducts Expires = new LinkedProducts();
            for (linkedShops.Begin(); linkedShops.Exists(); linkedShops.Next())
            {
                Shop shop = linkedShops.Get();
                for (shop.ProductsBegin(); shop.ProductsExists(); shop.ProductsNext())
                {
                    Product product = shop.ProductsGet();
                    if (product.Expire >= DateTime.Now && product.Expire <= DateTime.Now.AddDays(days))
                        Expires.Add(product);
                }
            }
            return Expires;
        }

        public static Shop FindShopWithBiggestAssortment(LinkedShops linkedShops)
        {
            Shop Biggest = new Shop();
            int count = -1;
            for (linkedShops.Begin(); linkedShops.Exists(); linkedShops.Next())
            {
                Shop shop = linkedShops.Get();
                if (shop.ProductsCount() > count)
                {
                    Biggest = shop;
                    count = shop.ProductsCount();
                }
            }
            return Biggest;
        }

        public static LinkedShops FindShopsThatAreBelowSpecifiedValue(LinkedShops linkedShops, float maximumValue)
        {
            LinkedShops Shops = new LinkedShops();
            for (linkedShops.Begin(); linkedShops.Exists(); linkedShops.Next())
            {
                Shop shop = linkedShops.Get();
                if (shop.Value <= maximumValue && shop.Value != -1f)
                {
                    Shops.Add(shop);
                }
            }
            return Shops;
        }
    }
}