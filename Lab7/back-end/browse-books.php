<?php header('Access-Control-Allow-Origin: *');
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
if ($result) {
    $number_of_rows = mysqli_num_rows($result);
    $books = array();
    for ($i = 0; $i < $number_of_rows; $i++) {
        $row = mysqli_fetch_array($result);
        array_push($books, array(
            "title" => $row['title'],
            "author" => $row['author'],
            "pages" => (int)$row['pages'],
            "genre" => $row['genre'],
            "lended" => $row['lended']));
    }
    mysqli_free_result($result);
    echo json_encode($books);
}

CloseConnection($connect); 
        
?>