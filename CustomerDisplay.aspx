<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerDisplay.aspx.cs" Inherits="masterpage.CustomerDisplay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link type="text/css" rel="stylesheet" href="StyleSheet1.css" runat="server" />
    <link href="https://fonts.googleapis.com/css?family=CinzelDecorative" rel="stylesheet" runat="server" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>Chattahoochee Credit Union</h1>
            <a href="AdminLogin.aspx">Admin Login</a>

        </header>
        <nav>
            <ul>
                <li><a href="WebForm1.aspx">Home</a></li>
                <li><a href="#">Investment Banking</a></li>
                <li><a href="#">Personal Loans</a></li>
            </ul>

        </nav>
        <div id="Wrapper">

            <div id="custInfo">
                <asp:Label ID="cName" runat="server" ForeColor="SlateGray" Font-Names="Gabriola" CssClass="custName"></asp:Label>
                <asp:Label ID="cID" runat="server" ForeColor="SlateGray" Font-Names="Gabriola" CssClass="custAdd"></asp:Label>
            </div>
            <asp:GridView runat="server" ID="gridView1" CssClass="dTable" GridLines="None" HeaderStyle-CssClass="tableHd" RowStyle-CssClass="rowTable" CellSpacing="5" AutoGenerateSelectButton="True" OnRowDataBound="gridView1_RowDataBound" OnSelectedIndexChanged="gridView1_SelectedIndexChanged"></asp:GridView>
            <div id="optionsDiv">
                
                <span id="newAcctDiv">
                    <asp:Button ID="newAcctBT" runat="server" OnClick="newAcctBT_Click" Text="New Account" CssClass="newAccBT" />
                </span>
                <span id="depositeDiv">
                    <asp:TextBox ID="depositeTB" runat="server"></asp:TextBox>
                    <asp:Button ID="depositeBT" runat="server" Text="Deposite" CssClass="depositeBT" OnClick="depositeBT_Click" />

                </span>
                <span id="withdrawDiv">
                    <asp:TextBox ID="withdrawTB" runat="server"></asp:TextBox>
                    <asp:Button ID="withdrawBT" runat="server" OnClick="withdrawBT_Click" Text="Withdraw" CssClass="withdrawBT" />
                </span>
                <asp:Label runat="server" ID="test"></asp:Label>
                
            </div>




        </div>
    </form>
</body>
</html>
