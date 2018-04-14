<?php

/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

require 'includes/Config.php';

$pid=$_GET['playerid'];
$badge=$_GET['badge'];

$query="insert into player_badge(player_id,badge) values ('$pid','$badge')";
$result=  mysqli_query($connection, $query);
if($result)
{
    echo "Success";
}
else
{
    echo " error kabodie";
}