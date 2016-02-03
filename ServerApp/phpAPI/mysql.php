<?php

$host = "mysql1.ugu.pl";
$port = "port=5432";
$dbname = "db681579";
$user = "db681579";
$pass= "lonsdale26";


$db = mysqli_connect($host, $user, $pass, $dbname);

if(mysqli_connect_errno())
    echo "Failed to connnect to MySQL server: " . mysqli_connect_error();
else
    echo "Connection successful";

?>