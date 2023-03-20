using System;
using System.Collections.Generic;

namespace LabDarbas2_19.App_Class
{
    /// <summary>
    /// Class which holds information about shops
    /// </summary>
    public class Shop
    {
        public string Name { get; private set; }

        public int AllStock
        {
            get
            {
                int sum = 0;
                for (AllProducts.Begin(); AllProducts.Exists(); AllProducts.Next())
                {
                    sum += AllProducts.Get().Stock;
                }
                return sum;
            }
        }

        public float Value
        {
            get
            {
                float sum = 0;
                for (AllProducts.Begin(); AllProducts.Exists(); AllProducts.Next())
                {
                    if (AllProducts.Get().TotalPrice == -1f)
                        return -1f;
                    sum += AllProducts.Get().TotalPrice;
                }
                return sum;
            }
        }

        private LinkedProducts AllProducts;

        /// <summary>
        /// Constructor for Shop class object which is null
        /// </summary>
        public Shop() { }

        /// <summary>
        /// Constructor for Shop class object
        /// </summary>
        /// <param name="name">Initial name of shop</param>
        public Shop(string name)
        {
            Name = name;
            AllProducts = new LinkedProducts();
        }

        /// <summary>
        /// Find favorite product among all shop products
        /// </summary>
        /// <returns>Favorite product</returns>
        public Product FavoriteProduct()
        {
            Product favorite = new Product();
            float ratio = -1f;
            for (AllProducts.Begin(); AllProducts.Exists(); AllProducts.Next())
            {
                Product selected = AllProducts.Get();
                float selectedRatio = selected.Sold / (DateTime.Now - selected.Arrived).Days;
                if (selectedRatio > ratio)
                {
                    favorite = selected;
                    ratio = selectedRatio;
                }
            }
            return favorite;
        }

        /// <summary>
        /// Count of shop products
        /// </summary>
        /// <returns>Integer</returns>
        public int ProductsCount() => AllProducts.Count;

        /// <summary>
        /// Adds new product to shop
        /// </summary>
        /// <param name="product">Product class object</param>
        public void ProductsAdd(Product product) => AllProducts.Add(product);

        /// <summary>
        /// Sets LinkedProducts list selected node to head
        /// </summary>
        public void ProductsBegin() => AllProducts.Begin();

        /// <summary>
        /// Checks if selected node exists
        /// </summary>
        /// <returns>True, if exists; otherwise false</returns>
        public bool ProductsExists() => AllProducts.Exists();

        /// <summary>
        /// Sets LinkedProducts list selected node to selected adresss
        /// </summary>
        public void ProductsNext() => AllProducts.Next();

        /// <summary>
        /// Returns selected node value
        /// </summary>
        /// <returns>Product</returns>
        public Product ProductsGet() => AllProducts.Get();

        /// <summary>
        /// String representation of Shpp class object
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return string.Format("| {0,-40} | {1,7} | {2,10} |", Name, AllStock, Value);
        }

        /// <summary>
        /// Checks if given Shop class object is the same as original
        /// </summary>
        /// <param name="obj">Object to which compare to</param>
        /// <returns>True, if they are the same; otherwise false</returns>
        public override bool Equals(object obj)
        {
            return obj is Shop shop && Name.Equals(shop.Name);
        }

        /// <summary>
        /// Calculates HashCode of the Shop class object
        /// </summary>
        /// <returns>Integer</returns>
        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}