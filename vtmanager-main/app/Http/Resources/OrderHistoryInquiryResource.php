<?php

namespace App\Http\Resources;

use Illuminate\Http\Resources\Json\JsonResource;

class OrderHistoryInquiryResource extends JsonResource
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
            'denpyono' => $this->伝票番号,
            'order_no' => $this->受注番号,
            'tokuisaki_nm' => $this->得意先名称,
            'nhsaki_cd' => $this->納品先コード,
            'nhsaki_name1' => $this->納品先名1,
            'nhsaki_name2' => $this->納品先名2,
            'nhsaki_ad1' => $this->納品先住所1,
            'nhsaki_ad2' => $this->納品先住所2,
            'meisai_no' => $this->明細番号,
            'item_cd' => $this->商品コード,
            'nhsaki_item_name' => $this->納品先商品名,
            'lot_no' => $this->ロットナンバー,
            'symlmt' => $this->管理日付,
            'order_num1' => $this->受注数,
            'irisu' => $this->入数,
            'ship_num1' => $this->出荷数,
            'sell_amount' => $this->売価金額,
            'ship_date' => $this->出荷日,
            'delivery_date' => $this->納品日,
            'status_name' => $this->ステータス名,
        ];
    }
}
