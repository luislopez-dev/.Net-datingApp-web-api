﻿
namespace datingApp.Error;

/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public class ApiException
{
    public int Status { get; set; }
    public string Message { get; set; }
    public string Details { get; set; }

    public ApiException(int status, string message, string details)
    {
        Status = status;
        Message = message;
        Details = details;
    }
}