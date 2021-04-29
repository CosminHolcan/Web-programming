<?php
header('Access-Control-Allow-Headers: *');
header('Access-Control-Allow-Origin: *');
include ('connection.php');
$connect = OpenConnection();

$postdata = file_get_contents("php://input");
$request = json_decode($postdata);
$author = $request->author;
$title = $request->title;

$query = "DELETE FROM books WHERE author = '$author' AND title = '$title'";
$result = mysqli_query($connect, $query);

CloseConnection($connect);
        
?>