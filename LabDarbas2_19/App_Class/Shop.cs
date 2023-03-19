using System;
using System.Collections.Generic;

namespace LabDarbas2_19.App_Class
{
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

        public Shop() { }

        public Shop(string name)
        {
            Name = name;
            AllProducts = new LinkedProducts();
        }

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

        public int ProductsCount() => AllProducts.Count;

        public void ProductsAdd(Product product) => AllProducts.Add(product);

        public void ProductsBegin() => AllProducts.Begin();

        public bool ProductsExists() => AllProducts.Exists();

        public void ProductsNext() => AllProducts.Next();

        public Product ProductsGet() => AllProducts.Get();

        public override string ToString()
        {
            return string.Format("| {0,-40} | {1,7} | {2,10} |", Name, AllStock, Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Shop shop && Name.Equals(shop.Name);
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}