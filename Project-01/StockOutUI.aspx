<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="Project_01.StockOutUI" %>

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
        <asp:DropDownList ID="companyDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged"></asp:DropDownList>
        <br/><br/>
        <asp:Label ID="Label1" runat="server" Text="Item"></asp:Label>
        <asp:DropDownList ID="itemDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged"></asp:DropDownList>
        <br/><br/>
        <asp:Label ID="Label3" runat="server" Text="Reorder Level"></asp:Label>
        <asp:TextBox ID="reorderTextBox" runat="server" ReadOnly="True"></asp:TextBox> <asp:Label ID="ReorderAlertLebel" ForeColor="RED" runat="server" Text=""></asp:Label>
        <br/><br/>
        <asp:Label ID="Label4" runat="server" Text="Available Quantity"></asp:Label>
        <asp:TextBox ID="availableQTextBox" runat="server" ReadOnly="True"></asp:TextBox>
        <br/><br/>
        <asp:Label ID="Label5" runat="server" Text="Stock Out Quantity"></asp:Label>
        <asp:TextBox ID="stockOutQTextBox" runat="server" OnTextChanged="stockOutQTextBox_TextChanged"></asp:TextBox>
        <br/><br/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" Height="23px" Width="67px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="textLabel" runat="server" Text=""></asp:Label>
         <br/><br/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="StockOutGridView" runat="server"></asp:GridView>
        <br/><br/>
            &nbsp;&nbsp;
        <asp:Button ID="sellButton" runat="server" Text="Sell" OnClick="sellButton_Click" Height="25px" Width="70px" />
            &nbsp;&nbsp;
        <asp:Button ID="damageButton" runat="server" Text="Damage" OnClick="damageButton_Click" Height="25px" Width="70px" />
            &nbsp;&nbsp;
        <asp:Button ID="lostButton" runat="server" Text="Lost" OnClick="lostButton_Click" Height="25px" Width="70px" />
    </div>
    </form>
</body>
</html>
