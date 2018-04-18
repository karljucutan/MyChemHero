<?php

function verify($email,$hash)
{
    global $connection;
    $searchquery="select * from player where email='$email' and hash='$hash'";
    $result=  mysqli_query($connection, $searchquery);
    if($result->num_rows > 0)
    {
        $updatedb="update player set active='yes' where email='$email'";
        $result=  mysqli_query($connection, $updatedb);
        if(!$result)
        {
            echo 'Db error'.mysqli_error($connection);
        }
        else
        {
            return true;
        }
    }
    
    return false;
}
