<?php
require_once('json.php');
$host = "host=127.0.0.1";
$port = "port=5432";
$dbname = "dbname=baza_projekt";
$credentials = "user=sdawidow password=notifications";


$db = pg_connect("$host $port $dbname $credentials");
if(!$db)
    echo 'Error';
else
    echo 'Success';

$date = date('Y-m-d H:i:s');


$command = "SELECT * FROM notifications;";
$ret = pg_query($db, $command);
$notifications = array();

while($row = pg_fetch_row($ret))
{
    $dataArray = array();
    /*echo "id = ". $row[0] . "<br/>";
    echo "date = ". $row[1] ."<br/>";
    echo "name = ". $row[2] ."<br/>";
    echo "surname = ". $row[3] ."<br/>";
    echo "notification = ". $row[4] ."<br/>";
    echo "latitude = ". $row[5] ."<br/>";
    echo "longitude = ". $row[6] ."<br/>";*/
    $dataArray['id'] = $row[0];
    $dataArray['date'] = $row[1];
    $dataArray['name'] = $row[2];
    $dataArray['surname'] = $row[3];
    $dataArray['notification'] = $row[4];
    $dataArray['latitude'] = $row[5];
    $dataArray['longitude'] = $row[6];
    array_push($notifications, $dataArray);
    $lat = $row[5];
    $lon = $row[6];
}
$json = new Services_JSON();
pg_close($db);
?>

<!DOCTYPE html>
<html>
<head>
    <script src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <script src="https://code.jquery.com/jquery-2.2.0.min.js"></script>
    <link rel="stylesheet" href="style.css"/>
</head>
<body>
<div id="notificationsInfo"></div>
<div id="data"></div>
<div id="googleMap"></div>
<script>

    var map;
    var markers = [];

    function initMap()
    {
        var myLatLng = {lat: <?php echo $lat; ?>, lng: <?php echo $lon; ?>};
        var mapPro = {
            center: myLatLng,
            zoom: 4,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        map = new google.maps.Map(document.getElementById('googleMap'), mapPro);

    }

    function AddMarker(location, id)
    {
        var marker = new google.maps.Marker({
            position: location,
            map: map,
            title: id
        });
        markers.push(marker);
    }

    function SetMarkersOnAll(map)
    {
        markers.forEach(function(){
            setMap(map);
        });
    }

    function ClearMarkers(map)
    {
        markers.forEach(function(){
           setMap(null);
        });
    }

    function RemoveMarker(id)
    {
        for(var i = 0; i < markers.length; i++)
        {
            if(markers[i]['title'] == id)
                markers[i].setMap(null);
        }
    }

    function CreateNotificationDiv(element)
    {
        var text = 'Id: ' + element['id'] + '\n' +
            'Name: ' + element['name']  + '\n' +
            'Surname: ' + element['surname'] + '\n' +
            'Notification: ' + element['notification'] + '\n' +
            'Date: ' + element['date'] + '\n' + 
            'Latitude: ' + element['latitude'] + '\n' +
            'Longitude: ' + element['longitude'];

        $('<div/>', {"class" : 'record'}).text(text).click(function()
        {
            if($(this).attr('class') == 'record')
            {
                AddMarker({lat: parseFloat(element['latitude']), lng: parseFloat(element['longitude'])}, element['id']);
                $(this).attr('class', 'clicked');
            }
            else
            {
                RemoveMarker(element['id']);
                $(this).attr('class', 'record');
            }
        }).appendTo("#data");

    }

    $(document).ready(function()
    {
        var notificationsHtml = document.getElementById("notificationsInfo");
        var notificationsArray = <?php echo $json->encode($notifications); ?>;
        //for(var i = 0; i < notificationsArray.length; i++)
        //{
        //    notificationsHtml.innerHTML = JSON.stringify(notificationsArray);
        //}


        google.maps.event.addDomListener(window, 'load', initMap);
        notificationsArray.forEach(CreateNotificationDiv);
    });



</script>
</body>
</html>