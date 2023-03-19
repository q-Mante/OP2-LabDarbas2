using LabDarbas2_19.App_Class;
using System;
using System.IO;

namespace LabDarbas2_19
{
    public partial class WebInterface : System.Web.UI.Page
    {
        // Constants
        private const string CFd1 = "U19a.txt";
        private const string CFd2 = "U19b.txt";
        private const string CFr = "Results.txt";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Loading user session data
            SessionLoad();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Initializing variables
            string DataFilePath1 = Server.MapPath("App_Data\\" + CFd1);
            string DataFilePath2 = Server.MapPath("App_Data\\" + CFd2);
            string ResultFilePath = Server.MapPath("App_Data\\" + CFr);

            // Ensuring Tables integrity
            Table1.Rows.Clear();
            Table2.Rows.Clear();

            // Deleting existing results
            if (File.Exists(ResultFilePath))
                File.Delete(ResultFilePath);

            // Reading, processing and storing data from source files
            LinkedInformations AllInformations = InOutUtils.ReadInformations(DataFilePath2);
            LinkedShops AllShops = InOutUtils.ReadShops(DataFilePath1, AllInformations);

            if (AllShops.Count != 0)
            {
                // Populating Table1 and showing results at WebInterface
                AddTableHeaderRow(Table1, "Parduotuvės pavadinimas", "Prekės pavadinimas", "Atvykimo data", "Parduota", "Likutis");
                for (AllShops.Begin(); AllShops.Exists(); AllShops.Next())
                {
                    Shop shop = AllShops.Get();
                    for (shop.ProductsBegin(); shop.ProductsExists(); shop.ProductsNext())
                    {
                        Product product = shop.ProductsGet();
                        AddTableRow(Table1, shop.Name, product.Name, product.Arrived.ToString("yyyy-MM-dd"), product.Sold.ToString(), product.Stock.ToString());
                    }
                }

                // Writting results to file
                InOutUtils.WriteShops(ResultFilePath, "Duomenys: " + "\"" + CFd1 + "\"", AllShops);
            }
            else
            {
                // Showing results at WebInterface
                AddTableHeaderRow(Table1, "Sąrašo nėra");

                // Writting results to file
                File.AppendAllText(ResultFilePath, "Duomenų nėra.\n\n");
            }
            
            if (AllInformations.Count != 0)
            {
                // Populating Table2 and showing results at WebInterface
                AddTableHeaderRow(Table2, "Prekės pavadinimas", "Galiojimo laikotarpis (d)", "Kaina \u20AC");
                for (AllInformations.Begin(); AllInformations.Exists(); AllInformations.Next())
                {
                    Information information = AllInformations.Get();
                    AddTableRow(Table2, information.Name, information.Validity.ToString(), information.Price.ToString());
                }

                // Writting results to file
                InOutUtils.WriteInformations(ResultFilePath, "Duomenys: " + "\"" + CFd2 + "\"", AllInformations);
            }
            else
            {
                // Showing results at WebInterface
                AddTableHeaderRow(Table2, "Sąrašo nėra");

                // Writting results to file
                File.AppendAllText(ResultFilePath, "Duomenų nėra.\n\n");
            }
            
            // Ensuring visible content at WebInterface
            Label1.Visible = true;
            Table1.Visible = true;
            Label2.Visible = true;
            Table2.Visible = true;
            Label3.Visible = true;
            TextBox1.Visible = true;
            Button2.Visible = true;
            Label4.Visible = false;
            Table3.Visible = false;
            Label5.Visible = false;
            Table4.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            Table5.Visible = false;

            // Saving required data in user session
            SessionSave1(AllShops, AllInformations);
            SessionSaveVisible();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Initializing variables
            float MaximumValue = float.Parse(TextBox1.Text);
            string ResultFilePath = Server.MapPath("App_Data\\" + CFr);
            LinkedShops AllShops = (LinkedShops)Session["Table1"];

            // Ensuring Tables integrity
            Table3.Rows.Clear();
            Table4.Rows.Clear();
            Table5.Rows.Clear();

            // Finding favorite products at each shop
            LinkedInformations Favorites = TaskUtils.FindFavorites(AllShops);
            Favorites.Sort();

