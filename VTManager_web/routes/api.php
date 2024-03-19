<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\Api\AreaController;
use App\Http\Controllers\Api\TableController;
use App\Http\Controllers\Api\OrderController;
use App\Http\Controllers\Api\LoginController;
use App\Http\Controllers\Api\EmployeeController;
use App\Http\Controllers\Api\WorkingTimeController;
use App\Http\Controllers\Api\ProductController;
use App\Http\Controllers\Api\BillController;

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
    Route::post('/login-employee', [LoginController::class, 'loginEmployee']);
    // Route::get('/information', [LoginController::class, 'getInformation']);
});

// auth:admin => sử dụng guards admin
Route::middleware(['auth:admin,employee'])->get('/user', function (Request $request) {
    return auth()->user();
});

//Common
Route::prefix('com')->group(function () {
    Route::prefix('main')->group(function () {
        
    });
});

//ADMIN
Route::prefix('admin')->group(function () {
    Route::prefix('/status')->group(function () {
        Route::get('/areas/{ownerId}', [AreaController::class, 'getAreas']);
        Route::get('/tables/{ownerId}', [TableController::class, 'getTables']);
        Route::get('/table-orders/{ownerId}', [TableController::class, 'getTableOrders']);
        Route::get('/orders/{ownerId}', [OrderController::class, 'getOrders']);
        Route::get('/employees', [EmployeeController::class, 'getEmployees']);
        Route::get('/employees-is-working', [WorkingTimeController::class, 'isWorking']);
        Route::get('/product_type/{ownerId}', [ProductController::class, 'getProductTypes']);
        Route::get('/product/update-status-product', [ProductController::class, 'updateProductStatus']);
        Route::get('/product/{ownerId}', [ProductController::class, 'getProducts']);
    });
    Route::prefix('/manage')->group(function () {
    });
});

// Employee
Route::prefix('/employee')->group(function () {
    Route::get('/add-order',  [OrderController::class, 'addOrders']);
    Route::get('/get-order',  [OrderController::class, 'getOrder']);
    Route::get('/get-orders',  [OrderController::class, 'getOrder']);
    Route::get('/switch-table',  [OrderController::class, 'switchTable']);
    Route::get('/update-order',  [OrderController::class, 'updateOrder']);
    Route::get('/delete-order',  [OrderController::class, 'deleteOrder']);
    Route::get('/delete-orders',  [OrderController::class, 'deleteOrders']);
    Route::get('/reduce-quantity',  [OrderController::class, 'reduceQuantity']);
    Route::get('/update-status-table',  [TableController::class, 'updateStatus']);
    Route::get('/update-status-order',  [OrderController::class, 'updateStatus']);
    Route::get('/update-status-orders',  [OrderController::class, 'updateStatusOrders']);
    Route::get('/update-status-paid',  [OrderController::class, 'updateStatusPaid']);
    Route::get('/add-bill',  [BillController::class, 'addBill']);
});

// Common
Route::prefix('/common')->group(function () {
    Route::get('/orders/{ownerId}',  [OrderController::class, 'getCommonOrders']);
    Route::get('/employee_staff',  [EmployeeController::class, 'getCommonEmployeeStaff']);
    Route::get('/employee_order/{ownerId}',  [EmployeeController::class, 'getCommonEmployeeOrder']);
    
});
