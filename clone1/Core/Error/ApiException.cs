﻿namespace clone1.Core.Error;


/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
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