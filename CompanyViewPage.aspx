<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyViewPage.aspx.cs" Inherits="Assignment.CompanyViewPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    <script type="text/javascript">
        function openYesNo() {
            $('#YesNoModal').modal('show');
        };
        function openShow() {
            $('#Files').modal('show');
        };
    </script>

    <script src="js/jquery.min.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>


</head>
<body>
    <form id="form1" runat="server">
        <div class="card" style="width: 800px; height: 500px; padding: 10px 8px 10px 8px; margin-left: 250px">
            <div class="card-header">
                <asp:Label ID="lblHeader" runat="server" Text="Company Details"></asp:Label>
                <asp:Label ID="lblCompId" runat="server" Visible="false"></asp:Label>
            </div>
            <div class="card-body">

                <asp:GridView ID="gdvCompany" runat="server" AutoGenerateColumns="false" CssClass="table-bordered" Width="700px" Height="200px" BackColor="LightBlue">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr No" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CompanyId" HeaderText="Company id" ItemStyle-Width="150px" Visible="true" />
                        <asp:BoundField DataField="CompanyName" HeaderText="Company Name" ItemStyle-Width="150px" />
                        <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="150px" />
                        <asp:TemplateField>
                            <HeaderTemplate>Actions</HeaderTemplate>
                            <ItemTemplate >

                                <asp:Button ID="BtnShow" Text="Show" runat="server" CssClass="btn btn-sm btn-link" Style="font-size: small; width: 70px; height: 25px" CausesValidation="true" OnClick="BtnShow_Click" />
                                <asp:Button ID="BtnApproveDisapprove" runat="server" Text="Approve/DisApprove" CssClass="btn btn-sm btn-link" Style="font-size: small; width: 70px; height: 25px" CausesValidation="true" OnClick="BtnApproveDisapprove_Click" />

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
            <div class="card-footer text-right">
            </div>
        </div>



        <div id="YesNoModal" class="modal" data-keyboard="false" data-backdrop="static" role="dialog">
            <div class="modal-dialog modal-dialog-centered modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" style="text-align-last" aria-hidden="true">×</button>

                    </div>
                    <div class="modal-body" style="height: 70px">
                        <asp:Button ID="BtnYes" runat="server" CssClass="btn btn-success btn-sm " Text="Approve" Width="90px" Style="margin-left: 25px" OnClick="BtnYes_Click" CausesValidation="false" />
                        <asp:Button ID="BtnNo" runat="server" CssClass="btn btn-danger btn-sm " Text="DisApprove" Width="90px" CausesValidation="false" OnClick="BtnNo_Click" />

                    </div>

                    <div class="modal-footer" style="padding: 2px 15px 2px;">
                        <%--<button type="button" class="btn btn-success btn-sm" style="width:50px">Yes</button>--%>
                    </div>
                </div>
            </div>
        </div>
        <div id="Files" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:Label ID="lblHeader1" runat="server" Text="Files"></asp:Label>
                        <button type="button" class="close" data-dismiss="modal" style="text-align-last" aria-hidden="true">×</button>

                    </div>
                    <div class="modal-body" style="max-height: 200px; width: 100px">
                        <div class="form-group">

                            <div class="col-md-10">
                                <asp:GridView runat="server" ID="DataGridView" AutoGenerateColumns="false" Width="75px" style="overflow-y:scroll" Height="190px">
                                    <Columns>
                                        <asp:BoundField DataField="FileId" HeaderText="File id" ItemStyle-Width="190px" Visible="false" />
                                        <asp:BoundField DataField="FileName" HeaderText="File Name" />
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>

                                               
                                                <asp:Button ID="lnkDownload" Text="Download" runat="server" CssClass="btn btn-sm btn-link" Style="font-size: small; width: 70px; height: 25px" CausesValidation="true" OnClick="lnkDownload_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
