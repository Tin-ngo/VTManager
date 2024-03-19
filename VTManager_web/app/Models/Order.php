<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Support\Facades\DB;

class Order extends Model
{
    use HasFactory;

    protected $table = 'order';
    protected $primaryKey = 'orderId';
    public $incrementing = false;
    public $timestamps = false;
    /**
     * The attributes that are mass assignable.
     *
     * @var array
     */
    protected $fillable = [
        'ownerId',
        'orderId',
        'tableId',
        'status',
        'productId',
        'quantity',
        'dateOrder',
        'timeOrder',
        'isPaid'
    ];

    function convertToPaddedString($number, $length)
    {
        return str_pad($number, $length, '0', STR_PAD_LEFT);
    }

    public function maxOrderId($request)
    {
        $data = $request->all();
        $query = $this->query();
        $query->select(['orderId']);
        if (isset($data[0]["ownerId"])) {
            $query->where('ownerId', $data[0]["ownerId"]);
        }
        $data = $query->get()->max('orderId');
        return $data != null ? $data + 1 : 1;
    }

    public function addOrders($request)
    {
        $data = $request->all();
        $orderId = $this->convertToPaddedString($this->maxOrderId($request), 6);
        $dataInsert = [];
        DB::beginTransaction();
        try {
            for ($index = 0; $index < Count($data); $index++) {
                $dataInsert = [
                    'ownerId' => $data[$index]["ownerId"],
                    'orderId' => isset($data[$index]["orderId"]) ? $data[$index]["orderId"] : $orderId,
                    'tableId' => $data[$index]["tableId"],
                    'areaId' => $data[$index]["areaId"],
                    'status' => $data[$index]["status"],
                    'productId' => $data[$index]["productId"],
                    'quantity' => $data[$index]["quantity"],
                    'dateOrder' => $data[$index]["dateOrder"],
                    'timeOrder' => str_pad($data[$index]["timeOrder"], 6, '0', STR_PAD_LEFT),
                    'isPaid' => $data[$index]["isPaid"],
                ];
                $this->insert($dataInsert);
            }
            DB::commit();
        } catch (\Throwable $th) {
            DB::rollBack();
            return $th->getMessage();
        }
        return $orderId;
    }

    public function deleteOrder($request)
    {
        $data = $request;
        $query = $this->query();
        if (isset($data['ownerId']) 
                && isset($data['orderId']) 
                && isset($data['tableId']) 
                && isset($data['productId']) 
                && isset($data['dateOrder']) 
                && isset($data['timeOrder']) 
                && isset($data['areaId'])) {
            $query->where('ownerId', $data['ownerId']);
            $query->where('orderId', $data['orderId']);
            $query->where('tableId', $data['tableId']);
            $query->where('productId', $data['productId']);
            $query->where('dateOrder', $data['dateOrder']);
            $query->where('timeOrder', $data['timeOrder']);
            $query->where('areaId', $data['areaId']);
        }
        return $query->delete();
    }

    public function deleteOrders($data)
    {
        $statusDelete = 0;
        try {
            if ($this->isNestedArray($data)) {
                $tableIds = collect($data)->pluck('tableId')->toArray();
                $ownerIds = collect($data)->pluck('ownerId')->toArray();
                $orderIds = collect($data)->pluck('orderId')->toArray();
                $productIds = collect($data)->pluck('productId')->toArray();
                $dateOrders = collect($data)->pluck('dateOrder')->toArray();
                $timeOrders = collect($data)->pluck('timeOrder')->toArray();
                $areaId = collect($data)->pluck('areaId')->toArray();
        
                // Sử dụng whereIn để áp dụng điều kiện cho nhiều bản ghi
                $result = $this->whereIn('tableId', $tableIds)
                    ->whereIn('ownerId', $ownerIds)
                    ->whereIn('orderId', $orderIds)
                    ->whereIn('productId', $productIds)
                    ->whereIn('dateOrder', $dateOrders)
                    ->whereIn('timeOrder', $timeOrders)
                    ->whereIn('areaId', $areaId)
                    ->where('status', $statusDelete)
                    ->delete(); // Sử dụng phương thức delete để xóa bản ghi thay vì update
            } else {
                $result = $this->where('tableId', $data["tableId"])
                    ->where('ownerId', $data["ownerId"])
                    ->where('orderId', $data["orderId"])
                    ->where('productId', $data["productId"])
                    ->where('dateOrder', $data["dateOrder"])
                    ->where('timeOrder', $data["timeOrder"])
                    ->where('areaId', $data["areaId"])
                    ->where('status', $statusDelete)
                    ->delete(); // Sử dụng phương thức delete để xóa bản ghi thay vì update
            }
        
            // Kiểm tra xem có bản ghi nào bị ảnh hưởng hay không
            if ($result === false) {
                throw new \Exception('Không thể xóa bản ghi.');
            }
        
            return true;
        } catch (\Throwable $th) {
            // Xử lý lỗi và trả về false
            return false;
        }
    }

