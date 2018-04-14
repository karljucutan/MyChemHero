<?php

/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

require 'includes/Config.php';

$query="select * from team";
$result= mysqli_query($connection, $query);
while($row= mysqli_fetch_assoc($result))
{
    echo $row['team_id'].";".$row['team_name'].";".$row['team_colorID']."+";
}