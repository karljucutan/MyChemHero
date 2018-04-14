<?php

/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

require 'includes/Config.php';

$pid=$_GET['playerid'];

//$query="select player_state from player_game where player_id='$pid'";
$query="SELECT player_state FROM player_game WHERE player_id='$pid'";

$result=  mysqli_query($connection, $query);

if($row=  mysqli_fetch_assoc($result))
{
    echo $row['player_state'];
}
else
{
    echo "none";
}

