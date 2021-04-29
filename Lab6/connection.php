<?php
    function OpenConnection(): mysqli
    {    
        return mysqli_connect("localhost", "root", "", "booklibrary");
    }
    
    function CloseConnection(mysqli $con)
    {
        $con->close();
    }

