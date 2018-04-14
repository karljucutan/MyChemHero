<?php
require 'includes/Config.php';

$secNum=$_GET['sector'];
$pid=$_GET['playerid'];
$score=$_GET['pscore'];

$updateQuery="update sector_score set player_id='$pid',player_score='$score' where sector_id='$secNum'";
$result=  mysqli_query($connection, $updateQuery);
if($result)
{
    echo "not fail ";
}
else
{
    echo "fail";
}