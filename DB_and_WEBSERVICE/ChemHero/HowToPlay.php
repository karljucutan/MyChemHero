<?php
session_start();
$current='howtoplay';
include "includes/navigation.php";

if(isset($_POST['go_home']))
{
    $URL=" https://mychemhero.xyz/index.php";
    echo "<script type='text/javascript'>document.location.href='{$URL}';</script>";
    echo '<META HTTP-EQUIV="refresh" content="0;URL=' . $URL . '">';
    exit;
}


?>
<!doctype html>
<html lang="en">
    <head>
        <meta charset="utf-8">
        <title>How to Play</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta name="description" content="">
        <meta name="author" content="">

        <link rel="stylesheet" href="assets/css/logsign_style.css">
    </head>


    <body style="background-color: #93c6c0">
        <form action="about.php" method="post">
            <div class="container">
                    <div class="row">
                        <br>
                        <br>
                        <br>
                        <br>
                        <br>
                        <br>
                       <div class="col-lg-12">
                            <div class="services-group wow animated fadeInLeft" data-wow-offset="40">

                                <h1 class="services-body" style="text-align: center"><img height="200" src="assets/img/construc.png" alt="fix-pic"></h1>
                                <h2  style="text-align: center">This Web Page is Under Construction</h2>
                                <br>
                                <br>
                                <button type="submit" name="go_home" class="button button-block" />Go Back to Home Page</button>
                        <br>
                        <br>
                            </div>
                        </div>
                    </div>
            </div>
        </form>
        
    <span style="display:inline-block; width: 1000px;"></span>
    <span style="display:inline-block; width: 1000px;"></span>
    <span style="display:inline-block; width: 1000px;"></span>
    <span style="display:inline-block; width: 1000px;"></span>


     <?php
        include 'includes/footer.php';
     ?>


  </body>
</html>
