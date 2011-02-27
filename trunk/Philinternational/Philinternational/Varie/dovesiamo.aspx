<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="dovesiamo.aspx.cs" Inherits="Philinternational.dovesiamo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="http://maps-api-ssl.google.com/maps/api/js?v=3&sensor=false" type="text/javascript"></script>
    <script type="text/javascript">

var map;
function initialize() {

var myLatlng = new google.maps.LatLng(40.764015, -73.982797);

var myOptions = {
zoom: 8,
center: myLatlng,
mapTypeId: google.maps.MapTypeId.ROADMAP
};

map = new google.maps.Map(document.getElementById('map_canvas'), myOptions);

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><h1>Dove
    siamo</h1>
    <br />
    <br />
    via Domenico Cimarosa 11 <br />
    20144 Milano<br />
    <br />
    <div id="map_canvas" style="width: 100%; height: 100%">
    </div>
</asp:Content>
