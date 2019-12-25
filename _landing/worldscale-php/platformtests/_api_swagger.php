<?php
//Model-Based Testing Attempts
//Test swagger-type APIs

//Ingestor
$ch = curl_init("https://virtserver.swaggerhub.com/runblade/ingestor/1.0.0/devices");
curl_setopt($ch, CURLOPT_HEADER, 0);  
curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);  
$result = curl_exec($ch);

//Cruncher
$ch2 = curl_init("https://app.swaggerhub.com/apis/runblade/cruncher/1.0.0");
curl_setopt($ch2, CURLOPT_HEADER, 0);  
curl_setopt($ch2, CURLOPT_RETURNTRANSFER, true);  
$result2 = curl_exec($ch2);

//Concierge
$ch2 = curl_init("https://app.swaggerhub.com/apis/runblade/concierge/1.0.0");
curl_setopt($ch2, CURLOPT_HEADER, 0);  
curl_setopt($ch2, CURLOPT_RETURNTRANSFER, true);  
$result2 = curl_exec($ch2);

//Evaluate tests
if(curl_error($ch) || strlen($result) < 10 || curl_error($ch2) || strlen($result2) < 10) {
    //Send error HTTP header
    http_response_code(500);
}
else {
    http_response_code(200);
}
curl_close($ch);
?>