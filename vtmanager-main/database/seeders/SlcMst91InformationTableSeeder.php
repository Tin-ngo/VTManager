<?php

namespace Database\Seeders;

use App\Models\SlcMst91Information;
use Illuminate\Database\Seeder;

class SlcMst91InformationTableSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        SlcMst91Information::factory()->count(20)->create();
    }
}
