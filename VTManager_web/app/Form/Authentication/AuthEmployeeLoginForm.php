<?php

namespace App\Form\Authentication;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Validator;

class AuthEmployeeLoginForm
{
    /**
     * validate
     *
     * @param \Illuminate\Http\Request $request
     */
    public function validate(Request $request)
    {
        return Validator::make($request->all(), [
            'owner_id' => [
                'bail',
                'required',
                'min:3',
                'max:150'
            ],
            'employee_id' => [
                'bail',
                'required',
                'min:3',
                'max:150'
            ],
            'password' => [
                'bail',
                'required',
                'min:6',
                'max:150'
            ],
            'language' => [
                'required',
            ],
        ],[
            'owner_id.required' => 'OWNER ID chưa được nhập',
            'employee_id.required' => 'EMPLOYEE ID chưa được nhập',
            'password.required' => 'PASSWORD chưa được nhập',
            'language.required' => 'LANGUAGE không được chọn',
        ]);
    }
}
