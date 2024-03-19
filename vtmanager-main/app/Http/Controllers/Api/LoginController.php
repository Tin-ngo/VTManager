<?php

namespace App\Http\Controllers\Api;

use Illuminate\Http\Request;
use App\Http\Controllers\Controller;
use App\Http\Component\ResponseComponent;
use App\Form\Authentication\AuthLoginCustomValidator;
use App\Models\Admin;

class LoginController extends Controller
{
    protected $Response;
    protected $AuthLoginCustomValidator;
    protected $admin;

    protected $SlcMst91Information;
    
    public function __construct()
    {
        $this->Response = new ResponseComponent();
        $this->AuthLoginCustomValidator = new AuthLoginCustomValidator();
        $this->admin = new Admin();
    }

    public function login(Request $request)
    {
        try {
             // Validate input
             $validation = $this->AuthLoginCustomValidator->validate(
                $request,
                'AuthUserLoginForm'
            );

            if ($validation !== true) {
                return $this->Response->validationError($validation);
            }

            $result = $this->admin->login($request);

            return $this->Response->success([
                'token' => $result['token'],
                'user' => $result['user'],
                'role' => "USER",
                'error' => 0
            ]);
        } catch (\Throwable $th) {
            return $this->Response->customResponse(400, $th->getMessage());
        }
    }

    public function getInformation() {
        return $this->Response->success([
            'result' => $this->SlcMst91Information->getInformation(),
            'error' => 0
        ]);
    }
}