    public function reduceQuantity($request)
    {
        $data = $request->all();
        $dataUpdate = [];
        try {
            $dataUpdate = [
                'quantity' => (int)$data["quantity"] - 1,
            ];
            $this->where('tableId', $data["tableId"])
                ->where('ownerId', $data["ownerId"])
                ->where('productId', $data["productId"])
                ->where('dateOrder', $data["dateOrder"])
                ->where('timeOrder', $data["timeOrder"])
                ->where('areaId', $data["areaId"])
                ->update($dataUpdate);
        } catch (\Throwable $th) {
            throw $th;
        }
    }

    public function getOrders($ownerId)
    {
        return $this->select()
            ->where('ownerId', $ownerId)
            ->where('isPaid', 0)
            ->get();
    }

    public function getOrder($request)
    {
        $query = $this->select([
            'order.*',
            'product.*',
            'table.status as statusTable',
            'table.tableId',
            'table.areaId',
            'table.maxCapacity',
            'area.areaName',
            'MST_vat.*',
            'MST_vat.vatName',
            'MST_vat.vatValue%'
        ])
            ->leftJoin('product', function ($join) {
                $join->on('order.ownerId', '=', 'product.ownerId');
                $join->on('order.productId', '=', 'product.productId');
            })
            ->leftJoin('table', function ($join) {
                $join->on('order.ownerId', '=', 'table.ownerId');
                $join->on('order.tableId', '=', 'table.tableId');
                $join->on('order.areaId', '=', 'table.areaId');
            })
            ->leftJoin('area', function ($join) {
                $join->on('order.ownerId', '=', 'area.ownerId');
                $join->on('table.areaId', '=', 'area.areaId');
            })
            ->leftJoin('MST_vat', function ($join) {
                $join->on('product.vatId', '=', 'MST_vat.vatId');
            });
        if ($request->has('ownerId')) {
            $query->where('order.ownerId', $request->input('ownerId'));
        }
        if ($request->has('orderId')) {
            $query->where('order.orderId', $request->input('orderId'));
        }
        if ($request->has('tableId')) {
            $query->where('order.tableId', $request->input('tableId'));
        }
        if ($request->has('areaId')) {
            $query->where('order.areaId', $request->input('areaId'));
        }
        if ($request->has('productId')) {
            $query->where('order.productId', $request->input('productId'));
        }
        $query->where('order.isPaid', 0);
        $query->orderBy('order.orderId')->orderBy('order.timeOrder');
        return $query->get();
    }

    // đổi bàn dựa vào orderId
    public function switchTable($data)
    {
        $dataUpdate = [];
        try {
            $dataUpdate = [
                'tableId' => $data["tableId2"],
                'areaId' => $data["areaId2"],
            ];
            $this->where('ownerId', $data["ownerId"])
                ->where('tableId', $data["tableId"])
                ->where('areaId', $data["areaId"])
                ->where('isPaid', 0)
                ->update($dataUpdate);
        } catch (\Throwable $th) {
            throw $th;
        }
        return true;
    }

    // public function updateSTatus($data){
    // $dataUpdate = [];
    // try {
    //     $dataUpdate = [
    //         'status' => $data["status"],
    //     ];
    //     $this->where('tableId', $data["tableId"])
    //         ->where('ownerId', $data["ownerId"])
    //         ->where('productId', $data["productId"])
    //         ->where('dateOrder', $data["dateOrder"])
    //         ->where('timeOrder', $data["timeOrder"])
    //         ->update($dataUpdate);
    // } catch (\Throwable $th) {
    //     throw $th;
    // }
    // return true;
    // }
    // public function updateStatus(array $data)
    // {
    //     try {
    //         if ($this->isNestedArray($data)) {
    //             $tableIds = collect($data)->pluck('tableId')->toArray();
    //             $ownerIds = collect($data)->pluck('ownerId')->toArray();
    //             $productIds = collect($data)->pluck('productId')->toArray();
    //             $dateOrders = collect($data)->pluck('dateOrder')->toArray();
    //             $timeOrders = collect($data)->pluck('timeOrder')->toArray();
    //             $areaId = collect($data)->pluck('areaId')->toArray();
    //             $statuses = collect($data)->pluck('status')->toArray();

