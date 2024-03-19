<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;

class DeliveryDestinationCreateRequest  extends FormRequest
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
            // 得意先コード
            'customerCd' => 'required|alpha_num',
            // 配送先コード
            'deliveryCd' => 'required|alpha_num',
            // 配送先名称１
            'deliveryName1' => 'required|max:255',
            //
            'deliveryName2' => 'required|max:255',
            // 住所１
            'deliveryAddress1' => 'required',
            //住所2
            'deliveryAddress2' => 'required',
            //電話番号
            'telephoneNumber' => 'alpha_num',
            // リードタイム１
            'deliveryLeadTime' => 'required|numeric|min:1',
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
            'customerCd' => '得意先コード',
            'deliveryCd' => '配送先コード',
            'deliveryName1' => '配送先名称１',
            'deliveryName2' => '配送先名称２',
            'deliveryAddress1' => '住所１',
            'deliveryAddress2' => '住所2',
            'telephoneNumber' => '電話番号',
            'deliveryLeadTime' => '配送リードタイム',

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
}
