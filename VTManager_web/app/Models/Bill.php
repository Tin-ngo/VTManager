<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Support\Facades\DB;

class Bill extends Model
{
    use HasFactory;

    protected $table = 'bill';
    protected $primaryKey = 'billId';
    public $incrementing = false;
    public $timestamps = false;
    /**
     * The attributes that are mass assignable.
     *
     * @var array
     */
    protected $fillable = [
        'ownerId',
        'billId',
        'orderId',
        'dateOfPayment',
        'timeOfPayment',
        'totalPayment',
        'paymentType'
    ];

    public function maxBillId($request)
    {
        $data = $request->all();
        $query = $this->query();
        $query->select(['billId']);
        if (isset($data["ownerId"])) {
            $query->where('ownerId', $data["ownerId"]);
        }
        $data = $query->get()->max('billId');
        return $data != null ? $data + 1 : 1;
    }

    public function addBill($request)
    {
        $data = $request->all();
        $billId = $this->maxBillId($request);
        $dataInsert = [];
        DB::beginTransaction();
        try {
                $dataInsert = [
                    'ownerId' => $data["ownerId"],
                    'billId' => isset($data["billId"]) ? $data["billId"]: $billId,
                    'orderId' => $data["orderId"],
                    'dateOfPayment' => $data["dateOfPayment"],
                    'totalPayment' => $data["totalPayment"],
                    'paymentType' => $data["paymentType"],
                    'timeOfPayment' => $data["timeOfPayment"]
                ];
                $this->insert($dataInsert);
                DB::commit();
            
        } catch (\Throwable $th) {
            DB::rollBack();
            return $th->getMessage();
        }
        return true;
    }
}
