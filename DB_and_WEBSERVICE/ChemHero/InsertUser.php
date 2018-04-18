<?php

require 'includes/Config.php';

$pid=$_GET['playerid'];
$fid=$_GET['team_id'];

$query="insert into player_game(player_id,team_id,player_points,player_state,helps_made) values('$pid','$fid',0,'returning',0)";
$result=  mysqli_query($connection, $query);
if($result)
{
    echo "success";
}
else
{
    echo "fail";
}