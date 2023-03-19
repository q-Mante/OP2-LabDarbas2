using LabDarbas2_19.App_Class;
using System.Web.UI.WebControls;

namespace LabDarbas2_19
{
    public partial class WebInterface : System.Web.UI.Page
    {
        protected void AddTableHeaderRow(Table table, params string[] cellsHeaders)
        {
            TableHeaderRow hRow = new TableHeaderRow();
            for (int i = 0; i < cellsHeaders.Length; i++)
            {
                TableHeaderCell hCell = new TableHeaderCell { Text = cellsHeaders[i] };
                hRow.Cells.Add(hCell);
            }
            table.Rows.Add(hRow);
        }

        protected void AddTableRow(Table table, params string[] cells)
        {
            TableHeaderRow row = new TableHeaderRow();
            for (int i = 0; i < cells.Length; i++)
            {
                TableCell cell = new TableCell { Text = cells[i] };
                row.Cells.Add(cell);
            }
            table.Rows.Add(row);
        }

        protected void SessionSaveVisible()
        {
            Session["Label1.V"] = Label1.Visible;
            Session["Label2.V"] = Label2.Visible;
            Session["Label3.V"] = Label3.Visible;
            Session["Table1.V"] = Table1.Visible;
            Session["Table2.V"] = Table2.Visible;
            Session["TextBox1.V"] = TextBox1.Visible;
            Session["Button2.V"] = Button2.Visible;
            Session["Label4.V"] = Label4.Visible;
            Session["Label5.V"] = Label5.Visible;
            Session["Label6.V"] = Label6.Visible;
            Session["Label7.V"] = Label7.Visible;
            Session["Label8.V"] = Label8.Visible;
            Session["Table3.V"] = Table3.Visible;
            Session["Table4.V"] = Table4.Visible;
            Session["Table5.V"] = Table5.Visible;
        }

        protected void SessionSave1(LinkedShops shops, LinkedInformations informations)
        {
            Session["Table1"] = shops;
            Session["Table2"] = informations;
        }

        protected void SessionSave2(LinkedInformations favorites, LinkedProducts expires, Shop biggest, LinkedShops shops)
        {
            Session["Table3"] = favorites;
            Session["Table4"] = expires;
            Session["Label7"] = biggest;
            Session["Table5"] = shops;
        }

