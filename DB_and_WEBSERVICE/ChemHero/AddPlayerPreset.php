<?php

//Change User and PW
require 'includes/Config.php';

$uid = mysqli_escape_string($connection, $_GET['playerid']);
$body = mysqli_escape_string($connection, $_GET['body']);
$hair = mysqli_escape_string($connection, $_GET['hair']);
$eyebrows = mysqli_escape_string($connection, $_GET['eyebrows']);
$eyes = mysqli_escape_string($connection, $_GET['eyes']);
$nose = mysqli_escape_string($connection, $_GET['nose']);
$mouth = mysqli_escape_string($connection, $_GET['mouth']);
$gender = mysqli_escape_string($connection, $_GET['gender']);

$query="insert into player_preset(player_id,body_preset,hair_preset,eyebrows_preset,eyes_preset,nose_preset,mouth_preset,gender) values('$uid','$body','$hair','$eyebrows','$eyes','$nose','$mouth','$gender')";
$result=  mysqli_query($connection, $query);

if($result)
{
    echo "success";
}
else
{
    echo "query error";
}