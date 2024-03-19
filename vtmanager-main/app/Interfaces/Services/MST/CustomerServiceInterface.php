<?php

namespace App\Interfaces\Services\MST;

interface CustomerServiceInterface
{
    public function getCustomers(array $filters = []);
    public function deleteCustomer(array $customerCodes);
    public function createCustomer(array $filters = []);
}
