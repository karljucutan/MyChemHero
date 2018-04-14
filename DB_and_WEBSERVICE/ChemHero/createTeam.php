<?php

//Change User and PW
require 'includes/Config.php';

$teamName = mysqli_escape_string($connection, $_GET['team_name']);
$teamColorId = mysqli_escape_string($connection, $_GET['team_colorid']);
$teamLeaderId=mysqli_escape_string($connection, $_GET['leaderid']);
$query="insert into team(team_name,team_colorID,team_leader) values('$teamName','$teamColorId','$teamLeaderId')";
$result=  mysqli_query($connection, $query);
mysqli_close($connection);
if($result)
{
   $connection=  mysqli_connect($DBHOST, $DBUSER, $DBPASS, $DBNAME);
   $query="Select team_id from team where team_leader='$teamLeaderId'";
   $result=mysqli_query($connection,$query);
   if($row=mysqli_fetch_assoc($result))
   {
       echo $row['team_id'];
   }
}
else
{
    echo "query error";
}
