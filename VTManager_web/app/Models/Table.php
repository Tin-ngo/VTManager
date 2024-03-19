<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Table extends Model
{
    use HasFactory;

    protected $table = 'table';
    protected $primaryKey = 'tableId';
    public $incrementing = false;
    public $timestamps = false;
    /**
     * The attributes that are mass assignable.
     *
     * @var array
     */
    protected $fillable = [
        'ownerId',
        'tableId',
        'areaId',
        'status'
    ];

    public function getTables($ownerId)
    {
        $query = $this->query();
        $query->select()
            ->leftJoin('area', function ($join) {
                $join->on('table.ownerId', 'area.ownerId');
                $join->on('table.areaId', 'area.areaId');
            });
        $query->where('table.ownerId', $ownerId);
        $query->orderBy('table.areaId', 'ASC')->orderBy('table.tableId', 'ASC');
        return $query->get();
    }

    public function getTableOrders($ownerId)
    {
        $query = $this->query();
        $query->select([
            'table.tableId',
            'table.maxCapacity',
            'table.status AS statusTable',
            'area.areaId',
            'area.areaName',
            'order.orderId',
            'order.status AS statusOrder',
            'order.quantity',
            'order.dateOrder',
            'order.timeOrder',
            'order.statusTableJoin',
            'order.isPaid',
            'product.productId',
            'product.productName',
            'product.unitPrice',
        ])
            ->leftJoin('order', function ($join) {
                $join->on('table.ownerId', 'order.ownerId');
                $join->on('table.tableId', 'order.tableId');
                $join->where('order.isPaid', 0);
            })
            ->leftJoin('area', function ($join) {
                $join->on('table.ownerId', 'area.ownerId');
                $join->on('table.areaId', 'area.areaId');
            })
            ->leftJoin('product', function ($join) {
                $join->on('table.ownerId', 'product.ownerId');
                $join->on('order.productId', 'product.productId');
            });
        // $query->orderBy('order.timeOrder', 'ASC')->orderBy('table.tableId', 'DESC');
        $query->orderBy('table.areaId', 'ASC')->orderBy('table.tableId', 'ASC');
        $query->where('table.ownerId', $ownerId);
        return $query->get();

    }

    public function updateStatus($request)
    {
        $data = $request->all();
        $dataUpdate = [];

        try {
            $dataUpdate = [
                'status' => $data["status"],
            ];

            $result = $this->where('tableId', $data["tableId"])
                ->where('areaId', $data["areaId"])
                ->where('ownerId', $data["ownerId"])
                ->update($dataUpdate);

            // Kiểm tra kết quả của phương thức update
            if ($result === false) {
                throw new \Exception('Không thể cập nhật trạng thái.');
            }

            return true; // Trả về true khi thành công
        } catch (\Throwable $th) {
            // Trả về false khi có lỗi
            return false;
        }
    }
      
}
