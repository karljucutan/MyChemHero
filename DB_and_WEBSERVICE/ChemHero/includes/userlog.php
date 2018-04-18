<?php
/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

global $connection;
    $email=mysqli_real_escape_string($connection,filter_input(INPUT_POST, 'email_log'));
    $password=mysqli_real_escape_string($connection,filter_input(INPUT_POST,'pass_log'));
    $query="Select * from player where email='$email'";
    $result=  mysqli_query($connection, $query);
    if(!$result)
    {
        echo mysqli_error($connection);
    }
    if($row=  mysqli_fetch_assoc($result))
    {
        $pid=$row['player_Id'];
        $pass=$row['password'];
        $firstname=$row['firstname'];
        $active=$row['active'];
        if(password_verify($password, $pass))
        {
             //echo "<script type='text/javascript'>alert('login ka')</script>";
            if($active=='yes'){
                $_SESSION['loggedin']=true;
                $_SESSION['FNAME']=$firstname;
                $_SESSION['email']=$email;
                $_SESSION['active']=$active;
                $_SESSION['Message']="";
                $_SESSION['PLAYERID']=$pid;
                header('Location: https://mychemhero.xyz/index.php');
                exit;
            }
            else
            {
                $_SESSION['Message']="Please Verify your Email Address";
            }
        }
        else
        {
       
            $_SESSION['Message']="Username or Password is Incorrect";
        }
    }
    else
    {
        $_SESSION['Message']="Username or Password is Incorrect";
    }

