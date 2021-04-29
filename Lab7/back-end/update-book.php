<?php
header("Access-Control-Allow-Headers: *");
header("Access-Control-Allow-Origin: *");
include ('connection.php');
$connect = OpenConnection();

$postdata = file_get_contents("php://input");
$request = json_decode($postdata);
$author = $request->author;
$title = $request->title;
$pages = $request->pages;
$genre = $request->genre;

$query="";
if ($pages == "")
    $query = "UPDATE books SET  genre='$genre' WHERE author='$author' AND title='$title'";
elseif($genre == "")
    $query = "UPDATE books SET   pages='$pages' WHERE author='$author' AND title='$title'";
else 
    $query = "UPDATE books SET  genre='$genre', pages='$pages' WHERE author='$author' AND title='$title'";
$result = mysqli_query($connect, $query);

if (!$result)
	echo 'Book can not be updated!';
else
	echo 'Book updated!';

CloseConnection($connect);
        
?>