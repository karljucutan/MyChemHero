<?php
include "Classes/User.php";
include "Classes/phpmailer/mail.php";
/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

function login_user()
{
    global $connection;
    $email=mysqli_real_escape_string($connection,filter_input(INPUT_POST, 'email_log'));
    $password=mysqli_real_escape_string($connection,filter_input(INPUT_POST,'pass_log'));
    $query="Select * from users where email='$email'";
    $result=  mysqli_query($connection, $query);
    if(!$result)
    {
        echo mysqli_error($connection);
    }
    if($row=  mysqli_fetch_assoc($result))
    {
        $pass=$row['password'];
        $firstname=$row['firstname'];
        if($pass==$password)
        {
             //echo "<script type='text/javascript'>alert('login ka')</script>";
             setSession($firstname, $email);
             User::$creds=true;
             header('Location: http://localhost:8080/ChemHero/index.php');
             exit;
        }
        else
        {
       
            User::$creds=false;
        }
    }
    else
    {
        User::$creds=false;
    }
}
function register()
{
    global $connection;
    $hash = md5( rand(0,1000) ); 
    $firstname=  mysqli_real_escape_string($connection,filter_input(INPUT_POST, 'firstname_reg'));
    $lastname=mysqli_real_escape_string($connection,filter_input(INPUT_POST,'lastname_reg'));
    $email=mysqli_real_escape_string($connection,filter_input(INPUT_POST, 'email_reg'));
    $password=mysqli_real_escape_string($connection,filter_input(INPUT_POST,'password_reg'));
    $user=new User($connection,$email);
    if($user->checkEmail())
    {
        $query="Insert into users(firstname,lastname,email,password,hash,active) VALUES('$firstname','$lastname','$email','$password','$hash','no')";
        $result=  mysqli_query($connection, $query);
        if(!$result)
        {
            die('Cant Create!'.  mysqli_error($connection));
        }
        else
        {
            //go to somewhere
            sendEmail($email, $hash);
            header('Location: http://localhost:8080/ChemHero/Verification.php');
            
        }
    }
   
    
}
function setSession($fname,$email)
{
    $_SESSION['loggedin']=true;
    $_SESSION['firstname']=$fname;
    $_SESSION['email']=$email;

}
function sendEmail($email,$hash)
{
//    $to      = $email; // Send email to our user
//    $subject = 'Signup | Verification'; // Give the email a subject 
//    $message = '
// 
//    Thanks for signing up to Chem Hero!
//    Your account has been created, you can login with the following credentials after you have activated your account by pressing the url below.
// 
//    ------------------------
//    Email: '.$email.'
//    ------------------------
// 
//    Please click this link to activate your account:
//    http://www.yourwebsite.com/verify.php?email='.$email.'&hash='.$hash.'
// 
//    '; // Our message above including the link
//                     
//    $headers = 'From:ChemHero.com' . "\r\n"; // Set from headers
//    mail($to, $subject, $message, $headers); // Send our email
    
    $mail = new PHPMailer;

    //From email address and name
    $mail->From = "ChemHero.com";
    $mail->FromName = "ChemHero Activation Team";

    //To address and name
    $mail->addAddress($email, "Recepient Name");
    $mail->addAddress($email); //Recipient name is optional

    //Address to which recipient will reply
    $mail->addReplyTo("reply@yourdomain.com", "Reply");

    //CC and BCC
    $mail->addCC("cc@example.com");
    $mail->addBCC("bcc@example.com");

    //Send HTML or Plain Text email
    $mail->isHTML(true);

    $mail->Subject = "Subject Text";
    $mail->Body = '
 
    Thanks for signing up to Chem Hero!
    Your account has been created, you can login with the following credentials after you have activated your account by pressing the url below.
 
    ------------------------
    Email: '.$email.'
    ------------------------
 
    Please click this link to activate your account:
    http://www.yourwebsite.com/verify.php?email='.$email.'&hash='.$hash.'
 
    ';
    $mail->AltBody = "This is the plain text version of the email content";

    if(!$mail->send()) 
    {
        echo "Mailer Error: " . $mail->ErrorInfo;
    } 
    else 
    {
        echo "Message has been sent successfully";
    }
}
