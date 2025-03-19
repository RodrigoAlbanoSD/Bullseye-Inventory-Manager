<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />

        <title>CRUD - Mongo and Node - Tester</title>
        <link rel="stylesheet" href="mainStyleSheet.css">
    </head>
    <body>
        <h1 >Welcome to Bullseye</h1>
        <div id = "ChooseLocation">
            
            <form  action="buildPage.php" method="GET">
                <div class="title">Select a Store</div>
                <p>Which region is closest to you?</p>

                <?php 
                //connect to db and get all sites
                require 'dbConnector.php';
                include "ChromePhp.php";
                try {
                    $conn = connect_db();
                    $stmt = $conn->query("select * from site");
                    $stmt->execute();
                    $locations = $stmt->fetchAll();
                    //ChromePhp::log($locations);
                    $stmt->closeCursor();
                } catch (PDOException $e) {
                    echo "*** ERROR: " . $e->getMessage();
                }
                //display sites
                echo "<select name='location'>";

                for($i = 3; $i < count($locations); $i++){
                    echo "<option value='".$locations[$i]['siteID']."'>".$locations[$i]['name']." </option>";
                }
                echo "</select>";
                session_start();
                $_SESSION["productList"] = null;
                ?>
                <button id="btnChooseLocation" type="summit">Next</button>
            </form>            
            
        </div>


    </body>
</html>