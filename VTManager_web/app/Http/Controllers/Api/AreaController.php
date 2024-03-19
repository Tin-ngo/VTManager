<?php

namespace App\Http\Controllers\Api;

use Illuminate\Http\Request;
use App\Http\Controllers\Controller;
use App\Http\Component\ResponseComponent;
use App\Models\Area;

class AreaController extends Controller
{
    protected $Response;
    protected $area;
    
    public function __construct()
    {
        $this->Response = new ResponseComponent();
        $this->area = new Area();
    }

    public function getAreas($ownerId)
    {
        try {
            $result = $this->Response->success([
                'areas' => $this->area->getAreas($ownerId)
            ]);

            return $result;
        } catch (\Exception $th) {
            return  $this->Response->customResponse(400, $th->getMessage());
        }
    }
}
