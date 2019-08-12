<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="masterpage.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link type="text/css" rel="stylesheet" href="StyleSheet1.css" />
    <title></title>
    
</head>
<body runat="server">
    <form id="form1" runat="server">
        
        <header >
            <h1 id="header" runat="server">Chattahoochee Credit Union</h1>
            <a href="AdminLogin.aspx">Admin Login</a>


        </header>
        <nav>
            <ul>
                <li><a href="WebForm1.aspx">Home</a></li>
                <li><a href="#">Investment Banking</a></li>
                <li><a href="#">Personal Loans</a></li>
            </ul>

        </nav>
        <aside>
            
            <label id="uname" for="uname"><b>Member Name:</b></label>
            <asp:TextBox runat="server" ID="mName"></asp:TextBox>
               
          
            <label for="pword"><b>Password:</b></label>
           <asp:TextBox runat="server" ID="pWord"></asp:TextBox>
            <br />
            <asp:Button runat="server" ID="submitBT" Text="Login" OnClick="submitBT_Click" BackColor="Brown" />
            <br />
            <a href="#">New Member Sign Up</a>
            
        </aside>

        <div id="Wrapper">

            <div id="picDiv"><img src="inside.jpg" height="400" width="960" /></div>
            <div>
                
            </div>

        </div>
    </form>
</body>
</html>
