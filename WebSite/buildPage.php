<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />

        <title>CRUD - Mongo and Node - Tester</title>
        <script>
            


            window.onload = function(){
                document.querySelector("#InventoryTable").addEventListener("click", handleRowClick);
//                document.querySelector("#btnCategory").addEventListener("click", SearchByCategory);
//                document.querySelector("#btnShowForm").addEventListener("click", ShowForm);
            
            }

            function handleRowClick(e) {
                clearSelections();
                e.target.parentElement.classList.add("highlighted");
            }

            function clearSelections() {
                let elem = document.querySelector(".highlighted");
                if (elem) {
                    elem.classList.remove("highlighted");
                }
            }

        </script>

        <link rel="stylesheet" href="mainStyleSheet.css">
    </head>
    <body>
        <h1 >Welcome to Bullseye</h1>
        <div id="btnBack"><form action="index.php"><button type="submit"><img src="images/goBack.png"></button> </form></div>
        <div id="navigator"> 
            <form id='FormCategory' action="buildPage.php" method="GET">
                <p>Choose a category here: </p>
                <select name="categoryName">
                    <?php
                    require 'dbConnector.php';
                    include "ChromePhp.php";

                    try{
                        $conn = connect_db();
                        $stmt = $conn->prepare("select * from category");
                        $stmt->execute();
                        $category = $stmt->fetchAll();
                        $stmt->closeCursor();
                        foreach ($category as $c){
                            echo "<option>".$c["categoryName"]."</option>";
                        }
                    } catch (PDOException $e) {
                    echo "*** ERROR: " . $e->getMessage();
                    }
                    ?>

                </select> 

                <button type="submit" >Search</button>
            </form>
        </div>
        <!--<button id="btnShowForm">Add to Cart</button>-->
        
        <div id="Table">
        <table id= "InventoryTable">
            <tr><th>Product</th><th>Description</th><th>Category</th><th>Price</th><th></th></tr>
            <?php 
            session_start();
            //Fix location choice in session
            if(isset($_GET["location"])){
                $_SESSION["location"] = $_GET["location"];
            }
            //Start table header
            try {
                //get all itemId in the inventory for the chossen site
                $conn = connect_db();
                $stmt = $conn->prepare("select * from inventory where siteID = " . $_SESSION["location"]); 
                $stmt->execute();
                $itemList = $stmt->fetchAll();
                $stmt->closeCursor();
                
                //Loop through item table and get the matchs
                foreach ($itemList as $itemID) {
                    
                    if(isset($_GET["categoryName"])){
                        $stmt = $conn->prepare("select * from item where itemID = " . $itemID["itemID"]." and category = '".$_GET["categoryName"]."'");
                    }
                    else{
                        $stmt = $conn->prepare("select * from item where itemID = " . $itemID["itemID"]."");
                    }                 
                    $stmt->execute();
                    $item = $stmt->fetch();
                    $stmt->closeCursor();
                    if($item != false){
                        //ChromePhp::log($item);
                        $name = $item["name"];
                        $desc = $item["description"];
                        $cat = $item["category"];
                        $price = $item["retailPrice"];
                        echo "<tr><td>".$name."</td><td>".$desc."</td><td>".$cat."</td><td> $".$price."</td><td>";
                        echo "<form action ='buildPage.php' method='GET'><input name='itemID' value='".$itemID["itemID"]."' type='hidden'></input>";
                        echo "<input name='quantityInventory' value='".$itemID["quantity"]."' type='hidden'></input><button type='submmit'>Add</button></form></td></tr>";                       
                    }

                }


            } catch (PDOException $e) {
                echo "*** ERROR: " . $e->getMessage();
            }
            ?>
        </table>
        </div>
        
        
        <?php
        if(isset($_GET["itemID"])){
            
            $itemID = $_GET["itemID"];
            $quantityInventory = $_GET["quantityInventory"];
            
            $stmt = $conn->prepare("select * from item where itemID = " . $itemID);
            $stmt->execute();
            $item = $stmt->fetch();
            $name = $item["name"];
            $desc = $item["description"];
            $cat = $item["category"];
            $price = $item["retailPrice"];
            $stmt->closeCursor(); 
            
            echo "<div id='FormAdd'>";
            echo "<form action ='buildPage.php' method='GET' >";
            echo "<div class='title'>". $name ."</div>";
            echo "<div id='retailLogo'><img src='images/RetailsLogo.jpg'></div>";
            echo "<div id='container'><p>How many items you want to buy?</p><input name='Quantity' type='number' min ='1' max='".$quantityInventory."'></input></div>";
            echo "<button type='submit'>Add to Cart</button>";
            echo "</form>";
            echo "</div>";
            
            $_SESSION["itemID"] = $itemID;
            $_SESSION["name"] = $name;
            $_SESSION["price"] = $price;
            
        }
        ?>           
        
        
        <?php 
            if(isset($_GET["Quantity"]) && ($_SESSION["productList"] != null)){
                $quantity = $_GET["Quantity"];
                $productList = ['itemid'=> $_SESSION["itemID"], 'name'=> $_SESSION["name"], 'quantity'=>$quantity, 'price'=>$_SESSION["price"]];
                array_push($_SESSION["productList"], $productList);
                if($quantity == null){ $quantity = 1;};
                
                echo "<div id='Cart'>";
                echo "<div class='title'>Cart</div>";
                echo "<form action='finishOrder.php' method='GET'>";
                foreach ($_SESSION["productList"] as $product){
                    echo "<p> ".$product["quantity"]." ".$product["name"]."</p>";  
                }
                echo "<button type='submit'>Finish</button>";
                echo "</form>";
                echo "</div>";
            }
            else if(isset($_GET["Quantity"]) && $_SESSION["productList"] === null ){
                $quantity = $_GET["Quantity"];
                if($quantity == null){ $quantity = 1;};
                echo "<div id='Cart'>";
                echo "<form action='finishOrder.php' method='GET'>";
                echo "<div class='title'><h4>Cart</h4></div>";
                echo "<p> ". $quantity . " " . $_SESSION["name"] . "</p>";
                echo "<button type='submit'>Finish</button>";
                echo "</form>";
                echo "</div>";
                //save product in array
                $productList = ['itemid'=> $_SESSION["itemID"], 'name'=> $_SESSION["name"], 'quantity'=>$quantity, 'price'=>$_SESSION["price"]];
                $_SESSION["productList"][] = $productList;
                
            }
        ?>
            
        
    </body>
</html>