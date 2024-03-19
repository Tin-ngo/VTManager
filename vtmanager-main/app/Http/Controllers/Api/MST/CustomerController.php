<?php

namespace App\Http\Controllers\Api\MST;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Http\Requests\CustomerRequest;
use App\Http\Component\ResponseComponent;
use App\Services\MST\CustomerService;
use App\Interfaces\Services\MST\CustomerServiceInterface;
use App\Http\Resources\CustomerResource;

class CustomerController extends Controller
{
    private $response;
    private CustomerService $customerService;

    public function __construct(CustomerServiceInterface $customerServiceInterface, ResponseComponent $response)
    {
        $this->response = $response;
        $this->customerService = $customerServiceInterface;
    }

    public function getCustomers(Request $request)
    {
        try {
            $customers = $this->customerService->getCustomers($request->all());
            return $this->response->success([
                'customers' => CustomerResource::collection($customers)
            ]);
        } catch (\Exception $e) {
            return $this->response->customResponse(400, $e->getMessage());
        }
    }

    public function getCustomer($customerCode) {
        try {
            $customer = $this->customerService->getCustomer($customerCode);

            return $this->response->success([
                'customer' => new CustomerResource($customer)
            ]);
        } catch (\Exception $e) {
            return $this->response->customResponse(400, $e->getMessage());
        }
    }

    public function createCustomer(CustomerRequest $request)
    {
        try {
            $validatedCustomer = (array) $request->validated();
            $result = $this->customerService->createCustomer($validatedCustomer);
            if($result['customer_code']) {
                return $this->response->customResponse(402, $result);
            }
            return $this->response->success($result);
        } catch (\Exception $e) {
            return $this->response->customResponse(500, $e->getMessage());
        }
    }

    public function updateCustomer(CustomerRequest $request, $customerCode)
    {
        try {
            $validatedCustomer = (array) $request->validated();
            
            $result = $this->customerService->updateCustomer($customerCode, $validatedCustomer);
            return $this->response->success($result);
        } catch (\Exception $e) {
            return $this->response->customResponse(500, $e->getMessage());
        }
    }

    public function deleteCustomer(Request $request)
    {    
        try {
            $requestData = $request->all();
            $result = $this->customerService->deleteCustomer($requestData['customerCodes']);
            if(is_string($result)) {
                return $this->response->customResponse(402, $result);
            }
           
            return $this->response->success();
        } catch (\Exception $e) {
            return $this->response->customResponse(400, $e->getMessage());
        }
    }
}
