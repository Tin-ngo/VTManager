<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;

class ProductUpdateRequest  extends FormRequest
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
            // 商品コード
            'productCode' => 'required|max:30|alpha_num',
            // 商品名
            'productName' => 'required|max:140|alpha_num',
            // 入数
            'quantityPerPack' => 'required|numeric|min:1',
            // 容積
            'volume' => 'numeric|min:0',
            // 重量
            'weight' => 'numeric|min:0',
            // GTIN
            'GTIN' => 'numeric|digits_between:1,20',
            // 税率
            // 'taxRate' => 'required|numeric',

            //=== 発注商品コード登録 ====
            // 発注商品コード
            'customerProducts.*.productCustomerCode' => 'required|max:10|alpha_num',
            // 販売単価
            'customerProducts.*.cost1' => 'numeric'
        ];
    }

    public function messages()
    {
        return [
            'required' => ':attribute が未入力です.',
            'max' => ':attribute 桁数オーバー.',
            'alpha_num' => ':attribute は半角数値で入力してください.',
            'numeric' => ':attribute は半角数値で入力してください',
            'min' => ':attribute 入数は:min以上で入力してください',
            'digits_between' => ':attribute 桁数オーバー'
        ];
    }

    protected function failedValidation(Validator $validator)
    {
        if ($validator->fails()) {
            throw new HttpResponseException(response()->json([
                'errors' => $validator->errors(),
            ], 200));
        }
    }

    public function attributes()
    {
        return [
            'productCode' => '商品コード',
            'productName' => '商品名',
            'quantityPerPack' => '入数',
            'volume' => '容積',
            'weight' => '重量',
            'GTIN' => 'GTIN',
            // 発注商品コード
            'customerProducts.*.productCustomerCode' => '発注商品コード',
            // 販売単価
            'customerProducts.*.cost1' => '販売単価'
        ];
    }
}
