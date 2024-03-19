<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;

class DatabaseSeeder extends Seeder
{
    /**
     * Seed the application's database.
     *
     * @return void
     */
    public function run()
    {
        // $this->call(SlcMst01UserTableSeeder::class);
        $this->call(SlcOmsT1OrderTableSeeder::class);
        $this->call(SlcMst03BranchTableSeeder::class);
        $this->call(SlcMst04ProductTableSeeder::class);
        $this->call(SlcMst06CustomerTableSeeder::class);
        $this->call(SlcMst22StatusTableSeeder::class);
        $this->call(SlcWmsT103ShippingDetails::class);
        $this->call(SlcWmsT02ShippingInstructionHeaderTableSeeder::class);
        // $this->call(SlcMst91InformationTableSeeder::class);
        // $this->call(SlcWmsT01ReceivingTableSeeder::class);
    }
}
