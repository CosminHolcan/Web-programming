<?php
include ('connection.php');
$connect = OpenConnection();

$author=$_POST['author'];
$title =$_POST['title'];
$pages =$_POST["pages"];
$genre =$_POST["genre"];

$query = "INSERT INTO books (author, title, pages, genre, lended) VALUES ('$author', '$title', '$pages', '$genre', 'NO')";
$result = mysqli_query($connect, $query);

if (!$result)
	echo 'Could not add new book!';
else
	echo 'New book added!';

CloseConnection($connect);
        
?>