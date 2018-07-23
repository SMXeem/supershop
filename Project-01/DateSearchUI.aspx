<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DateSearchUI.aspx.cs" Inherits="Project_01.DateSearchUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
      $(function () {
          $("#toDate").datepicker();
          $("#fromDate").datepicker();
      });
  </script>
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



        <asp:Label ID="Label1" runat="server" Text="From Date"></asp:Label>
        <asp:TextBox runat="server" ID="fromDate"></asp:TextBox>
        <br/><br/>
        <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label>
        <asp:TextBox runat="server" ID="toDate"></asp:TextBox>
        <br/><br/>
        <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
        <br/><br/>
        <asp:GridView ID="searchResultsGridView" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
