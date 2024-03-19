<?php

namespace Database\Seeders;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Hash;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;

class SlcMst04ProductTableSeeder extends Seeder
{

    private $data = [
        [
            'オーナーＩＤ' => '000001',
            '商品コード' => 'SPC123',
            '商品名' => 'Product Name 1',
            '得意先商品コード' => 'CustomerProductCode1',
            'ベンダー商品コード' => 'VendorProductCode1',
            '商品コードＧＴＩＮ' => 'GTIN1',
            '商品コードＩＴＦ' => 'ITF1',
            '商品コードＪＡＮ' => 'JAN1',
            '重量' => 100,
            '才数' => 10.5,
            '容積' => 5.678,
        ],
        [
            'オーナーＩＤ' => '000002',
            '商品コード' => 'SPC123',
            '商品名' => 'Product Name 2',
            '得意先商品コード' => 'CustomerProductCode2',
            'ベンダー商品コード' => 'VendorProductCode2',
            '商品コードＧＴＩＮ' => 'GTIN2',
            '商品コードＩＴＦ' => 'ITF2',
            '商品コードＪＡＮ' => 'JAN2',
            '重量' => 200,
            '才数' => 20.5,
            '容積' => 6.789,
        ],
        [
            'オーナーＩＤ' => '000003',
            '商品コード' => 'SPC123',
            '商品名' => 'Product Name 3',
            '得意先商品コード' => 'CustomerProductCode3',
            'ベンダー商品コード' => 'VendorProductCode3',
            '商品コードＧＴＩＮ' => 'GTIN3',
            '商品コードＩＴＦ' => 'ITF3',
            '商品コードＪＡＮ' => 'JAN3',
            '重量' => 300,
            '才数' => 30.5,
            '容積' => 7.890,
        ],
        [
            'オーナーＩＤ' => '000004',
            '商品コード' => 'SPC123',
            '商品名' => 'Product Name 4',
            '得意先商品コード' => 'CustomerProductCode4',
            'ベンダー商品コード' => 'VendorProductCode4',
            '商品コードＧＴＩＮ' => 'GTIN4',
            '商品コードＩＴＦ' => 'ITF4',
            '商品コードＪＡＮ' => 'JAN4',
            '重量' => 400,
            '才数' => 40.5,
            '容積' => 8.901,
        ],
        [
            'オーナーＩＤ' => '000005',
            '商品コード' => 'SPC123',
            '商品名' => 'Product Name 5',
            '得意先商品コード' => 'CustomerProductCode5',
            'ベンダー商品コード' => 'VendorProductCode5',
            '商品コードＧＴＩＮ' => 'GTIN5',
            '商品コードＩＴＦ' => 'ITF5',
            '商品コードＪＡＮ' => 'JAN5',
            '重量' => 500,
            '才数' => 50.5,
            '容積' => 9.012,
        ],
        [
            'オーナーＩＤ' => '000006',
            '商品コード' => 'SPC123',
            '商品名' => 'Product Name 6',
            '得意先商品コード' => 'CustomerProductCode6',
            'ベンダー商品コード' => 'VendorProductCode6',
            '商品コードＧＴＩＮ' => 'GTIN6',
            '商品コードＩＴＦ' => 'ITF6',
            '商品コードＪＡＮ' => 'JAN6',
            '重量' => 600,
            '才数' => 60.5,
            '容積' => 10.123,
        ],
        [
            'オーナーＩＤ' => '000007',
            '商品コード' => 'SPC123',
            '商品名' => 'Product Name 7',
            '得意先商品コード' => 'CustomerProductCode7',
            'ベンダー商品コード' => 'VendorProductCode7',
            '商品コードＧＴＩＮ' => 'GTIN7',
            '商品コードＩＴＦ' => 'ITF7',
            '商品コードＪＡＮ' => 'JAN7',
            '重量' => 700,
            '才数' => 70.5,
            '容積' => 11.234,
        ],
        [
            'オーナーＩＤ' => '000008',
            '商品コード' => 'SPC123',
            '商品名' => 'Product Name 8',
            '得意先商品コード' => 'CustomerProductCode8',
            'ベンダー商品コード' => 'VendorProductCode8',
            '商品コードＧＴＩＮ' => 'GTIN8',
            '商品コードＩＴＦ' => 'ITF8',
            '商品コードＪＡＮ' => 'JAN8',
            '重量' => 800,
            '才数' => 80.5,
            '容積' => 12.345,
        ],
        [
            'オーナーＩＤ' => '000009',
            '商品コード' => 'SPC123',
            '商品名' => 'Product Name 9',
            '得意先商品コード' => 'CustomerProductCode9',
            'ベンダー商品コード' => 'VendorProductCode9',
            '商品コードＧＴＩＮ' => 'GTIN9',
            '商品コードＩＴＦ' => 'ITF9',
            '商品コードＪＡＮ' => 'JAN9',
            '重量' => 900,
            '才数' => 90.5,
            '容積' => 13.456,
        ],
    ];


    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('ＭＳＴ＿Ｍ００４商品')->truncate();
        DB::table('ＭＳＴ＿Ｍ００４商品')->insert($this->data);
    }
}
