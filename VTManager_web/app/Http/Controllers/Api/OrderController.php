<?php

namespace App\Http\Controllers\Api;

use Illuminate\Http\Request;
use App\Http\Controllers\Controller;
use App\Http\Component\ResponseComponent;
use App\Models\Order;
use App\Models\Table;
use Illuminate\Support\Facades\DB;

class OrderController extends Controller
{
    protected $Response;
    protected $order;
    protected $table;

    public function __construct()
    {
        $this->Response = new ResponseComponent();
        $this->order = new Order();
        $this->table = new Table();
    }

    public function getOrders($ownerId)
    {
        try {
            $result = $this->Response->success([
                'orders' => $this->order->getOrders($ownerId)
            ]);

            return $result;
        } catch (\Exception $th) {
            return $this->Response->customResponse(400, $th->getMessage());
        }
    }

    public function getOrder(Request $request)
    {
        try {
            $result = $this->Response->success([
                'orders' => $this->order->getOrder($request)
            ]);

            return $result;
        } catch (\Exception $th) {
            return $this->Response->customResponse(400, $th->getMessage());
        }
    }

    public function switchTable(Request $request)
    {
        try {
            $result = $this->Response->success([
                'result' => $this->order->switchTable($request->all())
            ]);
            return $result;
        } catch (\Exception $th) {
            return $this->Response->customResponse(400, $th->getMessage());
        }
    }

    public function getCommonOrders($ownerId)
    {
        try {
            $result = $this->Response->success([
                'tableOrders' => $this->table->getTableOrders($ownerId),
                'orders' => $this->order->getOrders($ownerId)
            ]);

            return $result;
        } catch (\Exception $th) {
            dd(12121212);
            return $this->Response->customResponse(400, $th->getMessage());
        }
    }

    public function addOrders(Request $request)
    {
        try {
            $result = $this->Response->success([
                'result' => $this->order->addOrders($request)
            ]);

            return $result;
        } catch (\Exception $th) {
            return $this->Response->customResponse(400, $th->getMessage());
        }
    }

    public function updateOrder(Request $request)
    {
        $data = $request->all();
        DB::beginTransaction();
        try {
            for ($i = 0; $i < count($data); $i++) {
                $this->order->deleteOrder($data[$i]);
            }
            $this->order->addOrders($request);
            DB::commit();
            return $this->Response->success();
        } catch (\Throwable $th) {
            dd(111);
            return $this->Response->customResponse(400, $th->getMessage());
        }
    }

    public function deleteOrder(Request $request)
    {
        try {
            $result = $this->Response->success([
                'result' => $this->order->deleteOrder($request)
            ]);

            return $result;
        } catch (\Exception $th) {
            return $this->Response->customResponse(400, $th->getMessage());
        }
    }

    public function deleteOrders(Request $request)
    {
        try {
            $result = $this->Response->success([
                'result' => $this->order->deleteOrders($request->all())
            ]);

            return $result;
        } catch (\Exception $th) {
            return $this->Response->customResponse(400, $th->getMessage());
        }
    }

    public function reduceQuantity(Request $request)
    {
        try {
            $result = $this->Response->success([
                'result' => $this->order->reduceQuantity($request)
            ]);

            return $result;
        } catch (\Exception $th) {
            return $this->Response->customResponse(400, $th->getMessage());
        }
    }

    // cập nhật status order 1
    public function updateStatus(Request $request)
    {
        try {
            $result = $this->Response->success([
                'result' => $this->order->updateStatus($request->all())
            ]);

            return $result;
        } catch (\Exception $th) {
            return $this->Response->customResponse(400, $th->getMessage());
        }
    }

    // cập nhật status order - nhiều
    // public function updateStatusOrders(Request $request)
    // {
    //     $data = $request->all();
    //     DB::beginTransaction();
    //     try {
    //         for ($i=0; $i < count($data); $i++) {
    //             $this->order->updateStatus($data[$i]);
    //         }
    //         DB::commit();
    //         return $this->Response->success();
    //     } catch (\Throwable $th) {
    //         return  $this->Response->customResponse(400, $th->getMessage());
    //     }
    // }
    public function updateStatusOrders(Request $request)
    {
        $data = $request->all();
        DB::beginTransaction();
        try {
            $result = $this->order->updateStatus($data); // Gọi phương thức mới chỉ cần một lần

            DB::commit();
            if($result == true){
                return $this->Response->success(['results' => true]);
            }else{
                return $this->Response->success(['results' => false]);
            }
        } catch (\Throwable $th) {
            DB::rollBack();
            return  $this->Response->customResponse(400, $th->getMessage());
        }
    }

    public function updateStatusPaid(Request $request)
    {
        // $data = $request->all();
        // dd($data[0]);
        // try {
        //     $result = $this->Response->success([
        //         'result' => $this->order->updateStatusPaid($request)
        //     ]);

        //     return $result;
        // } catch (\Exception $th) {
        //     return  $this->Response->customResponse(400, $th->getMessage());
        // }
        $data = $request->all();
        DB::beginTransaction();
        try {
            // for ($i = 0; $i < count($data); $i++) {
            //     $this->order->updateStatusPaid($data[$i]);
            // }
            $result = $this->order->updateStatusPaid($data);
            DB::commit();

            if($result == true){
                return $this->Response->success(['result' => true]);
            }else{
                return $this->Response->success(['result' => false]);
            }
        } catch (\Throwable $th) {
            dd(111);
            return $this->Response->customResponse(400, $th->getMessage());
        }
    }
}