            // Finding products which will expire in the next 30 days at each shop
            LinkedProducts Expires = TaskUtils.FindProductsThatExpireIn(AllShops, 30);
            Expires.Sort();

            // Finding shop which has most variety of products
            Shop Biggest = TaskUtils.FindShopWithBiggestAssortment(AllShops);

            // Finding shops which values are below specified value
            LinkedShops Shops = TaskUtils.FindShopsThatAreBelowSpecifiedValue(AllShops, MaximumValue);

            File.AppendAllText(ResultFilePath, string.Format("Pinigų suma: {0}\n\n", MaximumValue));

            if (Favorites.Count != 0)
            {
                // Populating Table3 and showing results at WebInterface
                AddTableHeaderRow(Table3, "Prekės pavadinimas", "Galiojimo laikotarpis (d)", "Kaina \u20AC");
                for (Favorites.Begin(); Favorites.Exists(); Favorites.Next())
                {
                    Information information = Favorites.Get();
                    AddTableRow(Table3, information.Name, information.Validity.ToString(), information.Price.ToString());
                }

                // Writting results to file
                InOutUtils.WriteInformations(ResultFilePath, "Rezultatai: Perkamiausių prekių sąrašas", Favorites);
            }
            else
            {
                // Showing results at WebInterface
                AddTableHeaderRow(Table3, "Sąrašo nėra");

                // Writting results to file
                File.AppendAllText(ResultFilePath, "Perkamiausių prekių sąraše nėra.\n\n");
            }

            if (Expires.Count != 0)
            {
                // Populating Table4 and showing results at WebInterface
                AddTableHeaderRow(Table4, "Prekės pavadinimas", "Galiojimo pabaiga", "Kaina \u20AC");
                for (Expires.Begin(); Expires.Exists(); Expires.Next())
                {
                    Product product = Expires.Get();
                    AddTableRow(Table4, product.Name, product.Expire.ToString("yyyy-MM-dd"), product.Info.Price.ToString());
                }

                // Writting results to file
                InOutUtils.WriteExpires(ResultFilePath, "Rezultatai: Baigiantis galioti prekių sąrašas", Expires);
            }
            else
            {
                // Showing results at WebInterface
                AddTableHeaderRow(Table4, "Sąrašo nėra");

                // Writting results to file
                File.AppendAllText(ResultFilePath, "Nėra prekių, kurių galiojimo laikotarpis pasibaigs.\n\n");
            }

            if (Biggest.Name != null)
            {
                // Setting Label7 text value and showing results at WebInterface
                Label7.Text = Biggest.Name;

                // Writting results to file
                File.AppendAllText(ResultFilePath, string.Format("Parduotuvė, kuri turi didžiausią prekių asortimentą: {0}.\n\n", Biggest.Name));
            }
            else
            {
                // Showing results at WebInterface
                Label7.Text = "nėra";

                // Writting results to file
                File.AppendAllText(ResultFilePath, "Nėra parduotuvės su didžiausiu prekių asortimentu.\n\n");
            }

            if (Shops.Count != 0)
            {
                // Populating Table5 and showing results at WebInterface
                AddTableHeaderRow(Table5, "Parduotuvės pavadinimas", "Likutis", "Vertė \u20AC");
                for (Shops.Begin(); Shops.Exists(); Shops.Next())
                {
                    Shop shop = Shops.Get();
                    AddTableRow(Table5, shop.Name, shop.AllStock.ToString(), shop.Value.ToString());
                }

                // Writting results to file
                InOutUtils.WriteShopsCharacteristics(ResultFilePath, "Rezultatai: Biudžeto parduotuvių sąrašas", Shops);
            }
            else
            {
                // Showing results at WebInterface
                AddTableHeaderRow(Table5, "Sąrašo nėra");

                // Writting results to file
                File.AppendAllText(ResultFilePath, string.Format("Nėra parduotuvių, kurių vertė neviršija {0} \u20AC\n\n", MaximumValue));
            }

            // Ensuring visible content at WebInterface
            Label4.Visible = true;
            Table3.Visible = true;
            Label5.Visible = true;
            Table4.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Table5.Visible = true;

            // Saving required data in user session
            SessionSave2(Favorites, Expires, Biggest, Shops);
            SessionSaveVisible();
        }
    }
}