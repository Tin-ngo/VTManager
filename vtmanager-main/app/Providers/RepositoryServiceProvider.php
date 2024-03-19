<?php

namespace App\Providers;

use App\Services\MST\CustomerService;
use Illuminate\Support\ServiceProvider;
use App\Repositories\MST\CustomerRepository;
// ＭＳＴ＿Ｍ００７配送先
use App\Interfaces\Services\MST\CustomerServiceInterface;

// ＭＳＴ＿Ｍ００６得意先

use App\Interfaces\Repositories\MST\CustomerRepositoryInterface;


class RepositoryServiceProvider extends ServiceProvider
{
    /**
     * Register services.
     *
     * @return void
     */
    public function register()
    {

        //ＭＳＴ＿Ｍ００６得意先
        $this->app->bind(CustomerServiceInterface::class, CustomerService::class);
        $this->app->bind(CustomerRepositoryInterface::class, CustomerRepository::class);
    }


    /**
     * Bootstrap services.
     *
     * @return void
     */
    public function boot()
    {
        //
    }
}
