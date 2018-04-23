<?php
require 'includes/Config.php';


$query="Select player.player_Id AS id,firstname,player_points,helps_made from player,player_game where player.player_Id=player_game.player_id order by player_points desc";


$result=  mysqli_query($connection, $query);

while($row=  mysqli_fetch_assoc($result))
{
    $id = $row['id'];
    $query2 = "SELECT COUNT(player_id) AS sectors FROM sector_score WHERE player_id = '$id'";
    $result2 =  mysqli_query($connection, $query2);

    if($row2 = mysqli_fetch_assoc($result2)){
        echo $row['id'].';'.$row['firstname']. ";" .$row['player_points'].";" .$row['helps_made'].";".$row2['sectors'].'+';
    }
}

?>

