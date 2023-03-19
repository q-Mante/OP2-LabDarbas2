<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebInterface.aspx.cs" Inherits="LabDarbas2_19.WebInterface" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Parduotuvių analizė</title>
    <link href="Style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="display">
                <div class="container1">
                    <div class="input1">
                        <asp:Button ID="Button1" runat="server" Text="ĮKELTI DUOMENIS" OnClick="Button1_Click" />
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="Failo U19b.txt duomenys: " Visible="False"></asp:Label>
                        <asp:Table ID="Table2" runat="server" Visible="False" BorderColor="Black" BorderStyle="Solid" GridLines="Both" BorderWidth="2px"></asp:Table>
                    </div>
                    <div class="data1">
                        <asp:Label ID="Label1" runat="server" Text="Failo U19a.txt duomenys: " Visible="False"></asp:Label>
                        <asp:Table ID="Table1" runat="server" Visible="False" BorderColor="Black" BorderStyle="Solid" GridLines="Both" BorderWidth="2px"></asp:Table>
                    </div>
                </div>
                <div class="container2">
                    <div class="input2">
                        <asp:Label ID="Label3" runat="server" Text="Įveskite pinigų sumą:" Visible="False"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBox1" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Button ID="Button2" runat="server" Text="IŠANALIZUOTI" OnClick="Button2_Click" Visible="False" />
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="Parduotuvė, kuri turi didžiausią prekių asortimentą: " Visible="False"></asp:Label>
                        <asp:Label ID="Label7" runat="server" BorderStyle="Solid" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="Parduotuvių sąrašas, kurių vertė neviršija nurodytos pinigų sumos: " Visible="False"></asp:Label>
                        <asp:Table ID="Table5" runat="server" Visible="False" BorderColor="Black" BorderStyle="Solid" GridLines="Both" BorderWidth="2px"></asp:Table>
                    </div>
                    <div class="data2">
                        <div class="container3">
                            <asp:Label ID="Label4" runat="server" Text="Perkamiausių prekių sąrašas: " Visible="False"></asp:Label>
                            <asp:Table ID="Table3" runat="server" Visible="False" BorderColor="Black" BorderStyle="Solid" GridLines="Both" BorderWidth="2px"></asp:Table>
                        </div>
                        <div class="container4">
                            <asp:Label ID="Label5" runat="server" Text="Prekių sąrašas, kurių galiojimas netrukus pasibaigs: " Visible="False"></asp:Label>
                            <asp:Table ID="Table4" runat="server" Visible="False" BorderColor="Black" BorderStyle="Solid" GridLines="Both" BorderWidth="2px"></asp:Table>
                        </div>                        
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
