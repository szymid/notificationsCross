<?php

$host = "host=localhost";
$port = "port=5432";
$dbname = "dbname=info";
$credentials = "user=postgres password=przemo2174";

$db = pg_connect("$host $port $dbname $credentials");
echo "Success";

$command = "SELECT * FROM reports;";
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