<?php
require 'includes/Config.php';

$query = "SELECT player_game.player_id AS id,firstname,team_colorID,player_points,helps_made,body_preset,hair_preset,eyebrows_preset,eyes_preset,nose_preset,mouth_preset,gender from player,player_preset,player_game,team "
        . "where player.player_id=player_preset.player_id AND player_preset.player_id=player_game.player_id AND player_game.team_id=team.team_id;";
$result=  mysqli_query($connection, $query);
while($row=  mysqli_fetch_assoc($result))
{
    $id = $row['id'];
    $query2 = "SELECT COUNT(player_id) AS sectors FROM sector_score WHERE player_id = '$id'";
    $result2 =  mysqli_query($connection, $query2);

    if($row2 = mysqli_fetch_assoc($result2)){
        echo $row['id'].";".$row['firstname'].";".$row['team_colorID'].";".$row['player_points'].";".
            $row['body_preset'].";".$row['hair_preset'].";".$row['eyebrows_preset'].";".$row['eyes_preset'].";".$row["nose_preset"].";".$row["mouth_preset"].";".$row['gender'].";".
            $row['helps_made'].";".$row2['sectors']."+";
    }


}
    
