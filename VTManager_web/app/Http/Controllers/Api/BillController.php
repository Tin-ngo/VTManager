<?php

namespace App\Http\Controllers\Api;

use Illuminate\Http\Request;
use App\Http\Controllers\Controller;
use App\Http\Component\ResponseComponent;
use App\Models\Bill;

class BillController extends Controller
{
    protected $Response;
    protected $bill;
    
    public function __construct()
    {
        $this->Response = new ResponseComponent();
        $this->bill = new Bill();
    }

    public function addBill(Request $request)
    {
        try {
            $result = $this->Response->success([
                'result' => $this->bill->addBill($request)
            ]);

            return $result;
        } catch (\Exception $th) {
            return  $this->Response->customResponse(400, $th->getMessage());
        }
    }
}
