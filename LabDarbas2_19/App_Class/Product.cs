using System;
using System.Collections.Generic;

namespace LabDarbas2_19.App_Class
{
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

        public Product() { }

        public Product(string name, DateTime arrived, int sold, int stock, Information info)
        {
            Name = name;
            Arrived = arrived;
            Sold = sold;
            Stock = stock;
            Info = info;
        }

        public int CompareTo(Product product)
        {
            if (Name.CompareTo(product.Name).Equals(0))
            {
                return Info.Price.CompareTo(product.Info.Price);
            }
            return Name.CompareTo(product.Name);
        }

        public string ToStringExpire()
        {
            return string.Format("| {0,-30} | {1,17} | {2,7} |", Name, Expire.ToString("yyyy-MM-dd"), Info.Price);
        }

        public override string ToString()
        {
            return string.Format("| {0,-30} | {1,13} | {2,8} | {3,7} |", Name, Arrived.ToString("yyyy-MM-dd"), Sold, Stock);
        }

        public override bool Equals(object obj)
        {
            return obj is Product product && Name.Equals(product.Name) && Arrived.Equals(product.Arrived);
        }

        public override int GetHashCode()
        {
            int hashCode = 1278469092;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Arrived.GetHashCode();
            return hashCode;
        }
    }
}