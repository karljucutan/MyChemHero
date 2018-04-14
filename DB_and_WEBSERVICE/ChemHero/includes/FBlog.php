<?php

session_start();
require 'includes/Config.php';

global $connection;
$fbemail=$_SESSION['EMAIL'];
$fbfname=$_SESSION['FNAME'];
$fblname=$_SESSION['LNAME'];
$query="Select * from player where email='$fbemail'";
$result=  mysqli_query($connection, $query);
if($result->num_rows > 0)
{
    header("Location:  https://mychemhero.xyz/index.php");
}
else
{
    $insertquery="Insert into player(firstname,lastname,email,active) values('$fbfname','$fblname','$fbemail','yes')";
    $insertRes=  mysqli_query($connection, $insertquery);
    if($insertRes)
    {
        header("Location:  https://mychemhero.xyz/index.php");
    }
    else
    {
        mysqli_error($connection);
    }
}
