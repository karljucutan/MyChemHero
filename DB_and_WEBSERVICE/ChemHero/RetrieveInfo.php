<?php

require 'includes/Config.php';

$playerid = $_GET["pid"];
$query = "select firstname, body_preset, hair_preset, eyebrows_preset, eyes_preset, nose_preset, mouth_preset, gender,team_colorID,player_points,helps_made,SUM(CASE WHEN sector_score.player_id='$playerid' THEN 1 ELSE 0 END)as sectors_hold from player, player_preset,sector_score,player_game,team WHERE player_preset.player_id=player.player_id and player.Player_Id=player_game.player_id and player_game.team_id=team.team_id and player.player_Id='$playerid'
";
 
$result= mysqli_query($connection,$query);
if($row= mysqli_fetch_assoc($result))
{
   echo $row['firstname'].';'.$row['body_preset'].';'.$row['hair_preset'].';'.$row['eyebrows_preset'].';'.$row['eyes_preset'].';'.$row['nose_preset'].';'.$row['mouth_preset'].';'.$row['gender'].";".$row['player_points'].";".$row['helps_made'].";".$row['sectors_hold'].';'.$row['team_colorID'];
}