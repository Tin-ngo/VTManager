<?php

namespace App\Http\Controllers\Api;

use Illuminate\Http\Request;
use App\Http\Controllers\Controller;
use App\Http\Component\ResponseComponent;
use App\Models\Table;

class TableController extends Controller
{
    protected $Response;
    protected $table;
    
    public function __construct()
    {
        $this->Response = new ResponseComponent();
        $this->table = new Table();
    }

    public function getTables($ownerId)
    {
        try {
            $result = $this->Response->success([
                'tables' => $this->table->getTables($ownerId)
            ]);

            return $result;
        } catch (\Exception $th) {
            return  $this->Response->customResponse(400, $th->getMessage());
        }
    }

    public function getTableOrders($ownerId)
    {
        try {
            $result = $this->Response->success([
                'tableOrders' => $this->table->getTableOrders($ownerId)
            ]);

            return $result;
        } catch (\Exception $th) {
            return  $this->Response->customResponse(400, $th->getMessage());
        }
    }

    public function updateStatus(Request $request)
    {
        try {
            $result = $this->Response->success([
                'result' => $this->table->updateSTatus($request)
            ]);

            return $result;
        } catch (\Exception $th) {
            return  $this->Response->customResponse(400, $th->getMessage());
        }
    }
}
