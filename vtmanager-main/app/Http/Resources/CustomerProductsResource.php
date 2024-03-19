<?php

namespace App\Http\Resources;

use Illuminate\Http\Resources\Json\JsonResource;
use App\Http\Resources\CustomerResource;
class CustomerProductsResource extends JsonResource
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
            'productcode' => $this->商品コード,
            'customerProductcode' => $this->得意先商品コード,
            'customerCode' => $this->得意先コード,
            'cost1' => $this->売価１,
            'customer' => new CustomerResource($this->customer_)
        ];
    }
}
