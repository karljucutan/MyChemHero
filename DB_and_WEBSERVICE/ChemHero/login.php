<!DOCTYPE html>
<?php
session_start();
$current='login';
require 'includes/Config.php';
include "includes/navigation.php";

$_SESSION['Message']="";
    if(!isset($_SESSION['loggedin'])&&!isset($_SESSION['facebook_access_token']))
    {
        if(isset($_POST['submit_log']))
        {

            require'includes/userlog.php';
        }
        else if(isset($_POST['submit_logFB'])) 
        {
            require 'fbconfig.php';
        }
    }
    else
    {
        //header('Location: http://localhost:8080/ChemHero/index.php');
        $URL=" https://mychemhero.xyz/index.php";
        echo "<script type='text/javascript'>document.location.href='{$URL}';</script>";
        echo '<META HTTP-EQUIV="refresh" content="0;URL=' . $URL . '">';
        exit;
    }
    
?>
<html >
<head>
    <title>Login</title>
<!--  <meta charset="UTF-8">
  <link href='https://fonts.googleapis.com/css?family=Titillium+Web:400,300,600' rel='stylesheet' type='text/css'>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">-->

  
  <link rel="stylesheet" href="assets/css/logsign_style.css">

  
</head>

<body style="background-image:url(assets/img/bg.jpg);">

  <div class="form">
      
      <div class="tab-content">
        
        <!--end of register-->
        
      
          <h1>Welcome Back!</h1>
          
          <form action="http://mychemhero.xyz/login.php" method="post">
          
            <div class="field-wrap">
            <label>
              Email Address<span class="req">*</span>
            </label>
            <input type="email" name="email_log" required autocomplete="off"/>
          </div>
          
          <div class="field-wrap">
            <label>
              Password<span class="req">*</span>
            </label>
            <input type="password" name="pass_log" required autocomplete="off"/>
          </div>
          <?php
              echo"<p class='forgot' style='color:#A51B26'>{$_SESSION['Message']}</p>";
          ?>
        
          <button type="submit" name="submit_log" class="button button-block"/>Log In</button>
          </br>
          
          </form>
          <form action="login.php" method="post">
              <button  type="submit" name="submit_logFB" class="button button-block"/><img src="assets/img/fb.png" style="padding:10px">Log In with Facebook</button>
          </form>
        </div>
        

      
</div> <!-- /form -->
<span style="display:inline-block; width: 1000px;"></span>
<span style="display:inline-block; width: 1000px;"></span>
<span style="display:inline-block; width: 1000px;"></span>
<span style="display:inline-block; width: 1000px;"></span>


 <?php
    include 'includes/footer.php';
 ?>
    <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>

    <script  src="js/index.js"></script>

</body>
</html>