<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register assembly="DevExpress.Web.v13.1" namespace="DevExpress.Web.ASPxFileManager" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxFileManager ID="ASPxFileManager1" runat="server" oncustomthumbnail="ASPxFileManager1_CustomThumbnail">
            <settings rootfolder="~\" />
        </dx:ASPxFileManager>
    </div>
    </form>
</body>
</html>