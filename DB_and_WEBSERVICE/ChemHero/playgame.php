<?php
session_start();
$current='playgame';
include "includes/navigation.php";

    if(!isset($_SESSION['loggedin']) && !isset($_SESSION['facebook_access_token']))
    {
        header('Location: https://mychemhero.xyz/index.php');
        exit;
    }
?>

<html lang="en-us">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>Unity WebGL Player | New Unity Project 10</title>
    <link rel="shortcut icon" href="TemplateData/favicon.ico">
    <link rel="stylesheet" href="TemplateData/style.css">
    <script src="TemplateData/UnityProgress.js"></script>  
    <script src="Build/UnityLoader.js"></script>
    <script>
      var gameInstance = UnityLoader.instantiate("gameContainer", "Build/MCH.json", {onProgress: UnityProgress});
    </script>
  </head>
 <body style="background-image:url(assets/img/bg.jpg);">
     <div class="container"><p></br></p></div>
    <div class="webgl-content">
      <div id="gameContainer" style="width: 1280px; height: 720px"></div>
      <div class="footer">
        <div class="webgl-logo"></div>
        <div class="fullscreen" onclick="gameInstance.SetFullscreen(1)"></div>
        <div class="title">New Unity Project 10</div>
      </div>
    </div>
  </body>
</html>