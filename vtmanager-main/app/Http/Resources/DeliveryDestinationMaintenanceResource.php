<?php

namespace App\Http\Resources;

use Illuminate\Http\Resources\Json\JsonResource;

class DeliveryDestinationMaintenanceResource extends JsonResource
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
            'delivery_cd' => $this->配送先コード,
            'customer_cd' => $this->得意先コード,
            'customer_name' => $this->得意先名称,
            'delivery_name1' => $this->配送先名称１,
            'delivery_name2' => $this->配送先名称２,
            'delivery_address1' => $this->住所１,
            'delivery_address2' => $this->住所２,
            'delivery_telno' => $this->電話番号,
            'delivery_lead_time' => $this->リードタイム１
        ];
    }
}
