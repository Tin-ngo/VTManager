<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
//login
use Tymon\JWTAuth\Facades\JWTAuth;
use Exception;
use Auth;
use Illuminate\Support\Facades\Hash;
use Illuminate\Foundation\Auth\User as Authenticatable;
use Tymon\JWTAuth\Contracts\JWTSubject;

class Employee extends Authenticatable implements JWTSubject
{
    use HasFactory;

    protected $table = 'employee';
    protected $primaryKey = 'employeeId';
    public $incrementing = false;
    public $timestamps = false;
    /**
     * The attributes that are mass assignable.
     *
     * @var array
     */
    protected $fillable = [
        'ownerId',
        'employeeId',
        'employeeClassId',
        'employeeName',
        'birthday',
        'startDate',
        'endDate',
        'password'
    ];

    public function login($request)
    {
        $credentials = [
            'ownerId' => $request->owner_id,
            'employeeId' => $request->employee_id,
            'password' => $request->password
        ];
        $token = Auth::guard('employee')->attempt($credentials);
        if ($token) {
            $user = $this->query()
                ->where('ownerId', $credentials["ownerId"])
                ->where('employeeId', $credentials["employeeId"])
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
            'employeeId' => $this->employeeId,
        ];
    }

    public function getAuthPassword()
    {
        return Hash::make($this->password);
    }



    // end login

    public function getEmployees($request)
    {
        $query = $this->query();
        $query->select([
            'employee.employeeId',
            'employee.employeeClassId',
            'employee.employeeName',
            'employee.birthday',
            'employee.startDate',
            'employee_class.employeeClassName'
        ])
            ->leftJoin('employee_class', function ($join) {
                $join->on('employee.ownerId', 'employee_class.ownerId');
                $join->on('employee.employeeClassId', 'employee_class.employeeClassId');
            })
            ->leftJoin('working_time', function ($join) {
                $join->on('employee.ownerId', 'working_time.ownerId');
                $join->on('employee.employeeId', 'working_time.employeeId');
            });
        if ($request->has('ownerId')) {
            $query->where("employee.ownerId", "=", $request->input('ownerId'));
        }
        if ($request->has('employeeName')) {
            $query->where("employee.employeeName", "LIKE", "%".$request->input('employeeName')."%");
        }
        $query->orderBy('working_time.employeeId');
        return $query->get();
    }
}
