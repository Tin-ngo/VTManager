<?php

namespace App\Http\Resources;

use Illuminate\Http\Resources\Json\JsonResource;

class OrderStatusResource extends JsonResource
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
            'owner_id' => $this->オーナーＩＤ,
            'customer_name' => $this->ＭＳＴ＿Ｍ００６得意先_得意先名称,
            'customer_code' => $this->得意先コード,
            'status_code' => $this->ステータスコード,
            'status_name' => $this->ステータス名称,
            'order_no' => $this->受注番号,
            'tokuisakinm' => $this->得意先名称,
            'denpyono' => $this->伝票番号,
            'order_date' => $this->受注日,
            'delivery_date' => $this->納品日,
            'nhsaki_cd' => $this->納品先コード,
            'nhsaki_name1' => $this->納品先名1,
            'nhsaki_name2' => $this->納品先名2,
            'mesaino' => $this->明細番号,
            'branch_name' => $this->倉庫名,
            'item_cd' => $this->商品コード,
            'nhsaki_item_name' => $this->商品名,
            'lot_no' => $this->ロットナンバー,
            'symlmt' => $this->管理日付,
            'order_num1' => $this->受注数,
            'ship_date' => $this->出荷日,
            'assign_num1' => $this->割当数,
            'ship_num1' => $this->出荷数,
            'irisu' => $this->入数,
            'remain_num1' => $this->残在庫数,
            'missing_num1' => $this->欠品数,
            'create_date' => $this->作成日,
            'delete_flg' => $this->削除フラグ,
            'tax_code' => $this->倉庫コード,
            'amount' => $this->売単価
        ];
    }
}
