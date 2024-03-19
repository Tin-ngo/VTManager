<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Product extends Model
{
    use HasFactory;

    protected $table = 'product';
    protected $primaryKey = 'productId';
    public $incrementing = false;
    public $timestamps = false;
    /**
     * The attributes that are mass assignable.
     *
     * @var array
     */
    protected $fillable = [
        'ownerId',
        'productId',
        'productTypeId',
        'productName',
        'unitPrice',
        'description',
        'image'
    ];

    public function getProducts($ownerId)
    {
        return $this->select(['productId', 'productName', 'image', 'unitPrice', 'productTypeId', 'productStatus'])
            ->where('ownerId', $ownerId)
            ->orderBy('productTypeId')
            ->orderBy('productId')
            ->get();
    }


    public function updateProductStatus($data)
    {
        $dataUpdate = [];
        try {
            $dataUpdate = [
                'productStatus' => $data["productStatus"],
            ];
            $this->where('ownerId', $data["ownerId"])
                ->where('productId', $data["productId"])
                ->update($dataUpdate);
        } catch (\Throwable $th) {
            throw $th;
        }
        return true;
    }
}
