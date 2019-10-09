<?php
include_once('Database.php');
$DB = new Database('localhost\SQLExpress','KidsApp');
if (is_null($DB)){
    throw new Exception("Couldn't initiate database.");
}
?>