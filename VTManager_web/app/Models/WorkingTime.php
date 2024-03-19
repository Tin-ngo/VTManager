<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class WorkingTime extends Model
{
    use HasFactory;

    protected $table = 'working_time';
    public $incrementing = false;
    public $timestamps = false;
    /**
     * The attributes that are mass assignable.
     *
     * @var array
     */
    protected $fillable = [
        'ownerId',
        'dateOfWeek',
        'idWorkingTime',
        'employeeId',
        'salaryId',
        'startTime',
        'endTime'
    ];

    public function checkorkingTime($request)
    {
        $data = $request->all();
        return $this->select()
            ->where('ownerId', $data['ownerId'])
            ->where('dateOfWeek', $data['dateOfWeek'])
            ->where('employeeId', $data['employeeId'])
            ->where('startTime', '<=', $data['timeWorking'])
            ->where('endTime', '>=', $data['timeWorking'])
            ->get();
        // $query = $this->query();
        // $query->select([
        //     'employee.employeeId',
        //     'employee.employeeClassId',
        //     'employee.employeeName',
        //     'employee.birthday',
        //     'employee.startDate',
        //     'employee_class.employeeClassName'
        // ])
        //     ->leftJoin('employee_class', function ($join) {
        //         $join->on('employee.ownerId', 'employee_class.ownerId');
        //         $join->on('employee.employeeClassId', 'employee_class.employeeClassId');
        //     });
        // $query->where('employee.ownerId', $ownerId);
        // return $query->get();
    }
}
