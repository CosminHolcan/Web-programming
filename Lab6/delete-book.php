<?php
include ('connection.php');
$connect = OpenConnection();

$author=$_POST['author'];
$title =$_POST['title'];

$query = "DELETE FROM books WHERE author = '$author' AND title = '$title'";
$result = mysqli_query($connect, $query);

if (!$result)
	echo 'Book can not be deleted!';
else
	echo 'Book was deleted!';

CloseConnection($connect);
        
?>