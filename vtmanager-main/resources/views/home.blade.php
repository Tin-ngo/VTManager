<!-- @extends('layouts.app')

@section('content')
<div class="hold-transition sidebar-mini layout-fixed">
    <div class="wrapper" id="app">
        <nav class="main-header navbar navbar-expand navbar-white navbar-light">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" data-widget="pushmenu" href="#" role="button">
                        <font-awesome-icon icon="fas fa-bars" />
                    </a>
                </li>
                <li class="nav-item" style="font-size: 130%; padding-left: 3px; padding-top: 5px;">
                </li>
            </ul>

            <ul class="navbar-nav ml-auto">
                <li class="nav-item dropdown">
                    <a class="nav-link" id="dynamic-href" href="/login" aria-expanded="false">
                        <font-awesome-icon icon="fas fa-sign-out-alt fa-lg" />
                    </a>
                </li>
            </ul>
        </nav>

        <aside class="main-sidebar sidebar-dark-primary elevation-4">
            <a href="/" class="brand-link">
                <img src="" alt="" class="brand-image" sizes="512x512">
                <span class="brand-text font-weight-light">SL-CLOUD</span>
            </a>
            {{-- <sidebar /> --}}
            <div class="sidebar">
                <div class="user-panel mt-3 pb-3 mb-3 d-flex">
                    <div class="image" style="color: #fff; font-size: 140%">
                        <i class="nav-icon">
                            <font-awesome-icon icon="fas fa-user-circle" />
                        </i>
                    </div>
                    <div class="info" style="color: #fff">
                        テスト担当者
                    </div>
                </div>

                <nav class="mt-2">
                    <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false" />
                    <li class="nav-item menu-open">
                        <a href="#" class="nav-link active">
                            <i class="nav-icon fas fa-home"></i>
                            <p>
                                OMS MENU
                                <i class="right fas fa-angle-left"></i>
                            </p>
                        </a>
                        <ul class="nav nav-treeview">
                            <li class="nav-item">
                                <a href="/order-status-search" class="nav-link active">
                                    <i class="fas fa-search nav-icon"></i>
                                    <p>受注情報検索</p>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a href="#" class="nav-link">
                                    <i class="fas fa-search nav-icon"></i>
                                    <p>販売情報検索</p>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a href="#" class="nav-link">
                                    <i class="far fa-circle nav-icon"></i>
                                    <p>商品マスタ</p>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a href="#" class="nav-link">
                                    <i class="far fa-circle nav-icon"></i>
                                    <p>配送先マスタ</p>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a href="#" class="nav-link">
                                    <i class="fas fa-download nav-icon"></i>
                                    <p>データダウンロード</p>
                                </a>
                            </li>
                        </ul>
                    </li>
                    {{-- TMS Menu --}}
                    <li class="nav-item menu-open">
                        <a href="#" class="nav-link ">
                            <i class="nav-icon fas fa-solid fa-truck"></i>
                            <p>
                                TMS MENU
                                <i class="right fas fa-angle-left"></i>
                            </p>
                        </a>
                        <ul class="nav nav-treeview">
                            <li class="nav-item">
                                <a href="" class="nav-link ">
                                    <i class="far fa-circle nav-icon"></i>
                                    <p>配送会社</p>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a href="#" class="nav-link">
                                    <i class="far fa-circle nav-icon"></i>
                                    <p>車両番号・車番</p>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a href="#" class="nav-link">
                                    <i class="far fa-circle nav-icon"></i>
                                    <p>積載率</p>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a href="#" class="nav-link">
                                    <i class="far fa-circle nav-icon"></i>
                                    <p>総容積</p>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a href="#" class="nav-link">
                                    <i class="far fa-circle nav-icon"></i>
                                    <p>総個数</p>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a href="#" class="nav-link">
                                    <i class="far fa-circle nav-icon"></i>
                                    <p>納入先数</p>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a href="#" class="nav-link">
                                    <i class="far fa-circle nav-icon"></i>
                                    <p>温度帯</p>
                                </a>
                            </li>
                        </ul>
                    </li>
                    {{-- WMS MENU --}}
                    <li class="nav-item menu-open">
                        <a href="#" class="nav-link ">
                            <i class="nav-icon fas fa-solid fa-home"></i>
                            <p>
                                WMS MENU
                                <i class="right fas fa-angle-left"></i>
                            </p>
                        </a>
                        <ul class="nav nav-treeview">
                            <li class="nav-item">
                                <a href="" class="nav-link ">
                                    <i class="far fa-circle nav-icon"></i>
                                    <p>得意先別</p>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a href="#" class="nav-link">
                                    <i class="far fa-circle nav-icon"></i>
                                    <p>商品別</p>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a href="#" class="nav-link">
                                    <i class="far fa-circle nav-icon"></i>
                                    <p>出荷予定時刻</p>
                                </a>
                            </li>

                            <nav class="mt-2">
                                <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false" />
                                <li class="nav-item menu-open">
                                    <a href="#" class="nav-link active">
                                        <i class="nav-icon fas fa-home"></i>
                                        <p>
                                            OMS MENU
                                            <i class="right fas fa-angle-left"></i>
                                        </p>
                                    </a>
                                    <ul class="nav nav-treeview">
                                        <li class="nav-item">
                                            <a href="/order-status-search" class="nav-link">
                                                <i class="fas fa-search nav-icon"></i>
                                                <p>受注情報検索</p>
                                            </a>
                                        </li>
                                        <li class="nav-item">
                                            <a href="/order-registration" class="nav-link ">
                                                <i class="fas fa-search nav-icon"></i>
                                                <p>発注登録</p>
                                            </a>
                                        </li>
                                        <li class="nav-item">
                                            <a href="/product-master" class="nav-link">
                                                <i class="far fa-circle nav-icon"></i>
                                                <p>商品マスタ</p>
                                            </a>
                                        </li>
                                        <li class="nav-item">
                                            <a href="#" class="nav-link">
                                                <i class="far fa-circle nav-icon"></i>
                                                <p>配送先マスタ</p>
                                            </a>
                                        </li>
                                        <li class="nav-item">
                                            <a href="#" class="nav-link">
                                                <i class="fas fa-download nav-icon"></i>
                                                <p>データダウンロード</p>
                                            </a>
                                        </li>
                                    </ul>
                                </li>
                                {{-- TMS Menu --}}
                                <li class="nav-item ">
                                    <a href="#" class="nav-link ">
                                        <i class="nav-icon fas fa-solid fa-truck"></i>
                                        <p>
                                            TMS MENU
                                            <i class="right fas fa-angle-left"></i>
                                        </p>
                                    </a>
                                    <ul class="nav nav-treeview">
                                        <li class="nav-item">
                                            <a href="" class="nav-link ">
                                                <i class="far fa-circle nav-icon"></i>
                                                <p>配送会社</p>
                                            </a>
                                        </li>
                                        <li class="nav-item">
                                            <a href="#" class="nav-link">
                                                <i class="far fa-circle nav-icon"></i>
                                                <p>車両番号・車番</p>
                                            </a>
                                        </li>
                                        <li class="nav-item">
                                            <a href="#" class="nav-link">
                                                <i class="far fa-circle nav-icon"></i>
                                                <p>積載率</p>
                                            </a>
                                        </li>
                                        <li class="nav-item">
                                            <a href="#" class="nav-link">
                                                <i class="far fa-circle nav-icon"></i>
                                                <p>総容積</p>
                                            </a>
                                        </li>
                                        <li class="nav-item">
                                            <a href="#" class="nav-link">
                                                <i class="far fa-circle nav-icon"></i>
                                                <p>総個数</p>
                                            </a>
                                        </li>
                                        <li class="nav-item">
                                            <a href="#" class="nav-link">
                                                <i class="far fa-circle nav-icon"></i>
                                                <p>納入先数</p>
                                            </a>
                                        </li>
                                        <li class="nav-item">
                                            <a href="#" class="nav-link">
                                                <i class="far fa-circle nav-icon"></i>
                                                <p>温度帯</p>
                                            </a>
                                        </li>
                                    </ul>
                                </li>
                                {{-- WMS MENU --}}
                                <li class="nav-item ">
                                    <a href="#" class="nav-link ">
                                        <i class="nav-icon fas fa-solid fa-home"></i>
                                        <p>
                                            WMS MENU
                                            <i class="right fas fa-angle-left"></i>
                                        </p>
                                    </a>
                                    <ul class="nav nav-treeview">
                                        <li class="nav-item">
                                            <a href="" class="nav-link ">
                                                <i class="far fa-circle nav-icon"></i>
                                                <p>得意先別</p>
                                            </a>
                                        </li>
                                        <li class="nav-item">
                                            <a href="#" class="nav-link">
                                                <i class="far fa-circle nav-icon"></i>
                                                <p>商品別</p>
                                            </a>
                                        </li>
                                        <li class="nav-item">
                                            <a href="#" class="nav-link">
                                                <i class="far fa-circle nav-icon"></i>
                                                <p>出荷予定時刻</p>
                                            </a>
                                        </li>

                                        <div class="content-wrapper">
                                            <router-view />
                                        </div>

                                        <aside class="control-sidebar control-sidebar-dark">
                                            <div class="p-3">
                                                <h5>Title</h5>
                                                <p>Sidebar content</p>
                                            </div>
                                        </aside>

                                        <footer class="main-footer">
                                            Copyright © 2023 HRS All rights reserved.
                                        </footer>
            </div>
            @endsection -->