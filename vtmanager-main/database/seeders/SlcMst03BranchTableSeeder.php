<?php

namespace Database\Seeders;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Hash;

use App\Models\SlcMst03Branch;
use Illuminate\Database\Seeder;

class SlcMst03BranchTableSeeder extends Seeder
{

    private $data = [
        [
            'オーナーＩＤ' => '000001',
            'ログインユーザーＩＤ' => 'User1',
            '倉庫コード' => '0000001',
            '利用開始日' => '20230901',
            '倉庫名' => 'Warehouse Name 1',
            '倉庫名略称' => 'Warehouse Abbr 1',
            '住所１' => 'Address 1-1',
            '住所２' => 'Address 1-2',
            '電話番号' => '123-456-7890',
            'ファックス番号' => '987-654-3210',
        ],
        [
            'オーナーＩＤ' => '000002',
            'ログインユーザーＩＤ' => 'User2',
            '倉庫コード' => '0000002',
            '利用開始日' => '20230902',
            '倉庫名' => 'Warehouse Name 2',
            '倉庫名略称' => 'Warehouse Abbr 2',
            '住所１' => 'Address 2-1',
            '住所２' => 'Address 2-2',
            '電話番号' => '111-222-3333',
            'ファックス番号' => '444-555-6666',
        ],
        [
            'オーナーＩＤ' => '000003',
            'ログインユーザーＩＤ' => 'User3',
            '倉庫コード' => '0000003',
            '利用開始日' => '20230903',
            '倉庫名' => 'Warehouse Name 3',
            '倉庫名略称' => 'Warehouse Abbr 3',
            '住所１' => 'Address 3-1',
            '住所２' => 'Address 3-2',
            '電話番号' => '777-888-9999',
            'ファックス番号' => '999-888-7777',
        ],
        [
            'オーナーＩＤ' => '000004',
            'ログインユーザーＩＤ' => 'User4',
            '倉庫コード' => '0000004',
            '利用開始日' => '20230904',
            '倉庫名' => 'Warehouse Name 4',
            '倉庫名略称' => 'Warehouse Abbr 4',
            '住所１' => 'Address 4-1',
            '住所２' => 'Address 4-2',
            '電話番号' => '333-222-1111',
            'ファックス番号' => '111-222-3333',
        ],
        [
            'オーナーＩＤ' => '000005',
            'ログインユーザーＩＤ' => 'User5',
            '倉庫コード' => '0000005',
            '利用開始日' => '20230905',
            '倉庫名' => 'Warehouse Name 5',
            '倉庫名略称' => 'Warehouse Abbr 5',
            '住所１' => 'Address 5-1',
            '住所２' => 'Address 5-2',
            '電話番号' => '555-444-3333',
            'ファックス番号' => '333-444-5555',
        ],
        [
            'オーナーＩＤ' => '000006',
            'ログインユーザーＩＤ' => 'User6',
            '倉庫コード' => '0000006',
            '利用開始日' => '20230906',
            '倉庫名' => 'Warehouse Name 6',
            '倉庫名略称' => 'Warehouse Abbr 6',
            '住所１' => 'Address 6-1',
            '住所２' => 'Address 6-2',
            '電話番号' => '666-555-4444',
            'ファックス番号' => '444-555-6666',
        ],
        [
            'オーナーＩＤ' => '000007',
            'ログインユーザーＩＤ' => 'User7',
            '倉庫コード' => '0000007',
            '利用開始日' => '20230907',
            '倉庫名' => 'Warehouse Name 7',
            '倉庫名略称' => 'Warehouse Abbr 7',
            '住所１' => 'Address 7-1',
            '住所２' => 'Address 7-2',
            '電話番号' => '777-666-5555',
            'ファックス番号' => '555-666-7777',
        ],
        [
            'オーナーＩＤ' => '000008',
            'ログインユーザーＩＤ' => 'User8',
            '倉庫コード' => '0000008',
            '利用開始日' => '20230908',
            '倉庫名' => 'Warehouse Name 8',
            '倉庫名略称' => 'Warehouse Abbr 8',
            '住所１' => 'Address 8-1',
            '住所２' => 'Address 8-2',
            '電話番号' => '888-777-6666',
            'ファックス番号' => '666-777-8888',
        ],
        [
            'オーナーＩＤ' => '000009',
            'ログインユーザーＩＤ' => 'User9',
            '倉庫コード' => '0000009',
            '利用開始日' => '20230909',
            '倉庫名' => 'Warehouse Name 9',
            '倉庫名略称' => 'Warehouse Abbr 9',
            '住所１' => 'Address 9-1',
            '住所２' => 'Address 9-2',
            '電話番号' => '999-888-7777',
            'ファックス番号' => '777-888-9999',
        ],
    ];


    /**
     * Run the database seeds.
     * php artisan db:seed --class=SlcMst03BranchTableSeeder
     * @return void
     */
    public function run()
    {
        // SlcMst03Branch::factory()->count(20)->create();
        DB::table('ＭＳＴ＿Ｍ００３倉庫')->truncate();
        DB::table('ＭＳＴ＿Ｍ００３倉庫')->insert($this->data);
    }
}
