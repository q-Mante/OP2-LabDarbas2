using System.Collections.Generic;

namespace LabDarbas2_19.App_Class
{
    public class Information
    {
        public string Name { get; private set; }
        public int Validity { get; private set; }
        public float Price { get; private set; }

        public Information(string name, int validity = -1, float price = -1f)
        {
            Name = name;
            Validity = validity;
            Price = price;
        }

        public int CompareTo(Information information)
        {
            if (Name.CompareTo(information.Name).Equals(0))
            {
                return Price.CompareTo(information.Price);
            }
            return Name.CompareTo(information.Name);
        }

        public override string ToString()
        {
            return string.Format("| {0,-30} | {1,25} | {2,7} |", Name, Validity, Price);
        }

        public override bool Equals(object obj)
        {
            return obj is Information information && Name.Equals(information.Name);
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}