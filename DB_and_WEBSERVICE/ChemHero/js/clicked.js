/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
//
//   $(".nav li").on("click", function() {
//      //$(".nav li").removeClass("active");
//      $(this).addClass("active");
//    });

//if(document.getElementById('index').clicked === true)
//{
//   alert("button was clicked");
//}


var link1 = document.getElementById("login");

// attach event
link1.onclick = function(e) { return myHandler(e); };

// your handler
function myHandler(e) {
    // do whatever
    $(this).addClass("active");
    // prevent execution of the a href
    return false;
}