<?php
session_start();
$current="";
require "includes/Config.php";
require "includes/verifier.php";
include "includes/navigation.php";


    if(isset($_GET['email']) && !empty($_GET['email']) AND isset($_GET['hash']) && !empty($_GET['hash']))
    {
        $email=$_GET['email'];
        $hash=$_GET['hash'];
    }
//<meta http-equiv='refresh' content='=5;http://localhost:8080/ChemHero/login.php' />
?>
<html>
    <link rel="stylesheet" href="assets/css/logsign_style.css">
    <body style="background-color: #93c6c0">
        <form action="verify.php" method="post">
        <?php
            if(verify($email, $hash)){

            echo"
                <div class='container'>
                <div class='row'>

                    <br>
                    <br>
                    <br>
                    <br>
                   <div class='col-lg-12'>
                        <div class='services-group wow animated fadeInLeft' data-wow-offset='40'>

                            <h1 class='services-body' style='text-align: center'>You are now Registered!</h1>
                            <h2  style='text-align: center'>You can now login and start playing My Chem Heroes!</h2>
                            <h3 style='text-align: center'>You will automatically be redirected to the Login Page in</h3>  
                    <br>
                    <br>
                        </div>
                    </div>
                </div>
                </div>";
            }
            header( "refresh:5;url=http://mychemhero.xyz/login.php" );
        ?>
        </form>
        <div style="
        position: fixed;
        bottom: 0;
        width: 100%;">
        <span style="display:inline-block; width: 1000px;"></span>
        <span style="display:inline-block; width: 1000px;"></span>
        <span style="display:inline-block; width: 1000px;"></span>
        <span style="display:inline-block; width: 1000px;"></span>


         <?php
            include 'includes/footer.php';
         ?>
        </div>
    </body>
</html>
