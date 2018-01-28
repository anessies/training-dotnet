<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieList.aspx.cs" Inherits="training.MovieList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col">
            <asp:GridView ID="gvMovie" BorderWidth="0" GridLines="None" runat="server"
                AutoGenerateColumns="false" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="รหัสภาพยนต์" />
                    <asp:BoundField DataField="title" HeaderText="ชื่อภาพยนต์" />
                    <asp:TemplateField HeaderText="รูป">
                        <ItemTemplate>
                            <asp:Image Height="80px" ID="img" ImageUrl='<%# Eval("coverImg") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="releaseDate" HeaderText="เข้าฉายเมื่อ" />
                    <asp:BoundField DataField="genre" HeaderText="หมวดหมู่" />
                    <asp:BoundField DataField="duration" HeaderText="ความยาม (นาที)" />
                    <asp:TemplateField HeaderText="ลบ">
                        <ItemTemplate>
                            <asp:Button
                                CssClass="btn btn-danger"
                                OnClientClick="return confirm('คุณต้องการลบข้อมูลรายการนี้ใช่หรือไม่ ?');"
                                OnClick="btnDelete_Click"
                                Text="Delete"
                                ID="btnDelete"
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
