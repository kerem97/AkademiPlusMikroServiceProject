using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AkademiPlusMikroServiceProje.Shared.Dtos
{
    public class Response<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        [JsonIgnore]
        public bool IsSuccessFul { get; set; }
        public List<string> Errors { get; set; }


        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { StatusCode = statusCode, Data = default(T), IsSuccessFul = true };
        }
        public static Response<T> Success(int statusCode, T data)
        {
            return new Response<T> { StatusCode = statusCode, Data = data, IsSuccessFul = true };
        }
        public static Response<T> Fail(int statusCode, string error)
        {
            return new Response<T> { Errors = new List<string> { error }, StatusCode = statusCode, IsSuccessFul = false };
        }
        public static Response<T> Fail(int statusCode, List<string> errors)
        {
            return new Response<T> { Errors = errors, StatusCode = statusCode, IsSuccessFul = false };
        }
    }
}
