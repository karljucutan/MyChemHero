<?php

/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
$DBHOST="localhost";
$DBNAME="u951958676_mch";
$DBPASS="2013108007";
$DBUSER="u951958676_user";


$connection=  mysqli_connect($DBHOST, $DBUSER, $DBPASS, $DBNAME);

$query="Select firstname,player_points from player,player_game where player.player_Id=player_game.player_id order by player_points desc";

$result=  mysqli_query($connection, $query);

while($row=  mysqli_fetch_assoc($result))
{
    echo $row['firstname']. ";" .$row['player_points'].";";
}
