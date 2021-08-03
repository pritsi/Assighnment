<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyMaster.aspx.cs" Inherits="Assignment.CompanyMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery.min.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="card" style="width:700px;height:300px;padding:10px 8px 10px 8px;margin-left:250px">
            <div class="card-header">
                <asp:Label ID="lblHeader" runat="server" Text="Company Master">

               </div>
            <div class="card-body">
            <asp:Label id="lblName" runat="server" Text="Company Name" placeholderr="Enter Company Name"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
               
            <asp:FileUpload ID="fuDocs" AllowMultiple="true" runat="server"/>
            </div>
            <div class="card-footer text-right">

           
            <asp:Button ID="BtnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" Width="150px"  OnClick="BtnSubmit_Click"/> 
                 </div>
        </div>
    </form>
</body>
</html>
