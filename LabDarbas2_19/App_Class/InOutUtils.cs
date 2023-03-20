using System;
using System.IO;

namespace LabDarbas2_19.App_Class
{
    public static class InOutUtils
    {
        private const int CshopsSize = 114;
        private const int CinformationsSize = 72;
        private const int CexpiresSize = 64;
        private const int CshopsCharacteristicsSize = 67;

        public static LinkedInformations ReadInformations(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                LinkedInformations linkedInformations = new LinkedInformations();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] Parts = line.Split(';');

                    string name = Parts[0];
                    int validity = int.Parse(Parts[1]);
                    float price = float.Parse(Parts[2]);

                    Information information = new Information(name, validity, price);

                    linkedInformations.Add(information);
                }
                return linkedInformations;
            }
        }

        public static LinkedShops ReadShops(string fileName, LinkedInformations linkedInformations)
        {
            using (var reader = new StreamReader(fileName))
            {
                LinkedShops linkedShops = new LinkedShops();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] Parts = line.Split(';');

                    string shopName = Parts[0];
                    string productName = Parts[1];
                    DateTime arrived = DateTime.Parse(Parts[2]);
                    int sold = int.Parse(Parts[3]);
                    int stock = int.Parse(Parts[4]);

                    Information requiredInfo = new Information(productName);
                    if (linkedInformations.Contains(requiredInfo))
                    {
                        requiredInfo = linkedInformations.Find(requiredInfo);
                    }

                    Product product = new Product(productName, arrived, sold, stock, requiredInfo);

                    Shop requiredShop = new Shop(shopName);
                    if (linkedShops.Contains(requiredShop))
                    {
                        linkedShops.Find(requiredShop).ProductsAdd(product);
                    }
                    else
                    {
                        requiredShop.ProductsAdd(product);
                        linkedShops.Add(requiredShop);
                    }
                }
                return linkedShops;
            }
        }

        public static void WriteShops(string fileName, string header, LinkedShops linkedShops)
        {
            using (var writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(new string('-', CshopsSize));
                writer.WriteLine(string.Format("| {0,-110} |", header));
                writer.WriteLine(new string('-', CshopsSize));
                writer.WriteLine(string.Format("| {0,-40} | {1,-30} | {2,-13} | {3,-8} | {4,-7} |", "Parduotuvės pavadinimas", "Prekės pavadinimas", "Atvykimo data", "Parduota", "Likutis"));
                writer.WriteLine(new string('-', CshopsSize));
                for (linkedShops.Begin(); linkedShops.Exists(); linkedShops.Next())
                {
                    Shop shop = linkedShops.Get();
                    for (shop.ProductsBegin(); shop.ProductsExists(); shop.ProductsNext())
                    {
                        writer.WriteLine(string.Format("| {0,-40} {1}", shop.Name, shop.ProductsGet()));
                    }
                }
                writer.WriteLine(new string('-', CshopsSize));
                writer.WriteLine();
            }
        }

        public static void WriteInformations(string fileName, string header, LinkedInformations linkedInformations)
        {
            using (var writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(new string('-', CinformationsSize));
                writer.WriteLine(string.Format("| {0,-68} |", header));
                writer.WriteLine(new string('-', CinformationsSize));
                writer.WriteLine(string.Format("| {0,-30} | {1,-25} | {2,-7} |", "Prekės pavadinimas", "Galiojimo laikotarpis (d)", "Kaina \u20AC"));
                writer.WriteLine(new string('-', CinformationsSize));
                for (linkedInformations.Begin(); linkedInformations.Exists(); linkedInformations.Next())
                {
                    Information information = linkedInformations.Get();
                    writer.WriteLine(information);
                }
                writer.WriteLine(new string('-', CinformationsSize));
                writer.WriteLine();
            }
        }

        public static void WriteExpires(string fileName, string header, LinkedProducts linkedProducts)
        {
            using (var writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(new string('-', CexpiresSize));
                writer.WriteLine(string.Format("| {0,-60} |", header));
                writer.WriteLine(new string('-', CexpiresSize));
                writer.WriteLine(string.Format("| {0,-30} | {1,-17} | {2,-7} |", "Prekės pavadinimas", "Galiojimo pabaiga", "Kaina \u20AC"));
                writer.WriteLine(new string('-', CexpiresSize));
                for (linkedProducts.Begin(); linkedProducts.Exists(); linkedProducts.Next())
                {
                    Product product = linkedProducts.Get();
                    writer.WriteLine(product.ToStringExpire());
                }
                writer.WriteLine(new string('-', CexpiresSize));
                writer.WriteLine();
            }
        }

        public static void WriteShopsCharacteristics(string fileName, string header, LinkedShops linkedShops)
        {
            using (var writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(new string('-', CshopsCharacteristicsSize));
                writer.WriteLine(string.Format("| {0,-63} |", header));
                writer.WriteLine(new string('-', CshopsCharacteristicsSize));
                writer.WriteLine(string.Format("| {0,-40} | {1,-7} | {2,-10} |", "Parduotuvės pavadinimas", "Likutis", "Vertė"));
                writer.WriteLine(new string('-', CshopsCharacteristicsSize));
                for (linkedShops.Begin(); linkedShops.Exists(); linkedShops.Next())
                {
                    Shop shop = linkedShops.Get();
                    writer.WriteLine(shop);
                }
                writer.WriteLine(new string('-', CshopsCharacteristicsSize));
                writer.WriteLine();
            }
        }
    }
}