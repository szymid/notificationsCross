<!DOCTYPE html>
<html>
<head>
    <script src="http://maps.googleapis.com/maps/api/js"></script>
</head>
<body>
<?php

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
        echo "id = ". $row[0] . "<br/>";
        echo "date = ". $row[1] ."<br/>";
        echo "name = ". $row[2] ."<br/>";
        echo "surname = ". $row[3] ."<br/>";
        echo "notification = ". $row[4] ."<br/>";
        echo "latitude = ". $row[5] ."<br/>";
        echo "longitude = ". $row[6] ."<br/>";
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
    echo "Operation done sucessfully";
    pg_close($db);
?>
<div id="notificationsInfo"></div>
<div id="googleMap" style="width:500px;height:380px;"></div>
<script>
    var notificationsArray = <?php echo json_encode($notifications); ?>;

    var notificationsHtml = document.getElementById("notificationsInfo");
    for(i = 0; i < notificationsArray.length; i++)
    {
        
    }

    function initialize()
    {
        var mapProp = {
            center:new google.maps.LatLng(51.508742,-0.120850),
            zoom:5,
            mapTypeId:google.maps.MapTypeId.ROADMAP
        };
        var map=new google.maps.Map(document.getElementById("googleMap"),mapProp);
    }

    function initMap()
    {
        var myLatLng = {lat: <?php echo $lat; ?>, lng: <?php echo $lon; ?>};
        var mapPro = {
            center: myLatLng,
            zoom: 4,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        var map = new google.maps.Map(document.getElementById('googleMap'), mapPro);

        var marker = new google.maps.Marker({
            position: myLatLng,
            map: map,
            title: 'Hello World!'
        });
    }

    google.maps.event.addDomListener(window, 'load', initMap);
</script>
</body>

</html>