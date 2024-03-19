<?php

namespace App\Interfaces\Repositories\MST;

interface CustomerRepositoryInterface
{
    public function getCustomers(array $filters = []);
    public function getCustomer($id);
    public function deleteCustomer($id);
    public function createCustomer(array $data = []);

    public function updateCustomer($customer, array $data = []);
    
}
