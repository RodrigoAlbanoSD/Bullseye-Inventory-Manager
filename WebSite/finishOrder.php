<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />

        <title>CRUD - Mongo and Node - Tester</title>
        <script>

        </script>
        
        <link rel="stylesheet" href="mainStyleSheet.css">
    </head>
    <body>
        <div class="title">Almost there...</div>
        <div id = "GetClientInfo">

            <form  action="finishOrder2.php" method="GET">
                <p>Please, write bellow you information so we could proceed if your order</p><br>
                <p>Email:</p><input name="email" type="text" required><br>
                <p>Name:</p><input name="name" type="text" required><br>
                <p>Address:</p><input name="address" type="text" required><br>
                <p>Phone:</p><input name="phone" type="text" required><br>
                <button type="submit">Submit</button>
            </form>           
            
        </div>
        
        <?php
            echo "<div id='productList'>";
            echo "<p>Order:</p>"; 
            session_start();
            $totalPrice = 0;
            foreach ($_SESSION["productList"] as $product){
                echo "<p>  ".$product["quantity"]."  ".$product["name"]."  <span style='color:red;' >PRICE</span>: ".($product["price"]*$product["quantity"])."</p>";  
                $totalPrice = $totalPrice + ($product["price"]*$product["quantity"]);
            }
            echo "<br><br><p>Total Price: $".$totalPrice."</p>";
            echo "</div>";

        ?>
        
    </body>
</html>

