<?php

namespace App\Models;

use Carbon\Carbon;
use Exception;
use Auth;
use Tymon\JWTAuth\Facades\JWTAuth;
use Illuminate\Support\Facades\Hash;
use Tymon\JWTAuth\Contracts\JWTSubject;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Foundation\Auth\User as Authenticatable;

class Admin extends Authenticatable implements JWTSubject
{
    use HasFactory;

    protected $table = 'MST_admin';
    protected $primaryKey = 'adminId';

    public $timestamps = false;
    public $incrementing = false;

    /**
     * The attributes that are mass assignable.
     *
     * @var array
     */
    protected $fillable = [
        'ownerId',
        'adminId',
        'adminName',
        'adminPassword',
        'shopAdress',
        'shopName',
        'startDate',
    ];

    public function login($request)
    {
        $credentials = [
            'adminId' => $request->user_id,
            'password' => $request->password
        ];
        $token = Auth::guard('admin')->attempt($credentials);
        if ($token) {
            $user = $this->query()
                ->where('adminId', $credentials["adminId"])
                ->first();
            return [
                'token' => $token,
                'user' => $user,
            ];
        }else {
            throw new Exception('Thông tin đăng nhập không đúng');
        }
    }

    public function getJWTIdentifier()
    {
        return $this->getKey();
    }

    /**
     * Return a key value array, containing any custom claims to be added to the JWT.
     *
     * @return array
     */
    public function getJWTCustomClaims()
    {
        return [
            'ownerId' => $this->ownerId,
            'adminId' => $this->adminId,
        ];
    }

    public function getAuthPassword()
    {
        return Hash::make($this->adminPassword);
    }
    public function getAll()
    {
        return $this->all();
    }
}
