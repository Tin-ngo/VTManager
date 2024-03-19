<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Area extends Model
{
    use HasFactory;

    protected $table = 'area';
    protected $primaryKey = 'areaId';
    public $incrementing = false;
    public $timestamps = false;
    /**
     * The attributes that are mass assignable.
     *
     * @var array
     */
    protected $fillable = [
        'ownerId',
        'areaId',
        'areaName'
    ];

    public function getAreas($ownerId)
    {
        return $this->select()
            ->where('ownerId', $ownerId)
            ->get();
    }
}