    //             // Sử dụng whereIn để áp dụng điều kiện cho nhiều bản ghi
    //             $this->whereIn('tableId', $tableIds)
    //                 ->whereIn('ownerId', $ownerIds)
    //                 ->whereIn('productId', $productIds)
    //                 ->whereIn('dateOrder', $dateOrders)
    //                 ->whereIn('timeOrder', $timeOrders)
    //                 ->whereIn('areaId', $areaId)
    //                 ->update(['status' => $statuses[0]]); // Giả sử tất cả các bản ghi cần cập nhật có cùng một trạng thái
    //         } else {
    //             $dataUpdate = [];
    //             try {
    //                 $dataUpdate = [
    //                     'status' => $data["status"],
    //                 ];
    //                 $this->where('tableId', $data["tableId"])
    //                     ->where('ownerId', $data["ownerId"])
    //                     ->where('productId', $data["productId"])
    //                     ->where('dateOrder', $data["dateOrder"])
    //                     ->where('timeOrder', $data["timeOrder"])
    //                     ->where('areaId', $data["areaId"])
    //                     ->update($dataUpdate);
    //             } catch (\Throwable $th) {
    //                 throw $th;
    //             }
    //         }
    //         return true;
    //     } catch (\Throwable $th) {
    //         throw $th;
    //     }
    // }
    public function updateStatus(array $data)
    {
        try {
            if ($this->isNestedArray($data)) {
                $tableIds = collect($data)->pluck('tableId')->toArray();
                $ownerIds = collect($data)->pluck('ownerId')->toArray();
                $orderIds = collect($data)->pluck('orderId')->toArray();
                $productIds = collect($data)->pluck('productId')->toArray();
                $dateOrders = collect($data)->pluck('dateOrder')->toArray();
                $timeOrders = collect($data)->pluck('timeOrder')->toArray();
                $areaId = collect($data)->pluck('areaId')->toArray();
                $statuses = collect($data)->pluck('status')->toArray();

                // Sử dụng whereIn để áp dụng điều kiện cho nhiều bản ghi
                $result = $this->whereIn('tableId', $tableIds)
                    ->whereIn('ownerId', $ownerIds)
                    ->whereIn('orderId', $orderIds)
                    ->whereIn('productId', $productIds)
                    ->whereIn('dateOrder', $dateOrders)
                    ->whereIn('timeOrder', $timeOrders)
                    ->whereIn('areaId', $areaId)
                    ->update(['status' => $statuses[0]]); // Giả sử tất cả các bản ghi cần cập nhật có cùng một trạng thái
            } else {
                $result = $this->where('tableId', $data["tableId"])
                    ->where('ownerId', $data["ownerId"])
                    ->where('orderId', $data["orderId"])
                    ->where('productId', $data["productId"])
                    ->where('dateOrder', $data["dateOrder"])
                    ->where('timeOrder', $data["timeOrder"])
                    ->where('areaId', $data["areaId"])
                    ->update(['status' => $data["status"]]);
            }

            // Kiểm tra xem có bản ghi nào bị ảnh hưởng hay không
            if ($result === false) {
                throw new \Exception('Không thể cập nhật trạng thái.');
            }

            return true;
        } catch (\Throwable $th) {
            // Xử lý lỗi và trả về false
            return false;
        }
    }

    function isNestedArray($array)
    {
        return count(array_filter($array, 'is_array')) > 0;
    }

    // cập nhật isPaid thành 1 là đã thanh toán
    // public function updateStatusPaid($data)
    // {
    //     $dataUpdate = [];
    //     try {
    //         $dataUpdate = [
    //             'isPaid' => 1,
    //         ];
    //         $this->where('tableId', $data["tableId"])
    //             ->where('ownerId', $data["ownerId"])
    //             ->where('productId', $data["productId"])
    //             ->update($dataUpdate);
    //     } catch (\Throwable $th) {
    //         throw $th;
    //     }
    //     return true;
    // }

    public function updateStatusPaid($data)
    {
        try {
            if ($this->isNestedArray($data)) {
                $tableIds = collect($data)->pluck('tableId')->toArray();
                $areaIds = collect($data)->pluck('areaId')->toArray();
                $ownerIds = collect($data)->pluck('ownerId')->toArray();
                $productIds = collect($data)->pluck('productId')->toArray();

                // Sử dụng whereIn để áp dụng điều kiện cho nhiều bản ghi
                $this->whereIn('tableId', $tableIds)
                    ->whereIn('areaId', $areaIds)
                    ->whereIn('ownerId', $ownerIds)
                    ->whereIn('productId', $productIds)
                    ->update(['isPaid' => 1]); 
            } else {
                $dataUpdate = [];
                try {
                    $dataUpdate = [
                        'isPaid' => 1,
                    ];
                    $this->where('tableId', $data["tableId"])
                    ->where('areaId', $data["areaId"])
                    ->where('ownerId', $data["ownerId"])
                    ->where('productId', $data["productId"])
                    ->update($dataUpdate);
                } catch (\Throwable $th) {
                    throw $th;
                }
            }
            return true;
        } catch (\Throwable $th) {
            throw $th;
        }


    }


}
