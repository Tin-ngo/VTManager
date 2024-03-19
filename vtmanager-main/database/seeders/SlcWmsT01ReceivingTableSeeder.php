<?php

namespace Database\Seeders;

use Carbon\Carbon;
use Illuminate\Database\Seeder;
use App\Models\SlcWmsT01Receiving;

class SlcWmsT01ReceivingTableSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $currentDate = Carbon::now();

        $yesterday = $currentDate->subDay();
        $counter = 0;
        for ($index = 1; $index <= 20; $index++) {
            if ($counter % 5 === 0 && $counter > 0) {
                $yesterday->addDay();
            }
            SlcWmsT01Receiving::factory()->stockDate($currentDate->format('Ymd'))->create();
            $counter++;
        }
    }
}
