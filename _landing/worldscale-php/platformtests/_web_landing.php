<?php
//Model-Based Testing Attempts
//Test consumer-facing website

//Begin test
$ch = curl_init("https://runbladeau.azurewebsites.net");
$fp = fopen("_web_landing.result", "w");
curl_setopt($ch, CURLOPT_FILE, $fp);
curl_setopt($ch, CURLOPT_HEADER, 0);
curl_exec($ch);

//Debug output, send headers, etc.
if(curl_error($ch)) {
    fwrite($fp, curl_error($ch));
    //Send error HTTP header
    http_response_code(500);
}
else {
    fwrite($fp, $ch);
    http_response_code(200);
}
curl_close($ch);
fclose($fp);
?>