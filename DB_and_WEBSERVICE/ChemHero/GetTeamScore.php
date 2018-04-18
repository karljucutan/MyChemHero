<?php

require 'includes/Config.php';


$query = "select * from score";
$result=  mysqli_query($connection, $query);
while($row=  mysqli_fetch_assoc($result))
{
    echo $row['teamid'].";".$row['cityid']."+";
}
