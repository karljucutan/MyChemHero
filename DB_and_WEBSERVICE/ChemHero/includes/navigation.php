<?php
    include "includes/globalNavCss.php";

?> 
<style type="text/css">
     ul li a{
        display: block;
        padding: 8px 15px;
        color: #333;
        text-decoration: none;
    }
    ul li ul.dropdown{

        min-width: 100%; /* Set width of the dropdown */
        background:#529d67;
        display: none;
        position: absolute;
        z-index: 999;
        left: 15px;
        box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);

    }
    ul li:hover ul.dropdown{
        display: block;	/* Display the dropdown */
    }
    ul li ul.dropdown li{
        display: block;
    }
</style>
<nav id="navbar-section" class="navbar navbar-default navbar-static-top navbar-sticky" role="navigation">
    
        <div class="container" style="background-color:#0b2c2d;padding:15px;">
        
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-responsive-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>

            <a class="navbar-brand wow fadeInDownBig" href="index.html"><img class="office-logo" src="assets/img/MCH-LOGO.png" style="margin-top:-14px;" alt="Office"></a>      
            </div>
        
            <div id="navbar-spy" class="collapse navbar-collapse navbar-responsive-collapse">
                <ul id="NavMenu" class="nav navbar-nav pull-right">
                    <li>
                        <a <?php if($current=='index'){echo "class='active'";}?> href="https://mychemhero.xyz/index.php">Home</a>
                    </li>
                    <li>
                        <a <?php if($current=='about'){echo "class='active'";}?> href="https://mychemhero.xyz/about.php">About</a>
                    </li>
                    <li>
                        <a <?php if($current=='howtoplay'){echo "class='active'";}?>href="https://mychemhero.xyz/HowToPlay.php">How to Play</a>
                    </li>
                    <?php
                        
                        if(isset($_SESSION['loggedin'])|| isset($_SESSION['facebook_access_token']))
                        {
                         
                             if(isset($_SESSION['facebook_access_token']))
                            {
                                $fbid=$_SESSION['ID'];
                                $fname=$_SESSION['FNAME'];
                                //img src='//graph.facebook.com/{{fid}}/picture"
                                if($current=="playgame")
                                {
                                    echo "<li>
                                        <a class='active' href='playgame.php'>Let's Play</a>
                                      </li>
                                       <li>
                                         <a href='#'><img src='//graph.facebook.com/$fbid/picture'style='width:25px;border-radius: 50%;' >  $fname &#9662;</a>
                                          <ul class='dropdown'>
                                            <li><img src=''><a href='logout.php'>LogOut</a></li>
                                          </ul>
                                       </li>";

                                }
                                else
                                {
                                      echo "
                                          <li>
                                        <a href='playgame.php'>Let's Play</a>
                                      </li>
                                      <li>
                                        <a href='#'><img src='//graph.facebook.com/$fbid/picture'style='width:25px;border-radius: 50%;' >  $fname &#9662;</a>
                                          <ul class='dropdown'>
                                            <li><a href='logout.php'>LogOut</a></li>
                                          </ul>
                                       </li> 
                                            " 
                                      ;
                                }
                            }
                            else if(isset($_SESSION['loggedin']))
                            {
                                 $fname=$_SESSION['FNAME'];
                                 if($current=="playgame")
                                {
                                    echo "<li>
                                        <a class='active' href='playgame.php'>Let's Play</a>
                                      </li>
                                      <li>
                                        <a href='#'><img src='assets/img/defpic.png' style='width:25px;border-radius: 50%;' >  $fname &#9662;</a>
                                          <ul class='dropdown'>
                                            <li><a href='logout.php'>LogOut</a></li>
                                          </ul>
                                       </li> ";

                                }
                                else
                                {
                                      echo "
                                          <li>
                                        <a href='playgame.php'>Let's Play</a>
                                      </li>
                                      <li>
                                        <a href='#'><img src='assets/img/defpic.png' style='width:25px;border-radius: 50%;' >  $fname &#9662;</a>
                                          <ul class='dropdown'>
                                            <li><a href='logout.php'>LogOut</a></li>
                                          </ul>
                                       </li>" 
                                      ;
                                }
                            }
                          
                        }
                        else
                        {
                            if($current=='login'){
                                echo "<li>
                                    <a class='active' href='login.php'>Log In</a>
                                  </li>
                                  <li>
                                    <a href='Signup.php' id='index' >Sign Up</a>
                                  </li>";
                            }
                            else if($current=='signup')
                            {
                                echo "<li id='login'>
                                    <a  href='login.php'>Log In</a>
                                  </li>
                                  <li>
                                    <a href='Signup.php' class='active'>Sign Up</a>
                                  </li>";
                            }
                            else
                            {
                                echo "<li id='login'>
                                    <a  href='login.php'>Log In</a>
                                  </li>
                                  <li>
                                    <a href='Signup.php' id='index'>Sign Up</a>
                                  </li>";
                            }
                            
                        }
                    ?>
                    
                    
                </ul>         
            </div>
            
        </div>
    </nav>

