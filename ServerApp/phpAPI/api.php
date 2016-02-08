<?php

$input = file_get_contents('php://input');
$input = stripslashes($input);

$input = substr($input, 1, strlen($input) - 2);

$data = array();
$arr = explode(',', $input);
foreach($arr as $element)
{
    echo $element;
    $dic = explode(':', $element);
    $key = trim($dic[0]);
    $key = substr($key, 1, strlen($key) - 2);
    $value = trim($dic[1]);
    $value = substr($value, 1, strlen($value) - 2);
    $data[$key] = $value;
    echo strlen($key) . ' ' . strlen($value);
}

//$data = json_decode($json, true);
//echo 'Is working';

//$keys = array_keys($data);

$host = "host=localhost";
$port = "port=5432";
$dbname = "dbname=baza_projekt";
$credentials = "user=sdawidow password=notifications";


$db = pg_connect("$host $port $dbname $credentials");
if(!$db)
    echo "Error";
else
    echo "Success";


$name = $data['Name'];
$surname = $data['Surname'];
$notification_id = intval($data['Notification']);
$latitude = doubleval($data['Latitude']);
$longitude = doubleval($data['Longitude']);
$date = date('Y-m-d H:i:s');

echo $name . ' ' . $surname . ' ' . $notification_id . ' ' . $latitude . ' ' . $longitude . '</br>';
echo $latitude + $longitude;

/*$name = "Zbigniew";
$surname = "Boniek";
$notification_id = 2;
$latitude = 10;
$longitude = 20;*/

$command = "INSERT INTO notifications (date, name, surename, cid, lat, long) VALUES ('$date', '$name', '$surname', $notification_id, $latitude, $longitude);";
//$command = "INSERT INTO customers (id, name, surname, salary) VALUES (10, 'Ziom', 'Ziomek', 1000);";
$ret = pg_query($db, $command);
echo 'query';

?>