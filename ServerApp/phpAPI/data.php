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

while($row = pg_fetch_row($ret))
{
    echo "id = ". $row[0] . "<br/>";
    echo "date = ". $row[1] ."<br/>";
    echo "name = ". $row[2] ."<br/>";
    echo "surname = ". $row[3] ."<br/>";
    echo "notification = ". $row[4] ."<br/>";
    echo "latitude = ". $row[5] ."<br/>";
    echo "longitude = ". $row[6] ."<br/>";
}
echo "Operation done sucessfully";
pg_close($db);
?>
