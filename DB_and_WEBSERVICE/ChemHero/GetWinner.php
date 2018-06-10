<?php

require 'includes/Config.php';


$query = "SELECT teamid FROM `score` GROUP BY teamid HAVING COUNT(teamid) = 19 ";
$result = array();
$result = mysqli_query($connection, $query);
$row = mysqli_fetch_assoc($result);
if(isset($row)){
    echo $row['teamid'];
}
?>