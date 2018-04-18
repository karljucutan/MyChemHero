<?php

/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

require 'includes/Config.php';

$pid=$_GET['playerid'];
$tpoints=$_GET['totalpoints'];
$help=$_GET['helps'];

$query="Update player_game set player_points=player_points+'$tpoints',helps_made=helps_made+'$help' where player_id='$pid'";
$result=  mysqli_query($connection, $query);
if($result)
{
    echo "success";
}
 else {
    echo "fail";
 }