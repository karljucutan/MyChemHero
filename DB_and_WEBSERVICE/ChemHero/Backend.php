<?php
require 'includes/Config.php';
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title></title>
        
          <link rel='stylesheet prefetch' href='http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/themes/smoothness/jquery-ui.css'>
          <link rel='stylesheet prefetch' href='http://netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css'>

          <link rel="stylesheet" href="assets/css/backend.css">

  
    </head>
    <body>
    <div class="container">
        <div id="table" class="table-editable">
            <span class="table-add glyphicon glyphicon-plus"></span>
                <table class="table">
                  <tr>
                        <th>PlayerId</th>
                        <th>Firstname</th>
                        <th>Lastname</th>
                        <th>Email</th>
                        <th>Password</th>
                        <th>Hash</th>
                        <th>Active</th>
                    </tr>
                    <?php
                        $query="Select * from users";
                        $result=  mysqli_query($connection, $query);
                        while($row=  mysqli_fetch_assoc($result))
                        {
                            echo" <tr>";
                            foreach ($row as $data)
                            {
                              echo "<td contenteditable='true'>". $data . "</td>";
                            }
                            echo" <td><button id='export-btn' class='btn btn-primary'>Export Data</button></td>";
                        }
                    ?>

            </table>
         </div>
          <button id="export-btn" class="btn btn-primary">Export Data</button>
          <p id="export"></p>
    </div>
    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    <script src='http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js'></script>
    <script src='https://netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js'></script>
    <script src='http://cdnjs.cloudflare.com/ajax/libs/underscore.js/1.6.0/underscore.js'></script>

    <script  src="assets/js/index.js"></script>

    </body>
</html>

