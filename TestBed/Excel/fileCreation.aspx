<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="fileCreation.aspx.vb" Inherits="TestBed.fileCreation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 
</head>
<body>

    <h2>hello</h2>
    <button id="btnSubmit">submit</button>
    
</body>

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
$(function () {
    $("#btnSubmit").click(function () {        
        $.ajax({
            type: "POST",
            url: "Service.asmx/CreateExcel",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                alert("pass")
                alert(r.d);
            },
            error: function (r) {
                alert("error")
                alert(r.responseText);
            },
            failure: function (r) {
                alert("fails")
                alert(r.responseText);
            }
        });
        return false;
    });
});
</script>

</html>
