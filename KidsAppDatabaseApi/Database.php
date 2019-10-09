<?php

/**
 * Database Class.
 * @version 1.0
 * @author inesa
 */
class Database
{
    private $database = "KidsApp";
    private $username = null;
    private $password = null;
    public $dbconnection = null;

    /**
     * Constructor for Database class
     * @param string $host
     * @param string $dbname
     * @param string $username
     * @param string $password
     */
    function __construct($host, $dbname, $username = null, $password = null){
        if (is_null($username) && is_null($password)){
            $connection = array('Database' => $dbname);
        } else {
            $connection = array('Database' => $dbname, 'UID' => $username, 'PWD' => $password);
        }
        $this->createDatabase($host,$connection);
    }

    /**
     * Creates a connection using host and connection settings
     * @param mixed $host
     * @param mixed $connection
     */
    function createDatabase($host, $connection){
        $this->dbconnection = sqlsrv_connect($host,$connection);
        if ($this->dbconnection == false){
            printf("Connection unsuccessful");
        }
    }

    /**
     * Returns Query result as JSON
     * @param mixed $query
     * @param mixed $params
     * @return string
     */
    function returnQueryAsJson($query, $params = null){
        return json_encode(is_null($params) ? $this->returnQuery($query) : $this->returnQuery($query,$params));
    }

    /**
     * Runs a Query and returns results as Array of multiple records or a single record.
     * @param string $query
     * @param array $params
     * @return array
     */
    function returnQuery($query, $params = null){
        $resource = is_null($params) ? sqlsrv_query($this->getConnection(), $query) : sqlsrv_query($this->getConnection(), $query, $params);

        if ($resource == false){
            die(print_r(sqlsrv_errors(),true));
        }

        $numRows = sqlsrv_num_rows($resource);
        $values = array();
        while ($row = sqlsrv_fetch_array($resource,SQLSRV_FETCH_BOTH)){
            if ($numRows <= 1){
                $values = $row;
                settype($values,"array");
                break;
            } else {
                array_push($values,$row);
            }
        }
        sqlsrv_free_stmt($resource);
        return $values;
    }


    function getConnection(){
        if (is_null($this->dbconnection)){
            throw new Exception('No Connection');
        } else {
            return $this->dbconnection;
        }
    }

}