<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieAdd.aspx.cs" Inherits="training.MovieAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col">
            <div class="panel panel-default" style="margin-top: 15px">
                <div class="panel-heading">Movie Form</div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label Text="ชื่อภาพยนต์" Font-Bold="true" runat="server" />
                        <asp:TextBox runat="server" ID="txtTitle" placeholder="ชื่อภาพยนต์" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:Label Text="เช้าฉายเมื่อ" Font-Bold="true" runat="server" />
                        <asp:TextBox ID="txtDate" ReadOnly="true" runat="server" CssClass="form-control" style="background-color: unset" />
                    </div>
                    <div class="form-group">
                        <asp:Label Text="หมวดหมู่" Font-Bold="true" runat="server" />
                        <asp:DropDownList runat="server" CssClass="form-control">
                            <asp:ListItem Text="แอนิเมชัน" />
                            <asp:ListItem Text="แอคชั่น" />
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label Text="ความยาว(นาที)" Font-Bold="true" runat="server" />
                        <asp:TextBox runat="server" ID="txtDuration" TextMode="Number" Text="100" max="300" min="100" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:Label Text="รูปภาพ" Font-Bold="true" runat="server" />
                        <asp:FileUpload ID="fuCoverImg" runat="server" CssClass="form-control" AllowMultiple="false" />
                    </div>
                    <asp:Button Text="Submit" runat="server" class="btn btn-primary" ID="btnSubmit" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </div>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" />
    <script src="http://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("input[id*='txtDate']").datepicker({
                format: "yyyy/mm/dd"
            }).datepicker("setDate", new Date());;
        });
    </script>
</asp:Content>
