<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;

class OrderCorrectionUpdateRequest  extends FormRequest
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
            '*.order_number' => 'required',
            //出荷予定日
            '*.ship_date' => 'required',
            //倉庫
            '*.delivery_date' => 'required',
            //出荷数
            '*.nhsaki_cd' => 'required',
            //商品コード
            '*.product_cd' => 'required',
            //管理日付
            '*.control_date' => 'required',
            //訂正者名
            '*.corrector_name' => 'required',
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
            'order_number' => '発注番号',
            'ship_date' => '発注予定日',
            'delivery_date' => '納期',
            'nhsaki_cd' => '納入先',
            'product_cd' => '商品コード',
            'control_date' => '管理日付',
            'corrector_name' => '訂正者名',
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
