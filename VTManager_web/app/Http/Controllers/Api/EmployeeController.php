<?php

namespace App\Http\Controllers\Api;

use Illuminate\Http\Request;
use App\Http\Controllers\Controller;
use App\Http\Component\ResponseComponent;
use App\Models\Employee;
use App\Models\Area;
use App\Models\Table;
use App\Models\Order;
use App\Models\ProductType;
use App\Models\Product;

class EmployeeController extends Controller
{
    protected $Response;
    protected $employee;
    protected $area;
    protected $table;
    protected $order;
    protected $productType;
    protected $product;
    
    public function __construct()
    {
        $this->Response = new ResponseComponent();
        $this->employee = new Employee();
        $this->area = new Area();
        $this->table = new Table();
        $this->order = new Order();
        $this->productType = new ProductType();
        $this->product = new Product();
    }

    public function getEmployees(Request $request)
    {
        try {
            $result = $this->Response->success([
                'employees' => $this->employee->getEmployees($request)
            ]);

            return $result;
        } catch (\Exception $th) {
            return  $this->Response->customResponse(400, $th->getMessage());
        }
    }


    public function getCommonEmployeeStaff(Request $request)
    {
        $ownerId = $request->all()['ownerId'];
        try {
            $result = $this->Response->success([
                'areas' => $this->area->getAreas($ownerId),
                'tableOrders' => $this->table->getTableOrders($ownerId),
                'tables' => $this->table->getTables($ownerId),
                'orders' => $this->order->getOrder($request)
            ]);

            return $result;
        } catch (\Exception $th) {
            return  $this->Response->customResponse(400, $th->getMessage());
        }
    }


    public function getCommonEmployeeOrder($ownerId)
    {
        try {
            $result = $this->Response->success([
                'areas' => $this->area->getAreas($ownerId),
                'product_type' => $this->productType->getProductTypes($ownerId),
                'products' => $this->product->getProducts($ownerId)
            ]);

            return $result;
        } catch (\Exception $th) {
            return  $this->Response->customResponse(400, $th->getMessage());
        }
    }

}
