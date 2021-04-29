<?php
include ('connection.php');
$connect = OpenConnection();

$author=$_POST['author'];
$title =$_POST['title'];
$pages =$_POST["pages"];
$genre =$_POST["genre"];

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