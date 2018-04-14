<?php
session_start();
$current='index';
require 'includes/Config.php';
include "includes/header.php";
include "includes/navigation.php";

?>

    <!-- Begin #carousel-section -->
    <section id="carousel-section" class="section-global-wrapper"> 
        <div class="container-fluid-kamn">
            <div class="row">
                <div id="carousel-1" class="carousel slide" data-ride="carousel">

                    <!-- Indicators -->
                    <ol class="carousel-indicators visible-lg">
                        <li data-target="#carousel-1" data-slide-to="0" class="active"></li>
                        <li data-target="#carousel-1" data-slide-to="1"></li>
                        <li data-target="#carousel-1" data-slide-to="2"></li>
                    </ol>
        
                    <!-- Wrapper for slides -->
                    <div class="carousel-inner" role="listbox">
                        <!-- Begin Slide 1 -->
                        <div class="item active">
                            <img src="assets/img/slider/world.png" height="400" alt="Image of first carousel">
                            <div class="carousel-caption">
                                <h3 class="carousel-title hidden-xs">Office BOOTSTRAP TEMPLATE</h3>
                                <p class="carousel-body">RESPONSIVE \ MULTI PAGE</p>
                            </div>
                        </div>
                        <!-- End Slide 1 -->

                        <!-- Begin Slide 2 -->
                        <div class="item">
                            <img src="assets/img/slider/chem.jpg" height="400" alt="Image of second carousel">
                            <div class="carousel-caption">
                                <h3 class="carousel-title hidden-xs">EASY TO CUSTOMIZE</h3>
                                <p class="carousel-body">BEAUTIFUL \ CLEAN \ MINIMAL</p>
                            </div>
                        </div>
                        <!-- End Slide 2 -->

                        <!-- Begin Slide 3 -->
                        <div class="item">
                            <img src="assets/img/slider/chero.png" height="1000" alt="Image of third carousel">
                            <div class="carousel-caption">
                                <h3 class="carousel-title hidden-xs">MULTI-PURPOSE TEMPLATE</h3>
                                <p class="carousel-body">PORTFOLIO \ CORPORATE \ CREATIVE</p>
                            </div>
                        </div>
                        <!-- End Slide 3 -->
                    </div>
        
                    <!-- Controls -->
                    <a class="left carousel-control" href="#carousel-1" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left"></span>
                    </a>
                    <a class="right carousel-control" href="#carousel-1" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right"></span>
                    </a>
                </div>
            </div>
        </div>
    </section>
    <!-- End #carousel-section -->


    <!-- Begin #services-section -->
    <section id="services" class="services-section section-global-wrapper">
        <div class="container">
            <div class="row">
                <div class="services-header">
                    <h3 class="services-header-title">Your Mission</h3>
                    <p class="services-header-body"><em> Be the Top Hero Apprentice </em>  </p><hr>
                </div>
            </div>
      
            <!-- Begin Services Row 1 -->
            <div class="row services-row services-row-head services-row-1">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                    <div class="services-group wow animated fadeInLeft" data-wow-offset="40">
<!--                        <p class="services-icon"><span class="fa fa-android fa-5x"></span></p>-->
                        <img src="assets/img/agency.png" height="200" alt="Image of third carousel">
                        <h4 class="services-title">Join Hero Agency</h4>
                        <p class="services-body">Join the 4 available Hero Agency that matches your Characteristics and Preferences</p>
                        <p><br></p>
                    </div>
                </div>
        
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                    <div class="services-group wow animated zoomIn" data-wow-offset="40">
<!--                        <p class="services-icon"><i class="fa fa-android fa-5x"></i></p>-->
                         <img src="assets/img/hero.png" height="200" alt="Image of third carousel">
                        <h4 class="services-title">Create your own Hero Apprentice</h4>
                        <p class="services-body">Design your own Hero Apprentice's Facial features to fit your preferences</p>
                        <p><br></p>
                    </div>
                </div>
        
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                    <div class="services-group wow animated fadeInRight" data-wow-offset="40">
<!--                        <p class="services-icon"><i class="fa fa-thumbs-o-up fa-5x"></i></p>-->
                        <img src="assets/img/help.png" height="200" alt="Image of third carousel">
                        <h4 class="services-title">Help the World Sector</h4>
                        <p class="services-body">To be a distinguished Hero Apprentice, it is your goal to help the world sector.</p>
                        <p><br></p>
                    </div>        
                </div>
            </div>
            <!-- End Serivces Row 1 -->
      
            <!-- Begin Services Row 2 -->
            <div class="row services-row services-row-tail services-row-2">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                    <div class="services-group wow animated fadeInLeft" data-wow-offset="40">
<!--                        <p class="services-icon"><span class="fa fa-windows fa-5x"></span></p>-->
                        <img src="assets/img/combine.png" height="200" alt="Image of third carousel">
                        <h4 class="services-title">Combine Elements</h4>
                        <p class="services-body">Combine elements to produce the compound that is needed in certain scenarios</p>
                        <p><br></p>
                    </div>
                </div>
        
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                    <div class="services-group wow animated zoomIn" data-wow-offset="40">
<!--                        <p class="services-icon"><i class="fa fa-eye fa-5x"></i></p>-->
                        <img src="assets/img/leaderboard.png" height="200" alt="Image of third carousel">
                        <h4 class="services-title">Dominate the leaderboard</h4>
                        <p class="services-body">Mix element's as much as you can within the time limit to gain a high score</p>
                        <p><br></p>
                    </div>
                </div>
        
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                    <div class="services-group wow animated fadeInRight" data-wow-offset="40">
                        <img src="assets/img/top.png" height="200" alt="Image of third carousel">
                        <h4 class="services-title">Be the top Hero Apprentice</h4>
                        <p class="services-body">Help, Combine and Dominate to be the Top Hero Apprentice</p>
                        <p><br></p>
                    </div>
                </div>
            </div>
            <!-- End Serivces Row 2 -->
    
        </div>      
    </section>
    <!-- End #services-section -->


    <!-- Footer -->
    <?php
    include 'includes/footer.php';
    ?>

        
    <script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="js/wow.min.js"></script>
    <script>
      new WOW().init();
    </script>
  </body>
</html>
