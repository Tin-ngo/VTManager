<?php

namespace App\Http\Controllers\Api;

use Illuminate\Http\Request;
use App\Http\Controllers\Controller;
use App\Http\Component\ResponseComponent;
use App\Models\ProductType;
use App\Models\Product;

class ProductController extends Controller
{
    protected $Response;
    protected $productType;
    protected $product;
    
    public function __construct()
    {
        $this->Response = new ResponseComponent();
        $this->productType = new ProductType();
        $this->product = new Product();
    }

    public function getProductTypes($ownerId)
    {
        try {
            $result = $this->Response->success([
                'product_type' => $this->productType->getProductTypes($ownerId)
            ]);

            return $result;
        } catch (\Exception $th) {
            return  $this->Response->customResponse(400, $th->getMessage());
        }
    }

    public function getProducts($ownerId)
    {
        try {
            $result = $this->Response->success([
                'products' => $this->product->getProducts($ownerId)
            ]);

            return $result;
        } catch (\Exception $th) {
            return  $this->Response->customResponse(400, $th->getMessage());
        }
    }

    public function updateProductStatus(Request $request)
    {
        $data = $request->all();
        try {
            $result = $this->Response->success([
                'result' => $this->product->updateProductStatus($data)
            ]);

            return $result;
        } catch (\Exception $th) {
            return  $this->Response->customResponse(400, $th->getMessage());
        }
    }
}
