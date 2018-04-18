<?php

/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
require 'includes/Config.php';

$pid=$_GET['playerid'];
$query = "select badge from player_badge where player_id='$pid'";
$result=  mysqli_query($connection, $query);
while($row=  mysqli_fetch_assoc($result))
{
    echo $row['badge'].";";
}
