<?php

namespace App\Http\Controllers\Api;

use Illuminate\Http\Request;
use App\Models\SlcWmsT01Receiving;
use App\Models\SlcMst91Information;
use App\Models\SlcMst03Branch;
use App\Models\SlcMst06Customer;
use App\Models\SlcOmsT1Order;
use App\Http\Controllers\Controller;
use Illuminate\Support\Facades\Storage;
use App\Http\Component\ResponseComponent;
use App\Models\SlcWmsT02ShippingInstructionHeader;

class MainController extends Controller
{
    protected $Response;
    protected $SlcWmsT02ShippingInstructionHeader;
    protected $SlcWmsT01Receiving;
    protected $SlcMst91Information;
    protected $SlcMst03Branch;
    protected $SlcMst06Customer;
    protected $SlcOmsT1Order;

    public function __construct()
    {
        $this->Response = new ResponseComponent();
        $this->SlcWmsT01Receiving = new SlcWmsT01Receiving();
        $this->SlcWmsT02ShippingInstructionHeader = new SlcWmsT02ShippingInstructionHeader();
        $this->SlcMst91Information = new SlcMst91Information();
        $this->SlcMst03Branch = new SlcMst03Branch();
        $this->SlcMst06Customer = new SlcMst06Customer();
        $this->SlcOmsT1Order = new SlcOmsT1Order();
    }

    public function getDailySchedule()
    {
        try {
            $result = $this->Response->success([
                'receivings' => $this->SlcWmsT01Receiving->getDailyScheduleReceiving(),
                'instocks' => $this->SlcWmsT02ShippingInstructionHeader->getDailyScheduleInstock(),
                'getInformation' => $this->SlcMst91Information->getInformation(),
                'operatingInstructions' => $this->SlcMst91Information->getOperatingInstructions(),
                'isValidMessage' => $this->SlcWmsT01Receiving->isValidMessageMain(),
                'wareHouseInfor' => $this->SlcMst03Branch->getInfWareHouse(),
                'creaditInfor' => $this->SlcMst06Customer->getCreditInf(),
                'sumOrderInMonth' => $this->SlcOmsT1Order->getSumOrderInMonth(),
            ]);

            return $result;
        } catch (\Exception $th) {
            return  $this->Response->customResponse(400, $th->getMessage());
        }
    }

    public function getPDFSize(Request $request)
    {
        $filePath = public_path('OMS_OMS06001.pdf');
        // dd(file_get_contents($filePath));
        if (file_exists($filePath)) {
            $fileSize = filesize($filePath); // Lấy kích thước tệp (byte)
            // dd($fileSize);
            // Chuyển đổi kích thước từ byte sang đơn vị khác (ví dụ: KB, MB)
            $formattedSize = $this->formatSizeUnits($fileSize);

            echo "Kích thước của tệp là: " . $formattedSize;
        } else {
            echo "Tệp PDF không tồn tại.";
        }
    }
    function formatSizeUnits($bytes)
    {
        if ($bytes >= 1073741824) {
            $bytes = number_format($bytes / 1073741824, 2) . ' GB';
        } elseif ($bytes >= 1048576) {
            $bytes = number_format($bytes / 1048576, 2) . ' MB';
        } elseif ($bytes >= 1024) {
            $bytes = number_format($bytes / 1024, 2) . ' KB';
        } elseif ($bytes > 1) {
            $bytes = $bytes . ' bytes';
        } elseif ($bytes == 1) {
            $bytes = $bytes . ' byte';
        } else {
            $bytes = '0 bytes';
        }

        return $bytes;
    }
}
