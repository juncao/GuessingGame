<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GuessingPage.aspx.cs" Inherits="GuessingPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
       <asp:Label ID="lblGuesses" runat="server" Style="z-index: 101; left: 20px; position: absolute;
          top: 41px"></asp:Label>
       <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Style="z-index: 103;
          left: 9px; position: absolute; top: 133px" Text="Submit your guess" 
           Height="34px" Width="178px" />
       <asp:Label ID="lblPrompt" runat="server" Style="z-index: 104; left: 19px; position: absolute;
          top: 7px"></asp:Label>
       <asp:Label ID="lblResults" runat="server" BorderStyle="Solid" BorderWidth="1px" Style="z-index: 99;
          left: 19px; position: absolute; top: 73px; height: 22px;"></asp:Label>
       <p>
       <asp:TextBox ID="txtGuess" runat="server" Style="z-index: 102; left: 128px; position: absolute;
          top: 104px; height: 26px; right: 830px;" Width="139px"></asp:TextBox>
       </p>
       <asp:Label ID="lblGuess" runat="server" Style="z-index: 100; left: 18px; position: absolute;
          top: 105px; height: 27px; width: 100px;" Text="Enter your guess"></asp:Label>
    </form>
</body>
</html>
