<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;

class OrderStatusUpdateRequest  extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     *
     * @return bool
     */
    public function authorize()
    {
        return true;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array<string, mixed>
     */
    public function rules()
    {
        return [
            //出荷日
            '*.ship_date' => 'required',
            //出荷予定日
            '*.delivery_date' => 'required',
            //倉庫
            '*.tax_code' => 'required',
            //出荷数
            '*.ship_num1' => 'required',
        ];
    }

    public function messages()
    {
        return [
            'required' => ':attribute が未入力です.',
            'max' => ':attribute 桁数オーバー :max.',
            'alpha_num' => ':attribute 配送リードタイムは半角数値で入力して.',
            'numeric' => ':attribute は半角英数で入力してください.',
            'min' => ':attribute 配送リードタイムは1以上で入力して :min.',
        ];
    }

    public function attributes()
    {
        return [
            'ship_date' => '出荷日',
            'delivery_date' => '出荷予定日',
            'tax_code' => '倉庫',
            'ship_num1' => '出荷数',
        ];
    }

    protected function failedValidation(Validator $validator)
    {
        if ($validator->fails()) {
            throw new HttpResponseException(response()->json([
                'errors' => $validator->errors(),
            ], 402));
        }
    }
}
