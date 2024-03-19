<?php

namespace App\Http\Controllers\Api;

use Illuminate\Http\Request;
use App\Http\Controllers\Controller;
use App\Http\Component\ResponseComponent;
use App\Models\WorkingTime;

class WorkingTimeController extends Controller
{
    protected $Response;
    protected $workingTime;
    
    public function __construct()
    {
        $this->Response = new ResponseComponent();
        $this->workingTime = new WorkingTime();
    }

    
    public function isWorking(Request $request)
    {
        try {
            $result = $this->Response->success([
                'result' => $this->workingTime->checkorkingTime($request)
            ]);
            
            return $result;
        } catch (\Exception $th) {
            return  $this->Response->customResponse(400, $th->getMessage());
        }
    }
}
