<?php 
$current="";
include "includes/navigation.php";

if(isset($_POST['go_home']))
{
    $URL=" http://mychemhero.xyz/index.php";
    echo "<script type='text/javascript'>document.location.href='{$URL}';</script>";
    echo '<META HTTP-EQUIV="refresh" content="0;URL=' . $URL . '">';
    exit;
}
?>
<link rel="stylesheet" href="assets/css/logsign_style.css">
<body style="background-color: #93c6c0">
    <form action="http://mychemhero.xyz/Verification.php" method="post">
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

                            <h1 class="services-body" style="text-align: center">You are now Registered!</h1>
                            <h2  style="text-align: center">Please verify your Email Address to Start playing Chem Heroes!</h2>
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

