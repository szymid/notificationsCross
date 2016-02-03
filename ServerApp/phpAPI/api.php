<?php

$data = json_decode(file_get_contents('php://input'), true);

$keys = array_keys($data);

$host = "host=localhost";
$port = "port=5432";
$dbname = "dbname=info";
$credentials = "user=postgres password=przemo2174";


$db = pg_connect("$host $port $dbname $credentials");
if(!$db)
    echo "Error";
else
    echo "Success";


$command = "INSERT INTO reports (name, surname, accident) VALUES ('${data[$keys[0]]}', '${data[$keys[1]]}', '${data[$keys[2]]}');";
//$command = "INSERT INTO customers (id, name, surname, salary) VALUES (10, 'Ziom', 'Ziomek', 1000);";
$ret = pg_query($db, $command);

?>