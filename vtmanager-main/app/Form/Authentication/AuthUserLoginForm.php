<?php

namespace App\Form\Authentication;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Validator;

class AuthUserLoginForm
{
    /**
     * validate
     *
     * @param \Illuminate\Http\Request $request
     */
    public function validate(Request $request)
    {
        return Validator::make($request->all(), [
            'user_id' => [
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
            'user_id.required' => 'USER ID chưa được nhập',
            'password.required' => 'Mật khẩu chưa được nhập',
            'language.required' => 'LANGUAGE không được chọn',
        ]);
    }
}
