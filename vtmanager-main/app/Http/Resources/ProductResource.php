<?php

namespace App\Http\Resources;

use App\Http\Resources\CustomerProductsResource;
use Illuminate\Http\Resources\Json\JsonResource;

class ProductResource extends JsonResource
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
            'item_code' => $this->商品コード,
            'item_name' => $this->商品名,
            'capacity' => $this->容積,
            'qty_of_case' => $this->ケース入数,
            'gtin_code' => $this->商品コードＧＴＩＮ,
            'weight' => $this->重量,
            'cost1' => $this->売価１,
            'tax_class' => $this->税区分,
            'tax_rate' => $this->税率,
            'customer_code' => $this->得意先コード,
            'customer_name' => $this->得意先名称,
            'customer_product_code' => $this->得意先商品コード,
            'selling_price' => $this->売価1,
            'customerProduct' => CustomerProductsResource::collection($this->customerProducts)
        ];
    }
}
