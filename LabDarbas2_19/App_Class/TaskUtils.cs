using System;

namespace LabDarbas2_19.App_Class
{
    /// <summary>
    /// Class which holds tools for manipulating/calculating data
    /// </summary>
    public static class TaskUtils
    {
        /// <summary>
        /// Finds favorite products from each shop and stores them in LinkedList
        /// </summary>
        /// <param name="linkedShops">Storage</param>
        /// <returns>Returns LinkedList of favorite products</returns>
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

        /// <summary>
        /// Finds products which are going to expire in [days] days and stores them in LinkedList
        /// </summary>
        /// <param name="linkedShops">Storage</param>
        /// <param name="days">Interval in which product will expire</param>
        /// <returns>Returns LinkedList of products</returns>
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

        /// <summary>
        /// Finds shop which has the most amount of diverse products
        /// </summary>
        /// <param name="linkedShops">LinkedList of shops which are checked</param>
        /// <returns>Shop with most amount of diverse products</returns>
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

        /// <summary>
        /// Finds shops which values are below specified value
        /// </summary>
        /// <param name="linkedShops">LinkedList of shops which are checked</param>
        /// <param name="maximumValue">Specified value</param>
        /// <returns></returns>
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