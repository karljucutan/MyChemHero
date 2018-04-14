<?php
require 'includes/Config.php';
global $connection;
    $hash = md5( rand(0,1000) ); 
    $firstname=  mysqli_real_escape_string($connection,filter_input(INPUT_POST, 'firstname_reg'));
    $lastname=mysqli_real_escape_string($connection,filter_input(INPUT_POST,'lastname_reg'));
    $email=mysqli_real_escape_string($connection,filter_input(INPUT_POST, 'email_reg'));
    $password=mysqli_real_escape_string($connection,filter_input(INPUT_POST,'password_reg'));
    
    $query="Select * from player where email='$email'";
    $result=  mysqli_query($connection, $query);
    if($result->num_rows > 0)
    {
       echo "<script type='text/javascript'>alert('Email is Taken!')</script>";
    }
    else
    {
        $password=password_hash($password, PASSWORD_DEFAULT);
        $regquery="Insert into player(firstname,lastname,email,password,hash,active) VALUES('$firstname','$lastname','$email','$password','$hash','no')";
        $result=  mysqli_query($connection, $regquery);
        if(!$result)
        {
            die('Cant Create!'.  mysqli_error($connection));
        }
        else
        {
            //go to somewhere
            sendEmail($email, $hash);
            header('Location: https://mychemhero.xyz/Verification.php');
            exit;
        }
    }
function sendEmail($email,$hash)
{
    $to      = $email; // Send email to our user
    $subject = 'Signup | Verification'; // Give the email a subject 
    $message = '
 
    Thanks for signing up to Chem Hero!
    Your account has been created, you can login with the following credentials after you have activated your account by pressing the url below.
 
    ------------------------
    Email: '.$email.'
    ------------------------
 
    Please click this link to activate your account:
    https://mychemhero.xyz/verify.php?email='.$email.'&hash='.$hash.'
 
    '; // Our message above including the link
                     
    $headers = 'From:ChemHero.com' . "\r\n"; // Set from headers
    mail($to, $subject, $message, $headers); // Send our email
    
//    $mail = new PHPMailer;
//
//    //From email address and name
//    $mail->From = "ChemHero.com";
//    $mail->FromName = "ChemHero Activation Team";
//
//    //To address and name
//    $mail->addAddress($email, "Recepient Name");
//    $mail->addAddress($email); //Recipient name is optional
//
//    //Address to which recipient will reply
//    $mail->addReplyTo("reply@yourdomain.com", "Reply");
//
//    //CC and BCC
//    $mail->addCC("cc@example.com");
//    $mail->addBCC("bcc@example.com");
//
//    //Send HTML or Plain Text email
//    $mail->isHTML(true);
//
//    $mail->Subject = "Subject Text";
//    $mail->Body = '
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
//    ';
//    $mail->AltBody = "This is the plain text version of the email content";
//
//    if(!$mail->send()) 
//    {
//        echo "Mailer Error: " . $mail->ErrorInfo;
//    } 
//    else 
//    {
//        echo "Message has been sent successfully";
//    }
}

