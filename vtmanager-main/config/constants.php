<?php
return [
    'database' => [
        'SLC_MST_91_INFORMATION' => [
            'DATA_DIV' => [ // データ区分
                'INFORMATION_FOR_ALL_USER' => '0', // は全ユーザー対象
                'NOTICE' => '1', // "01"：お知らせ
                'OPENRATION_MANUAL' => '2' // "02"：操作マニュアル,
            ]
        ],
        // ＭＳＴ＿Ｍ００１ユーザー
        'SLC_MST_01_USER' => [
            'CONTROL_FLG' => [ // 管理フラグ
                'STOP' => '0', // 0-停止
                'IN_USE' => '1', // 1-利用中
                'TRIAL' => '2', //  2-お試し
                'WAIT_FOR_STOP' => '3' // 3-停止待ち,
            ],
            [
                'USER_CATEGORY' => [
                    'PERCHASER' => '1', //発注者
                    'SHIPPER' => '2', //荷主
                    'WAREHOUSE' => '3', //倉庫
                    'SHIP_COMPANY' => '4', // 配送会社
                    'SYSTEM_ADMINSTRATOR' => '9', // システム管理者
                    'INFORMATION_FOR_ALL_USER' => '0' // は全ユーザー対象
                ]
            ]
        ],
        'SLC_WMS_T01_RECEIVING' => [
            'ARRIVAL_CONFIRMATION_FLG' => [ // 入荷確定フラグ
                'NOT_IN_STOCK' => '0', // 0-未入荷　　
                'ARRIVED' => '1', // 1-入荷済
                'RECEIPT_CONFIRM' => '2', // 2-入庫確定済
            ]
        ],
        'SLC_WMS_T02_SHIPPING_INSTRUCTION_HEADER' => [
            'CONFIRM_FLG' => [ // 確定フラグ
                'UNCONFIRM' => '0', // 0-未確定　　　
                'CONFIRM' => '1', // 1-確定済
            ]
        ],
        'SlcMst23ImportDefinition' => [
            'DATA_TYPE' => [ // データ種別
                'EXPECTED_ARRIVAL' => '01', // 1-入荷予定
                'RECEIPT_RECORD' => '02', // 2-入荷実績
                'SCHEDULE_SHIP' => '03', // 3-出荷予定
                'SHIP_RESULT' => '04', // 4-出荷実績
                'INSTOCK' => '05', // 5-在庫
                'ORDER' => '06', // 6-受注
                'MASTER_SYSTEM' => '07', // 7-マスタ系
            ]
        ]
    ]
];
