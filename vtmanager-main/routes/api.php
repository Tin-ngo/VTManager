<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\Api\MainController;
use App\Http\Controllers\Api\LoginController;

use App\Http\Controllers\Api\MST\CustomerController;
/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

// Authentication
Route::prefix('auth')->group(function () {
    Route::post('/login', [LoginController::class, 'login']);
    Route::get('/information', [LoginController::class, 'getInformation']);
});

Route::middleware('auth:api')->get('/user', function (Request $request) {
    return auth()->user();
});

//共通
Route::prefix('com')->group(function () {
    Route::prefix('main')->group(function () {
        Route::get('/schedule', [MainController::class, 'getDailySchedule']);
    });
});


// 商品マスタ
Route::prefix('mst')->group(function () {
    // MST03101_得意先マスタ
    // MST03101_得意先マスタメンテナンス
    Route::prefix('/customer')->group(function () {
        Route::get('', [CustomerController::class, 'getCustomers']);
        Route::get('{cd}', [CustomerController::class, 'getCustomer']);
        Route::post('/', [CustomerController::class, 'createCustomer']);
        Route::put('/{cd}', [CustomerController::class, 'updateCustomer']);
        Route::post('/delete', [CustomerController::class, 'deleteCustomer']);
    });
});
