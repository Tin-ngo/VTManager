<?php
namespace App\Helpers;

class CommonHelper
{
    public static function formatMessagesError($data )
    {
        foreach ($data as $key => &$item) {
            if (is_array($item) && count($item) === 1) {
                $data[$key] = $item[0];
            }
        }    
        return $data;
    }

    public static function removeNullValues($array) {
        return array_filter($array, function ($value) {
            return $value !== null;
        });
    }

    public static function convertToSnakeCase($input) {
        $snakeCase = preg_replace('/([a-z])([A-Z])/', '$1_$2', $input);
        $snakeCase = strtolower($snakeCase);
        return $snakeCase;
    }
    
}