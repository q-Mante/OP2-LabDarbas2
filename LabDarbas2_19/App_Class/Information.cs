using System.Collections.Generic;

namespace LabDarbas2_19.App_Class
{
    /// <summary>
    /// Class which holds key information about individual products
    /// </summary>
    public class Information
    {
        public string Name { get; private set; }
        public int Validity { get; private set; }
        public float Price { get; private set; }

        /// <summary>
        /// Constructor for Information class object
        /// </summary>
        /// <param name="name">Initial name of product</param>
        /// <param name="validity">Amount of days product is valid for consumption</param>
        /// <param name="price">Price per unit</param>
        public Information(string name, int validity = -1, float price = -1f)
        {
            Name = name;
            Validity = validity;
            Price = price;
        }

        /// <summary>
        /// Compares to given Information class object: firtly by name, secondly by price
        /// </summary>
        /// <param name="information">Object to which compare to</param>
        /// <returns>Integer, indicating the position of object relative to given object</returns>
        public int CompareTo(Information information)
        {
            if (Name.CompareTo(information.Name).Equals(0))
            {
                return Price.CompareTo(information.Price);
            }
            return Name.CompareTo(information.Name);
        }

        /// <summary>
        /// String representation of Information class object
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return string.Format("| {0,-30} | {1,25} | {2,7} |", Name, Validity, Price);
        }

        /// <summary>
        /// Checks if given Information class object is the same as original
        /// </summary>
        /// <param name="obj">Object to which compare to</param>
        /// <returns>True, if they are the same; otherwise false</returns>
        public override bool Equals(object obj)
        {
            return obj is Information information && Name.Equals(information.Name);
        }

        /// <summary>
        /// Calculates HashCode of the Information class object
        /// </summary>
        /// <returns>Integer</returns>
        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}