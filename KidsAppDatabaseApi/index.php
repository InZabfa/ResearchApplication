<?php include_once('InitiateConnection.php');

      $Params = array("jesshope@email.com","Password1234");

      $Val= $DB->returnQuery("SELECT CAST((SELECT COUNT(*) FROM Participant WHERE Email = ? AND Password = ?) AS BIT) AS Result", $Params);


      print_r($Val);
      if ($Val[0] == 0){
          echo "Can't login";
      } else {
          http_response_code(200);
          echo json_encode(array("TOKEN"=>"FOKSDIFSKDFVICMNASFINSKCASJIFSNDIN"));
      }

?>