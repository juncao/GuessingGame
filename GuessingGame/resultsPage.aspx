<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resultsPage.aspx.cs" Inherits="resultsPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <asp:Label ID="lblResults" runat="server" Style="z-index: 100; left: 15px; position: absolute;
          top: 22px"></asp:Label>
       <asp:Button ID="btnPlayAgain" runat="server" OnClick="btnPlayAgain_Click" Style="z-index: 102;
          left: 7px; position: absolute; top: 90px" Text="Play Again" />
    
    </div>
    </form>
</body>
</html>
