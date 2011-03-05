<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="dovesiamo.aspx.cs" Inherits="Philinternational.dovesiamo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"><meta
    name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <style type="text/css">
        #map_canvas
        {
            height: 350px;
            width: 550px;
        }
        
        .columnGoogle
        {
            background-color: #000000;
            border: 0px;
        }
        .style1
        {
            width: 180px;
            background-color: #FFFFFF;
        }
    </style>
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=true">
    </script>
    <script type="text/javascript">
        function initialize() {
            var latlng = new google.maps.LatLng(45.5389012, 9.2835619);
            var myOptions = { zoom: 18, center: latlng, mapTypeId: google.maps.MapTypeId.ROADMAP };
            var map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
            var marker = new google.maps.Marker({ position: latlng, map: map });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><h1>Dove
    siamo</h1>
    <br />
    <br />
    Ci trovi in via Domenico Cimarosa, n° 11 <br />
    20144, Milano<br />
    <br />
    <div id="map_canvas" style="border: 1px solid #C0C0C0">
    </div>
    <br />
    <div>
        <table class="columnGoogle" style="border-style: none; background-color: #FFFFFF">
            <tr>
                <td class="style1">
                    <img src="http://maps.google.it/intl/it_it/images/logos/maps_logo.gif" alt="" />
                </td>
                <td style="background-color: #FFFFFF">
                    Powered by Google Maps
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
</asp:Content>
