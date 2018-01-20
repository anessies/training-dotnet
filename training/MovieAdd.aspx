<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieAdd.aspx.cs" Inherits="training.MovieAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">Movie Form</div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label Text="ชื่อภาพยนต์" Font-Bold="true" runat="server" />
                        <asp:TextBox runat="server" ID="txtTitle" placeholder="ชื่อภาพยนต์" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:Label Text="เช้าฉายเมื่อ" Font-Bold="true" runat="server" />
                        <div class='input-group date' id='dtPicker'>
                            <input type='text' class="form-control" id="txtDate" runat="server" />
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label Text="หมวดหมู่" Font-Bold="true" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlGenre" CssClass="form-control">
                            <asp:ListItem Text="แอนิเมชัน" Value="แอนิเมชัน" />
                            <asp:ListItem Text="แอคชั่น" Value="แอคชั่น" />
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
        <div class="col-md-3"></div>
    </div>

    <script type="text/javascript">
        $(function () {
            $('#dtPicker').datetimepicker({
                format: 'YYYY/MM/DD',
                defaultDate: new Date(),
            });
        });
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
    </script>
</asp:Content>
