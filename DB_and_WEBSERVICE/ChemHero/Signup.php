<!DOCTYPE html>
<?php
session_start();
$current='signup';
include "includes/navigation.php";

    if(!isset($_SESSION['loggedin'])&&!isset($_SESSION['facebook_access_token']))
    {
        if(isset($_POST['submit_reg']))
        {
            require 'includes/register.php';
        }
    }
    else
    {
        header('Location: https://mychemhero.xyz/index.php');
        exit;
    }
?>
<html >
<head>
  <title>Register</title>
  <link rel="stylesheet" href="assets/css/logsign_style.css">

  
</head>

<body style="background-image:url(assets/img/bg.jpg);">

  <div class="form">
      
      <div>
        <div id="signup">   
          <h1>Sign Up for Free</h1>
          
          <form action="Signup.php" method="post">
          
          <div class="top-row">
            <div class="field-wrap">
              <label>
                First Name<span class="req">*</span>
              </label>
              <input type="text" name="firstname_reg" required autocomplete="off" />
            </div>
        
            <div class="field-wrap">
              <label>
                Last Name<span class="req">*</span>
              </label>
              <input type="text" name="lastname_reg" required autocomplete="off"/>
            </div>
          </div>

          <div class="field-wrap">
            <label>
              Email Address<span class="req">*</span>
            </label>
            <input type="email" name="email_reg" required autocomplete="off"/>
          </div>
          
          <div class="field-wrap">
            <label>
              Set A Password<span class="req">*</span>
            </label>
            <input type="password" name="password_reg" required autocomplete="off"/>
          </div>
          
          <button type="submit" name="submit_reg" class="button button-block"/>Get Started</button>
          
          </form>

        </div>
     
        
      </div><!-- tab-content -->
      
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