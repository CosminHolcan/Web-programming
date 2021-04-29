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

if($author != '' && $title != '')
{
    $query = "INSERT INTO books (author, title, pages, genre, lended) VALUES ('$author', '$title', '$pages', '$genre', 'NO')";
    $result = mysqli_query($connect, $query);

    if (!$result)
        echo 'Could not add new book!';
    else
        echo 'New book added!';
}

CloseConnection($connect);
        
?>