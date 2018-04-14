<?php

/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

require 'includes/Config.php';
//$query="Select * from Scores order by score";
//$query="Select player_score from sector_score";
$pname=$_GET['name'];
$query="select player_Id from player where firstname='$pname'";
$result=  mysqli_query($connection, $query);

if($row=  mysqli_fetch_assoc($result))
{
    echo $row['player_Id'];
}