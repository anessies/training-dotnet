<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="training.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<script type="text/javascript" src="~/Scripts/jquery-1.10.2.min.js"></script>--%>
    <script type="text/javascript"  src="Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript"  src="Scripts/moment.js"></script>
    <script type="text/javascript"  src="Scripts/bootstrap.min.js"></script>
    <script type="text/javascript"  src="Scripts/bootstrap-datetimepicker.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="~/Content/bootstrap-datetimepicker.css" />
    <link rel="stylesheet" href="~/Content/bootstrap.css" />
</head>

<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class='col-sm-6'>
                    <div class="form-group">
                        <div class='input-group date' id='datetimepicker1'>
                            <input type='text' class="form-control" />
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>
                <script type="text/javascript">
                    $(function () {
                        $('#datetimepicker1').datetimepicker();
                    });
                </script>
            </div>
        </div>
    </form>
</body>
</html>
