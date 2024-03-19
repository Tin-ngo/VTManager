<?php

namespace App\Http\Resources;

use Illuminate\Http\Resources\Json\JsonResource;

class CustomerResource extends JsonResource
{
    /**
     * Transform the resource into an array.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return array|\Illuminate\Contracts\Support\Arrayable|\JsonSerializable
     */
    public function toArray($request)
    {
        return [
            'customer_code' => $this->得意先コード,
            'customer_name' => $this->得意先名称,
            'customer_address1' => $this->住所１,
            'payment_site' => (int)$this->入金サイト,
            'credit_limit' => (int)$this->与信限度額
        ];
    }
}
