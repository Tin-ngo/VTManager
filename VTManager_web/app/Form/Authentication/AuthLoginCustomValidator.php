<?php

namespace App\Form\Authentication;

/**
 * AuthLoginCustomValidator
 * This call a form validator class
 */
class AuthLoginCustomValidator
{
    /**
     * __construct
     */
    public function __construct()
    {
    }

    /**
     * validate
     *
     * @param array  $request
     * @param string $class
     *
     * @return JSON || boolean
     */
    public function validate($request, string $class)
    {
        // Declare object
        $FormValidator = str_replace("{{$class}}", $class, "\App\Form\Authentication\{$class}");
        $formValidator = new $FormValidator();
        // Validate inputs
        $validator = $formValidator->validate($request);

        if ($validator->fails()) {
            return $validator->errors()->messages();
        }

        return true;
    }
}
