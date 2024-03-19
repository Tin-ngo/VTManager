<?php

namespace App\Http\Component;

/**
 * ResponseComponent
 *
 * Response component for the controller
 */
class ResponseComponent
{
    protected $code;
    /**
     * setResponseBody private Method
     * This creates a response blueprint
     *
     * @param array $body response body
     *
     * @return object response
     */
    private function responseBody($body)
    {
        $response = response(json_encode($body, JSON_UNESCAPED_UNICODE), $this->code)
            ->header('Content-Type', 'application/json');

        return $response;
    }

    /**
     * Success response
     *
     * @param array $data - data being returned
     *
     * @return response
     */
    public function success($data = [])
    {
        $body = [
            'status_code' => 200,
            'message' => __('message.success'),
        ];
        if ($data) {
            $body['data'] = $data;
        }
        $this->code = 200;

        return $this->responseBody($body);
    }

    /**
     * Not found response
     *
     * @return response
     */
    public function notFound($message = [])
    {
        $body = [
            'status_code' => 404,
            'message' => __('message.not_found'),
        ];
        if ($message) {
            $body['message'] = $message;
        }
        $this->code = 404;

        return $this->responseBody($body);
    }

    /**
     * Validation response return with format
     *
     * @param array $data - data being returned
     *
     * @return response
     */
    public function validationErrorWithData($data = [], $message = '')
    {
        $body = [
            'status_code' => 422,
            'message' => __('message.invalid_parameters'),
        ];

        if ($data) {
            $body['data'] = $data;
        }

        if ($message) {
            $body['message'] = $message;
        }

        $this->code = 422;

        return $this->responseBody($body);
    }


    /**
     * Validation error response
     *
     * @param array $error - error message bag of validation
     *
     * @return response
     */
    public function validationError($error = [])
    {
        $body = [
            'status_code' => 422,
            'message' => __('message.invalid_parameters'),
        ];

        if (!empty($error)) {
            $body['data'] = $this->errorFormat($error);
        }
        $this->code = 422;

        return $this->responseBody($body);
    }

    /**
     * Error formatter
     *
     * @param array $errors - error message bag of validation
     *
     * @return response
     */
    private function errorFormat($errors)
    {
        $errorMessage = [];
        if (is_array($errors)) {
            foreach ($errors as $field => $value) {
                $reversedArray = array_reverse($value);
                $firstItem = array_pop($reversedArray);

                //Check if nested error messages
                if (is_array($firstItem)) {
                    $subFieldErrors = [];

                    foreach ($value as $input => $inputFields) {
                        foreach ($inputFields as $subfield => $subfieldValue) {
                            $subFieldErrors[$input][] = [
                                'field_name' => $subfield,
                                'message' => __(reset($subfieldValue))
                            ];
                        }
                    }

                    $errorMessage[] = [
                        'field_name' => $field,
                        'sub_field_errors' => $subFieldErrors,
                    ];
                } else {
                    $errorMessage[] = [
                        'field_name' => $field,
                        'message' => __($firstItem),
                    ];
                }
            }
        } else {
            $errorMessage = [
                'message' => $errors,
            ];
        }

        return $errorMessage;
    }

    /**
     * Method not allowed response
     *
     * @return response
     */
    public function methodNotAllowed()
    {
        $body = [
            'status_code' => 405,
            'message' => __('message.method_not_allowed'),
        ];
        $this->code = 405;

        return $this->responseBody($body);
    }

    /**
     * Forbidden response
     *
     * @return response
     */
    public function forbidden()
    {
        $body = [
            'status_code' => 403,
            'message' => __('message.action_not_allowed'),
        ];
        $this->code = 403;

        return $this->responseBody($body);
    }

    /**
     * Unauthorized response
     *
     * @param array $data - data to response
     *
     * @return response
     */
    public function unauthorized($data = [])
    {
        $body = [
            'status_code' => 401,
            'message' => __('message.unauthorized_action'),
        ];
        if ($data) {
            $body['data'] = $data;
        }
        $this->code = 401;

        return $this->responseBody($body);
    }

    /**
     * Unauthorized response
     *
     * @param array $data - data to response
     *
     * @return response
     */
    public function authFailed()
    {
        $body = [
            'status_code' => 401,
            'message' => __('auth.failed'),
        ];
        $this->code = 401;

        return $this->responseBody($body);
    }

    /**
     * Internal Server Error response
     *
     * @return response
     */
    public function internalServerError()
    {
        $body = [
            'status_code' => 500,
            'message' => __('message.internal_server_error'),
        ];
        $this->code = 500;

        return $this->responseBody($body);
    }

    /**
     * Internal Server Error response
     *
     * @param int $code
     * @param string $message
     *
     * @return response
     */
    public function customResponse($code = 500, $message = null)
    {
        $body = [
            'status_code' => $code,
            'message' => ($message) ? $message : __('message.internal_server_error'),
        ];
        $this->code = $code;

        return $this->responseBody($body);
    }

    public function errorResponse($code = 500, $message = null)
    {
        $body = [
            'status_code' => $code,
            'message' => is_array($message) ? $message : (($message) ? $message : __('message.internal_server_error')),
        ];
        $this->code = $code;

        return $this->responseBody($body);
    }

}
