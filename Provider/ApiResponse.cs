﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LuciaTech.Helper.Provider
{
    public class ApiResponse<T>
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public T data { get; set; }

        public ApiResponse<T> Success(T _data, string _message = "success")
        {
            return new ApiResponse<T> { data = _data, message = _message, statusCode = 200 };
        }

        public ApiResponse<T> BadRequest(T _data, string _message = "failed")
        {
            return new ApiResponse<T> { data = _data, message = _message, statusCode = 400 };
        }

        public ApiResponse<T> NotFound(T _data, string _message = "not found")
        {
            return new ApiResponse<T> { data = _data, message = _message, statusCode = 404 };
        }

        public ApiResponse<T> Created(T _data, string _message = "created")
        {
            return new ApiResponse<T> { data = _data, message = _message, statusCode = 201 };
        }

        public ApiResponse<T> UnAthorised(T _data, string _message = "failed")
        {
            return new ApiResponse<T> { data = _data, message = _message, statusCode = 403 };
        }
    }
}