        protected void SessionLoad()
        {
            if (Session["Table1"] != null)
            {
                LinkedShops sessionTable1 = (LinkedShops)Session["Table1"];

                Table1.Rows.Clear();
                if (sessionTable1.Count != 0)
                {
                    AddTableHeaderRow(Table1, "Parduotuvės pavadinimas", "Prekės pavadinimas", "Atvykimo data", "Parduota", "Likutis");
                    for (sessionTable1.Begin(); sessionTable1.Exists(); sessionTable1.Next())
                    {
                        Shop shop = sessionTable1.Get();
                        for (shop.ProductsBegin(); shop.ProductsExists(); shop.ProductsNext())
                        {
                            Product product = shop.ProductsGet();
                            AddTableRow(Table1, shop.Name, product.Name, product.Arrived.ToString("yyyy-MM-dd"), product.Sold.ToString(), product.Stock.ToString());
                        }
                    }
                }
                else
                {
                    AddTableHeaderRow(Table1, "Sąrašo nėra");
                }
                Table1.Visible = (bool)Session["Table1.V"];
            }

            if (Session["Table2"] != null)
            {
                LinkedInformations sessionTable2 = (LinkedInformations)Session["Table2"];

                Table2.Rows.Clear();
                if (sessionTable2.Count != 0)
                {
                    AddTableHeaderRow(Table2, "Prekės pavadinimas", "Galiojimo laikotarpis (d)", "Kaina \u20AC");
                    for (sessionTable2.Begin(); sessionTable2.Exists(); sessionTable2.Next())
                    {
                        Information information = sessionTable2.Get();
                        AddTableRow(Table2, information.Name, information.Validity.ToString(), information.Price.ToString());
                    }
                }
                else
                {
                    AddTableHeaderRow(Table2, "Sąrašo nėra");
                }
                Table2.Visible = (bool)Session["Table2.V"];
            }

            if (Session["Table3"] != null)
            {
                LinkedInformations sessionTable3 = (LinkedInformations)Session["Table3"];

                Table3.Rows.Clear();
                if (sessionTable3.Count != 0)
                {
                    AddTableHeaderRow(Table3, "Prekės pavadinimas", "Galiojimo laikotarpis (d)", "Kaina \u20AC");
                    for (sessionTable3.Begin(); sessionTable3.Exists(); sessionTable3.Next())
                    {
                        Information information = sessionTable3.Get();
                        AddTableRow(Table3, information.Name, information.Validity.ToString(), information.Price.ToString());
                    }
                }
                else
                {
                    AddTableHeaderRow(Table3, "Sąrašo nėra");
                }
                Table3.Visible = (bool)Session["Table3.V"];
            }

            if (Session["Table4"] != null)
            {
                LinkedProducts sessionTable4 = (LinkedProducts)Session["Table4"];

                Table4.Rows.Clear();
                if (sessionTable4.Count != 0)
                {
                    AddTableHeaderRow(Table4, "Prekės pavadinimas", "Galiojimo pabaiga", "Kaina \u20AC");
                    for (sessionTable4.Begin(); sessionTable4.Exists(); sessionTable4.Next())
                    {
                        Product product = sessionTable4.Get();
                        AddTableRow(Table4, product.Name, product.Expire.ToString("yyyy-MM-dd"), product.Info.Price.ToString());
                    }
                }
                else
                {
                    AddTableHeaderRow(Table4, "Sąrašo nėra");
                }
                Table4.Visible = (bool)Session["Table4.V"];
            }

            if (Session["Label7"] != null)
            {
                Shop shop = (Shop)Session["Label7"];

                if (shop.Name != null)
                {
                    Label7.Text = shop.Name;
                }
                else
                {
                    Label7.Text = "nėra";
                }
                Label7.Visible = (bool)Session["Label7.V"];
            }

            if (Session["Table5"] != null)
            {
                LinkedShops sessionTable5 = (LinkedShops)Session["Table5"];

                Table5.Rows.Clear();
                if (sessionTable5.Count != 0)
                {
                    // Populating Table5 and showing results at WebInterface
                    AddTableHeaderRow(Table5, "Parduotuvės pavadinimas", "Likutis", "Vertė \u20AC");
                    for (sessionTable5.Begin(); sessionTable5.Exists(); sessionTable5.Next())
                    {
                        Shop shop = sessionTable5.Get();
                        AddTableRow(Table5, shop.Name, shop.AllStock.ToString(), shop.Value.ToString());
                    }
                }
                else
                {
                    AddTableHeaderRow(Table5, "Sąrašo nėra");
                }
                Table5.Visible = (bool)Session["Table5.V"];
            }

            if (Session["Label1.V"] != null)
                Label1.Visible = (bool)Session["Label1.V"];
            if (Session["Label2.V"] != null)
                Label2.Visible = (bool)Session["Label2.V"];
            if (Session["Label3.V"] != null)
                Label3.Visible = (bool)Session["Label3.V"];
            if (Session["TextBox1.V"] != null)
                TextBox1.Visible = (bool)Session["TextBox1.V"];
            if (Session["Button2.V"] != null)
                Button2.Visible = (bool)Session["Button2.V"];
            if (Session["Label4.V"] != null)
                Label4.Visible = (bool)Session["Label4.V"];
            if (Session["Label5.V"] != null)
                Label5.Visible = (bool)Session["Label5.V"];
            if (Session["Label6.V"] != null)
                Label6.Visible = (bool)Session["Label6.V"];
            if (Session["Label8.V"] != null)
                Label8.Visible = (bool)Session["Label8.V"];
        }
    }
}