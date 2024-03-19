<?php
namespace App\Services\MST;

use App\Interfaces\Services\MST\CustomerServiceInterface;
use App\Interfaces\Repositories\MST\CustomerRepositoryInterface;
use App\Repositories\MST\CustomerRepository;
use App\Helpers\CommonHelper;

class CustomerService implements CustomerServiceInterface
{
    protected CustomerRepository $customerRepository;
    public function __construct(
        CustomerRepositoryInterface $customerRepositoryInterface,
    ) {
        $this->customerRepository = $customerRepositoryInterface;
    }

    public function getCustomers(array $filters = [])
    {
        $filters = CommonHelper::removeNullValues($filters);
        try {
            return $this->customerRepository->getCustomers($filters);
        } catch (\Exception $e) {
            throw new \Exception($e->getMessage());
        }
    }

    public function getCustomer($customerCode) {
        try {
            return $this->customerRepository->getCustomer($customerCode);
        } catch (\Exception $e) {
            throw new \Exception($e->getMessage());
        }
    }

    public function createCustomer(array $data = [])
    {
        try {
            $customer = $this->customerRepository->getCustomer($data['customer_code']);
            if($customer) {
                return ["customer_code" => "得意先コードがマスタに登録済みです"];
            }
            return $this->customerRepository->createCustomer($data);
        } catch (\Exception $e) {
            throw new \Exception($e->getMessage());
        }
    }

    public function updateCustomer($customerCode, array $data = [])
    {
        try {
            $customer = $this->customerRepository->getCustomer($customerCode);
            if(!$customer) {
                return ["customer_code" => "得意先コード không tồn tại"];
            }
            
            return $this->customerRepository->updateCustomer($customer, $data);
        } catch (\Exception $e) {
            throw new \Exception($e->getMessage());
        }
    }

    
    public function deleteCustomer($customerCodes)
    {
        try {
            // $customerValidate = $this->deleteCustomerValidate($customerCodes);
            // if (!empty($customerValidate['customerCodeUsage'])) {
            //     return "得意先コード không tồn tại";
            // }
            return $this->customerRepository->deleteCustomer($customerCodes);
        } catch (\Exception $e) {
            throw new \Exception($e->getMessage());
        }
    }

    // private function deleteCustomerValidate($customerCodes) {
    //     try {
    //         $slcWmsT02ShippingInstructionHeader = $this->getDistinct(
    //             $this->slcWmsT02ShippingInstructionHeaderRepository->getSlcWmsT02ShippingInstructionHeaderWithCustomerCode($customerCodes)
    //         );
            
    //         $slcWmsT22ShippingRecordHeaderWithCustomerCode = $this->getDistinct(
    //             $this->slcWmsT22ShippingRecordHeaderReponsitory->getSlcWmsT22ShippingRecordHeaderWithCustomerCode($customerCodes)
    //         );
    
    //         $customerCodeUsage = array_intersect($customerCodes, $slcWmsT02ShippingInstructionHeader, $slcWmsT22ShippingRecordHeaderWithCustomerCode);
    //         $customerCodeNonUsage = array_diff($customerCodes, $customerCodeUsage);
    
    //         return [
    //             'customerCodeUsage' => $customerCodeUsage,
    //             'customerCodeNonUsage' => $customerCodeNonUsage
    //         ];
    //     } catch (\Exception $e) {
    //         throw new \Exception($e->getMessage());
    //     }
    // }

    private function getDistinct($array, $key ='得意先コード') {
        $distinctValues = array_column($array, $key);
        return array_values(array_unique($distinctValues));
    }
}
