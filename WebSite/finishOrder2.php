<?php
    require 'dbConnector.php';
    include "ChromePhp.php";

    try{
        session_start();
        //INSERT NEW TXN
        $conn = connect_db();
        $status = 'Submitted';
        $shipdate = date('y-m-d h:i:s');
        $txnType = 'Sale';
        $barcode = '111222333444';
        $createddate = date('y-m-d h:i:s');
        $eo = 0;
        
        //Get notes
        $notes = "ADDRESS: " . $_GET["address"] . "PHONE: " . $_GET["phone"] . " NAME: " . $_GET["name"] . " EMAIL: " . $_GET["email"]; 
        echo $notes;
        //Get deliveryID
        $distanceCost = 100;
        $vehicleType = "Courier";
        $stmt = $conn->prepare("INSERT INTO delivery(distanceCost, vehicleType, notes) VALUES (:distanceCost, :vehicleType, :notes )");
        $stmt->bindParam(":distanceCost", $distanceCost);
        $stmt->bindParam(":vehicleType", $vehicleType);
        $stmt->bindParam(":notes", $notes);
        $stmt->execute();
        $stmt->closeCursor();
        
        $stmt = $conn->prepare("select MAX(deliveryID) from delivery");
        $stmt->execute();
        $deliveryID = $stmt->fetch();
        $stmt->closeCursor();
            
        
        $stmt = $conn->prepare("insert into txn (siteIDTo, siteIDFrom, status, shipDate, txnType, barCode, createdDate, deliveryID, emergencyDelivery) values (:siteIDTo, :siteIDFrom, :status, :shipDate, :txnType, :barCode, :createdDate, :deliveryID, :emergencyDelivery)");
        $stmt->bindParam(":siteIDTo", $_SESSION["location"]);
        $stmt->bindParam(":siteIDFrom", $_SESSION["location"]);
        $stmt->bindParam(":status", $status);
        $stmt->bindParam(":shipDate", $shipdate);
        $stmt->bindParam(":txnType", $txnType);
        $stmt->bindParam(":barCode", $barcode);
        $stmt->bindParam(":createdDate", $createddate);
        $stmt->bindParam(":deliveryID", $deliveryID[0]);
        $stmt->bindParam(":emergencyDelivery", $eo);
        $stmt->execute();
        $stmt->closeCursor();
    } catch (PDOException $e) {
        echo "*********** ERROR: " . $e->getMessage();
    } finally {
        //INSERT PRODUCT LIST TO NEW TXN
        //header("finishOrder2.php");
        try{
            $stmt = $conn->prepare("select MAX(txnID) from txn");
            $stmt->execute();
            $txnID = $stmt->fetch();
            $stmt->closeCursor();
        } catch (PDOException $e) {
            echo "*** ERROR: " . $e->getMessage();

        } finally {
            //insert product list to txn
            foreach ($_SESSION["productList"] as $product){
                $itemID = $product["itemid"];
                $quantity = $product["quantity"];

                try{
                    $stmt = $conn->prepare("insert into txnitems values (:txnID, :itemID, :quantity)");
                    $stmt->bindParam(":txnID", $txnID[0]);
                    $stmt->bindParam(":itemID", $itemID);
                    $stmt->bindParam(":quantity", $quantity);
                    $stmt->execute();
                    $stmt->closeCursor();
                } catch (PDOException $e) {
                    echo "*** ERROR: " . $e->getMessage();
                } finally {
                    header("location: index.php");
                    
                }
            }
        }
    }
?>