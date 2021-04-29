<?php
include ('connection.php');
$connect = OpenConnection();

$author=$_POST['author'];
$title =$_POST['title'];

$query = "UPDATE books SET lended='YES' WHERE author='$author' AND title='$title'";
$result = mysqli_query($connect, $query);

if (!$result)
	echo 'Book can not be lended!';
else
	echo 'Book was lended!';

CloseConnection($connect);
        
?>