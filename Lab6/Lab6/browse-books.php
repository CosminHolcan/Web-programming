<?php
include ('connection.php');
$connect = OpenConnection();

$author=$_GET['author'];
$genre =$_GET["genre"];

$query="";
if ($author == "" && $genre == "")
    $query = "SELECT * FROM books";
elseif($genre == "")
    $query = "SELECT * FROM books WHERE author='$author'";
elseif($author == "")
    $query = "SELECT * FROM books WHERE genre='$genre'";
else
    $query = "SELECT * FROM books WHERE genre='$genre' AND author='$author'";
$result = mysqli_query($connect, $query);
if(mysqli_num_rows($result)>0){
    while ($row = mysqli_fetch_array($result)){
        echo "<tr>";
        echo "<td>".$row['author']."</th>";
        echo "<td>".$row['title']."</th>";
        echo "<td>".$row['pages']."</th>";
        echo "<td>".$row['genre']."</th>";
        echo "<td>".$row['lended']."</th>";
        echo "</tr>";
    }

}

CloseConnection($connect); 
        
?>