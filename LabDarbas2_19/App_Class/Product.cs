using System;
using System.Collections.Generic;

namespace LabDarbas2_19.App_Class
{
    /// <summary>
    /// Class which holds information about existing product in the shop
    /// </summary>
    public class Product
    {
        public string Name { get; private set; }
        public DateTime Arrived { get; private set; }
        public int Sold { get; private set; }
        public int Stock { get; private set; }
        public Information Info { get; private set; }

        public DateTime Expire
        {
            get
            {
                if (Info.Validity == -1)
                    return DateTime.MinValue;
                return Arrived.AddDays(Info.Validity);
            }
        }

        public float TotalPrice
        {
            get
            {
                if (Info.Price == -1f)
                    return -1f;
                return Stock * Info.Price;
            }
        }

        /// <summary>
        /// Constructor for Information class object which is null
        /// </summary>
        public Product() { }

        /// <summary>
        /// Constructor for Information class object
        /// </summary>
        /// <param name="name">Initial name of product</param>
        /// <param name="arrived">Date when it arrived to shop</param>
        /// <param name="sold">Amount that has been sold</param>
        /// <param name="stock">Amount that are still in stock</param>
        /// <param name="info">Key information about individual product</param>
        public Product(string name, DateTime arrived, int sold, int stock, Information info)
        {
            Name = name;
            Arrived = arrived;
            Sold = sold;
            Stock = stock;
            Info = info;
        }

        /// <summary>
        /// Compares to given Product class object: firtly by name, secondly by price
        /// </summary>
        /// <param name="product">Object to which compare to</param>
        /// <returns>Integer, indicating the position of object relative to given object</returns>
        public int CompareTo(Product product)
        {
            if (Name.CompareTo(product.Name).Equals(0))
            {
                return Info.Price.CompareTo(product.Info.Price);
            }
            return Name.CompareTo(product.Name);
        }

        /// <summary>
        /// String representation of Product class object with expiring date
        /// </summary>
        /// <returns></returns>
        public string ToStringExpire()
        {
            return string.Format("| {0,-30} | {1,17} | {2,7} |", Name, Expire.ToString("yyyy-MM-dd"), Info.Price);
        }

        /// <summary>
        /// String representation of Product class object
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return string.Format("| {0,-30} | {1,13} | {2,8} | {3,7} |", Name, Arrived.ToString("yyyy-MM-dd"), Sold, Stock);
        }

        /// <summary>
        /// Checks if given Product class object is the same as original
        /// </summary>
        /// <param name="obj">Object to which compare to</param>
        /// <returns>True, if they are the same; otherwise false</returns>
        public override bool Equals(object obj)
        {
            return obj is Product product && Name.Equals(product.Name) && Arrived.Equals(product.Arrived);
        }

        /// <summary>
        /// Calculates HashCode of the Product class object
        /// </summary>
        /// <returns>Integer</returns>
        public override int GetHashCode()
        {
            int hashCode = 1278469092;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Arrived.GetHashCode();
            return hashCode;
        }
    }
}