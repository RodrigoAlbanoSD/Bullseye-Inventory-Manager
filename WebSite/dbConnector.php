<?php

function connect_db() {
    $db = new PDO("mysql:host=localhost;dbname=bullseyedb2022", "Rodrigo", "rororo0808");
    $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION); // throw exceptions
    return $db;
}