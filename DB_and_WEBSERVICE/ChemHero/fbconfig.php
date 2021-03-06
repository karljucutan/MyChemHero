<?php
// added in v4.0.0

session_start();

error_reporting(E_ALL);
ini_set('display_errors', TRUE);
ini_set('display_startup_errors', TRUE);
ini_set('memory_limit', '-1');
 
 
// Include the autoloader provided in the SDK
require_once 'facebook-php-sdk/autoload.php';
 
// Include required libraries
use Facebook\Facebook;
use Facebook\Exceptions\FacebookResponseException;
use Facebook\Exceptions\FacebookSDKException;
 
$appId = '530169034015972'; //Facebook App ID
$appSecret = '470e9f8a5501447ac5be8bb50aa60552'; //Facebook App Secret
$redirectURL = 'https://mychemhero.xyz/fbconfig.php'; //Callback URL
$fbPermissions = array();  //Optional permissions
 
$fb = new Facebook(array(
    'app_id' => $appId,
    'app_secret' => $appSecret,
    'default_graph_version' => 'v2.9',
        ));
 
// Get redirect login helper
$helper = $fb->getRedirectLoginHelper();

// Try to get access token
try {
    // Already login
    if (isset($_SESSION['facebook_access_token'])) {
         header("Location: https://mychemhero.xyz/index.php");
        $accessToken = $_SESSION['facebook_access_token'];
    } else {
        $accessToken = $helper->getAccessToken();
    }
 
    if (isset($accessToken)) {
        if (isset($_SESSION['facebook_access_token'])) {
            $fb->setDefaultAccessToken($_SESSION['facebook_access_token']);
        } else {
            // Put short-lived access token in session
            $_SESSION['facebook_access_token'] = (string) $accessToken;
 
            // OAuth 2.0 client handler helps to manage access tokens
            $oAuth2Client = $fb->getOAuth2Client();
 
            // Exchanges a short-lived access token for a long-lived one
            $longLivedAccessToken = $oAuth2Client->getLongLivedAccessToken($_SESSION['facebook_access_token']);
            $_SESSION['facebook_access_token'] = (string) $longLivedAccessToken;
 
            // Set default access token to be used in script
            $fb->setDefaultAccessToken($_SESSION['facebook_access_token']);
        }
 
        // Redirect the user back to the same page if url has "code" parameter in query string
        if (isset($_GET['code'])) {
 
            // Getting user facebook profile info
            try {
                $profileRequest = $fb->get('/me?fields=name,first_name,last_name,email,link,gender,locale,picture');
//                $fbUserProfile = $profileRequest->getGraphNode()->asArray();
                  $fbUserProfile = $profileRequest->getGraphNode();

                  $fname=$fbUserProfile->getField('first_name');
                  $email=$fbUserProfile->getField('email');
                  $lname=$fbUserProfile->getField('last_name');
                  $id=$fbUserProfile->getField('id');
                  
                  $_SESSION['FNAME']=$fname;
                  $_SESSION['LNAME']=$lname;
                  $_SESSION['EMAIL']=$fname."@facebook.com";
                  $_SESSION['ID']=$id;

                  require 'includes/FBlog.php';
                echo "<pre/>";
                print_r($fbUserProfile);
            } catch (FacebookResponseException $e) {
                echo 'Graph returned an error: ' . $e->getMessage();
                session_destroy();
                // Redirect user back to app login page
                header("Location:  https://mychemhero.xyz/index.php");
                exit;
            } catch (FacebookSDKException $e) {
                echo 'Facebook SDK returned an error: ' . $e->getMessage();
                exit;
            }
        }
    } else {
        // Get login url
 
        $loginURL = $helper->getLoginUrl($redirectURL, $fbPermissions);
        header("Location: " . $loginURL);
        
    }
} catch (FacebookResponseException $e) {
    echo 'Graph returned an error: ' . $e->getMessage();
    exit;
} catch (FacebookSDKException $e) {
    echo 'Facebook SDK returned an error: ' . $e->getMessage();
    exit;
}
