<?php

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 * Description of User
 *
 * @author Kealu
 */
class User {
    //put your code here
    private $_db;
    private $_email;
    static $creds=true;
    public function __construct($db,$email) {
        $this->_db=$db;
        $this->_email=$email;
    }
    public function checkEmail()
    {
        $query="Select email from users where email='$this->_email'";
        $result=  mysqli_query($this->_db, $query);
        if(! $row = $result->fetch_array())
        {
            return true;
        }
        else
        {
            echo "<script type='text/javascript'>alert('Email is Taken!')</script>";
        }
    }
    
    
}
