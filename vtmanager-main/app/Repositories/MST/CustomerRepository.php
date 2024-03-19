<?php

namespace App\Repositories\MST;

use App\Interfaces\Repositories\MST\CustomerRepositoryInterface;
use App\Models\SlcMst06Customer;

class CustomerRepository implements CustomerRepositoryInterface
{
    private SlcMst06Customer $slcMst06Customer;
    public function __construct(SlcMst06Customer $slcMst06Customer)
    {
        $this->slcMst06Customer = $slcMst06Customer;
    }

    public function getCustomers(array $filters = [])
    {
        try {
            return $this->slcMst06Customer->getCustomers($filters);
        } catch (\Exception $e) {
            throw new \Exception($e->getMessage());
        }
    }

    public function getCustomer($customerCode){
        try {
            return $this->slcMst06Customer->getCustomer($customerCode);
        } catch (\Exception $e) {
            throw new \Exception($e->getMessage());
        }
    }
    public function deleteCustomer($customerCodes)
    {
        try {
            return $this->slcMst06Customer->deleteCustomer($customerCodes);
        } catch (\Exception $e) {
           
            throw new \Exception($e->getMessage());
        }
    }

    public function createCustomer(array $data = [])
    {
        
        try {
            return $this->slcMst06Customer->createCustomer($data);
        } catch (\Exception $e) {
            throw new \Exception($e->getMessage());
        }
    }

    public function updateCustomer($customer, array $data = [])
    {
        try {
            return $this->slcMst06Customer->updateCustomer($customer, $data);
        } catch (\Exception $e) {
            throw new \Exception($e->getMessage());
        }
    }
}
