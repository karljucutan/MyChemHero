<?php
require 'includes/Config.php';
//$query="Select * from Scores order by score";
//$query="Select player_score from sector_score";
$query="select * from sector_score";
$result=  mysqli_query($connection, $query);

$result_array = array();

while($row=  mysqli_fetch_assoc($result))
{
    //$name=$row['name'];
    //$score=$row['score'];
   $pid=$row['player_id'];
   $score=$row['player_score'];
    //echo $name. ";" .$score.";";
    echo $pid.";".$score."+";
}

