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

echo 'rara';
$date = date('Y-m-d H:i:s');
//$result = $date->format('Y-m-d H:i:s');
echo $date;

/*$command = "SELECT * FROM notifications;";
$ret = pg_query($db, $command);

while($row = pg_fetch_row($ret))
{
    echo "Name = ". $row[0] . "<br/>";
    echo "Surname = ". $row[1] ."<br/>";
    echo "Accident = ". $row[2] ."<br/><br/>";
}
echo "Operation done sucessfully";
pg_close($db);
?>