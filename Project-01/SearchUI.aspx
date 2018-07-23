<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchUI.aspx.cs" Inherits="Project_01.SearchUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Menu ID="Menu1" runat="server" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" Orientation="Horizontal" StaticSubMenuIndent="10px">
            <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="5px" />
            <DynamicMenuStyle BackColor="#B5C7DE" />
            <DynamicSelectedStyle BackColor="#507CD1" />
            <Items>
                <asp:MenuItem NavigateUrl="~/CatagoryUI.aspx" Text="Catagory" Value="Catagory"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/CompanyUI.aspx" Text="Company" Value="Company"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/ItemSetupUI.aspx" Text="ItemSetup" Value="ItemSetup"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/StockInUI.aspx" Text="Stock In" Value="Stock In"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/StockOutUI.aspx" Text="Stock Out" Value="Stock Out"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/DateSearchUI.aspx" Text="Date Search" Value="Date Search"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/SearchUI.aspx" Text="Search" Value="Search"></asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="5px" />
            <StaticSelectedStyle BackColor="#507CD1" />
        </asp:Menu>



        <asp:Label ID="Label2" runat="server" Text="Company"></asp:Label>
        <asp:DropDownList ID="companyDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br/><br/>
        <asp:Label ID="Label1" runat="server" Text="Category"></asp:Label>
        <asp:DropDownList ID="categoryDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br/><br/>
        <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" style="height: 26px" />
        <br/><br/>
        <asp:GridView ID="searchResultGridView" runat="server"></asp:GridView>

    </div>
    </form>
</body>
</html>
