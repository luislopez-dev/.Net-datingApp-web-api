﻿/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */
namespace clone1.Core.Error;

public class ApiException
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string Details { get; set; }

    public ApiException(int statusCode, string message, string details)
    {
        StatusCode = statusCode;
        Message = message;
        Details = details;
    }
}