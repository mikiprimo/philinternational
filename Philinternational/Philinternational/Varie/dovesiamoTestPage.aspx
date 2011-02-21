<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dovesiamoTestPage.aspx.cs" Inherits="Philinternational.Varie.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://maps-api-ssl.google.com/maps/api/js?v=3&sensor=false" type="text/javascript"></script>
    <script lang="javascript" type="text/javascript">
        function initialize() {
            alert('ciao');
            //            var myLatlng = new google.maps.LatLng(40.764015, -73.982797);

            //            var myOptions = {
            //                zoom: 8,
            //                center: myLatlng,
            //                mapTypeId: google.maps.MapTypeId.ROADMAP
            //            }

            //            var map;
            //            map = new google.maps.Map(document.getElementById('map_canvas'), myOptions)
        };
    </script>
</head>
<body>
    <form id="form1" onload="initialize()">
    <h1>Dove siamo</h1>
    <hr />
    <br />
    via Domenico Cimarosa 11 <br />
    20144 Milano<br />
    <br />
    <div id="map_canvas" style="width: 100%; height: 100%">
    </div>
    </form>
</body>
</html>
