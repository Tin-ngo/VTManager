<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class ProductType extends Model
{
    use HasFactory;

    protected $table = 'product_type';
    protected $primaryKey = 'productTypeId';
    public $incrementing = false;
    public $timestamps = false;
    /**
     * The attributes that are mass assignable.
     *
     * @var array
     */
    protected $fillable = [
        'ownerId',
        'productTypeId',
        'productTypeName',
        'description'
    ];

    public function getProductTypes($ownerId)
    {
        return $this->select()
            ->where('ownerId', $ownerId)
            ->get();
    }
}
