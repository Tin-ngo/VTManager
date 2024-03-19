<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use App\Helpers\CommonHelper;
class SlcMst06Customer extends Model
{
    use HasFactory;

    protected $table = 'ＭＳＴ＿Ｍ００６得意先';
    protected $primaryKey = '得意先コード';
    private $ownerId = '000000';
    public $incrementing = false;
    public $timestamps = false;
    private $userId = 'User9';
    /**
     * The attributes that are mass assignable.
     *
     * @var array
     */
    protected $fillable = [
        'オーナーＩＤ',
        'ログインユーザーＩＤ',
        '得意先コード',
        '得意先名称',
        '得意先略称',
        '住所1',
        '住所2',
        '電話番号',
        'ファックス番号',
        '郵便番号',
        '与信限度額',
        '入金サイト',
        '荷主コード',
        '輸送荷主コード',
        '倉庫荷主コード',
        '予備１',
        '予備２',
        '予備３',
        '予備４',
        '予備５',
        '予備６',
        '予備７',
        '予備８',
        '予備９',
        '予備１０',
        '数値予備１',
        '数値予備２',
        '数値予備３',
        '数値予備４',
        '数値予備５',
        '作成日時',
        '更新日時',


        '登録者',
        '更新者',
        '取込上書可否区分'
    ];

    private function mapDataToModel($data)
    {
        $fillable = [
            '得意先コード' => 'customer_code',
            '得意先名称' => 'customer_name',
            '与信限度額' => 'credit_limit',
            '入金サイト' => 'payment_site'
        ];

        $mappedData = ['オーナーＩＤ' => $this->ownerId];

        foreach ($fillable as $fieldInModel => $fieldInData) {
            if (isset($data[$fieldInData])) {
                $mappedData[$fieldInModel] = $data[$fieldInData];
            }
        }
        return $mappedData;
    }

    public function getCustomers(array $filters = [], array $selectColumns = [])
    {
        $query = $this->query();

        $selectedColumns = !empty($selectColumns) ? $selectColumns : [
            '得意先コード',
            '得意先名称',
            '住所１',
            '与信限度額',
            '入金サイト'
        ];

        $query->select($selectedColumns);
        if(isset($filters['customer_code'])){
            $query->where('得意先コード', 'LIKE', '%' . $filters['customer_code'] . '%');
        }

        if(isset($filters['customer_name'])){
            $query->where('得意先名称', 'LIKE', '%' . $filters['customer_name'] . '%');
        }
        
        $query->where('オーナーＩＤ', "=", $this->ownerId);
        return $query->orderBy('得意先コード', 'ASC')->get();
    }

    public function getCustomer($customerCode)
    {
        $query = $this->query();
        return $query->where('オーナーＩＤ', $this->ownerId)
            ->where('得意先コード', $customerCode)
            ->first();
    }

    public function createCustomer(array $data)
    {
        $mappedData = $this->mapDataToModel($data);
        $mappedData["オーナーＩＤ"] = $this->ownerId;
        $mappedData["ログインユーザーＩＤ"] = $this->userId;
        return $this->create($mappedData);
    }

    public function updateCustomer($customer, array $data)
    {
        $mappedData = $this->mapDataToModel($data);
        return $customer->update($mappedData);
    }

    public function checkDelete($customer_code)
    {
 
        return true;
    }

    public function deleteCustomer($customerCodes)
    {
        $query = $this->query();
        return $query->where('オーナーＩＤ', "=", $this->ownerId)
            ->whereIn('得意先コード', $customerCodes)
            ->delete();
    }

    public function getCustomerByID()
    {
        return $this->select('得意先コード', '得意先名称')
            ->where('オーナーＩＤ', $this->ownerId)
            ->get();
    }
    public function getCreditInf()
    {
        $ownerId = auth()->user()->オーナーＩＤ;
        return $this->select('与信限度額', '入金サイト')
            ->where('オーナーＩＤ', $ownerId)
            ->get();
    }

    public function getCombinedDataProducts(array $selectColumns = [])
    {
        $query = $this->query();

        $selectedColumns = !empty($selectColumns) ? $selectColumns : [
            'ＭＳＴ＿Ｍ００６得意先.得意先コード as customerCode',
            'ＭＳＴ＿Ｍ００６得意先.得意先名称 as customerName',
            'ＭＳＴ＿Ｍ００５得意先商品.得意先商品コード as productCustomerCode',
            'ＭＳＴ＿Ｍ００５得意先商品.売価１ as cost1',
            'ＭＳＴ＿Ｍ００４商品.税区分 as textClassification',
            'ＭＳＴ＿Ｍ００４商品.税率 as textRate',
            // 'ＭＳＴ＿Ｍ００４商品.商品コード as productCode',
        ];

        $query->select($selectedColumns)
            ->leftJoin('ＭＳＴ＿Ｍ００５得意先商品', function ($join) {
                $join->on('ＭＳＴ＿Ｍ００５得意先商品.オーナーＩＤ', '=', 'ＭＳＴ＿Ｍ００６得意先.オーナーＩＤ');
                $join->on('ＭＳＴ＿Ｍ００５得意先商品.得意先コード', '=', 'ＭＳＴ＿Ｍ００６得意先.得意先コード');
            })
            ->leftJoin('ＭＳＴ＿Ｍ００４商品', function ($join) {
                $join->on('ＭＳＴ＿Ｍ００５得意先商品.オーナーＩＤ', '=', 'ＭＳＴ＿Ｍ００４商品.オーナーＩＤ');
                $join->on('ＭＳＴ＿Ｍ００５得意先商品.商品コード', '=', 'ＭＳＴ＿Ｍ００４商品.商品コード');
            });

        $query->where('ＭＳＴ＿Ｍ００６得意先.オーナーＩＤ', "=", $this->ownerId);
        return $query->get();
    }
}
