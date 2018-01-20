<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieAdd.aspx.cs" Inherits="training.MovieAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        div#success-alert, div#danger-alert {
            width: 80%;
            position: fixed;
            margin: 5% auto;
            left: 0;
            right: 0;
            display: none;
        }
    </style>
    <div class="alert alert-success" id="success-alert"></div>
    <div class="alert alert-danger" id="danger-alert"></div>
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
                        <asp:TextBox ID="txtDate" ReadOnly="true" runat="server" CssClass="form-control" Style="background-color: unset" />
                    </div>
                    <div class="form-group">
                        <asp:Label Text="หมวดหมู่" Font-Bold="true" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlGenre" CssClass="form-control">
                            <asp:ListItem Text="แอนิเมชัน" />
                            <asp:ListItem Text="แอคชั่น" />
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label Text="ความยาว(นาที)" Font-Bold="true" runat="server" />
                        <asp:TextBox runat="server" ID="txtDuration" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:Label Text="รูปภาพ" Font-Bold="true" runat="server" />
                        <asp:FileUpload ID="fuCoverImg" runat="server" CssClass="form-control" AllowMultiple="false" />
                    </div>
                    <asp:Button Text="Submit" runat="server" class="btn btn-primary" ID="btnSubmit" OnClick="btnSubmit_Click" OnClientClick="return submitClick();" />
                </div>
            </div>
        </div>
    </div>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" />
    <script src="http://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        function submitClick() {
            if (!$('#MainContent_txtTitle').val()) {
                showAlertError('กรุณากรอกข้อมูลชื่อภาพยนต์');
                return false;
            }
            if (!$('#MainContent_txtDuration').val()) {
                showAlertError('กรุณากรอกข้อมูลความยาวของภาพยนต์(นาที)');
                return false;
            }
            if (isNaN($('#MainContent_txtDuration').val())) {
                showAlertError('กรุณากรอกข้อมูลความยาวของภาพยนต์(นาที) เป็นตัวเลขเท่านั้น');
                return false;
            }
            if (!$('#MainContent_fuCoverImg').val()) {
                showAlertError('กรุณาเลือกรูปภาพ');
                return false;
            }
        }
        function showAlertSuccess(msg) {
            $("#success-alert").text(msg);
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                $("#success-alert").slideUp(500);
            });
        }
        function showAlertError(msg) {
            $("#danger-alert").text(msg);
            $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
                $("#danger-alert").slideUp(500);
            });
        }
        $(document).ready(function () {
            $("input[id*='txtDate']").datepicker({
                format: "yyyy/mm/dd"
            });
        });
    </script>
</asp:Content>
