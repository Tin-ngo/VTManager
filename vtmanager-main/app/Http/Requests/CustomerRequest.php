<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Http\Exceptions\HttpResponseException;
use App\Helpers\CommonHelper;

class CustomerRequest extends FormRequest
{
    // private CustomerResource $response;

    // public function __construct(CustomerResource $response)
    // {
    //     $this->response = $response;
    // }

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
            'customer_code' => 'required|max:20|regex:/^[a-zA-Z0-9]+$/',
            // 得意先名
            'customer_name' => 'required|max:100',
            // 与信額 
            'credit_limit' => 'numeric',
            // 入金サイト
            'payment_site' => 'numeric'
        ];
    }

    public function messages()
    {
        return [
            'required' => ':attributeが未入力です。',
            'max' => ':attribute桁数オーバーです。', 
            'regex' => ':attributeは半角英数で入力してください。',
            'numeric' => ':attributeは半角数値で入力してください。'
        ];
    }

    protected function failedValidation(Validator $validator)
    {
        if ($validator->fails()) {
            throw new HttpResponseException(response()->json([
                'message' => CommonHelper::formatMessagesError($validator->errors()->toArray()),
                'status_code' => 402,
            ], 402));
        }
    }

    
}
