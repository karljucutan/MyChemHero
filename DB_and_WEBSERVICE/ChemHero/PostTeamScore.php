<?php
require 'includes/Config.php';

$teamid=$_POST['teamid'];
$cityid=$_POST['cityid'];


$query="insert into score(teamid,cityid) values ('$teamid','$cityid')";
$result= mysqli_query($connection, $query);
if($result)
{
    echo "Success";
}
else
{
    echo " error kabodie";
}

?>