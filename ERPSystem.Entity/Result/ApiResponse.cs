using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.Result
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ErrorInformation? ErrorInformation { get; set; }

        public ApiResponse(T _data ,int _statusCode,string _message,ErrorInformation _errorInformation)
        {
            this.Data = _data;
            this.StatusCode = _statusCode;
            this.Message = _message;
            this.ErrorInformation = _errorInformation;
        }
        public ApiResponse(string _message, int _statusCode, ErrorInformation _errorInformation)
        {
            this.StatusCode = _statusCode;
            this.Message = _message;
            this.ErrorInformation = _errorInformation;
        }
        public ApiResponse(T _data, string _message,int _statusCode)
        {
            this.Data= _data;
            this.StatusCode = _statusCode;
            this.Message = _message;
        }           
        public ApiResponse(string _message, int _statusCode)
        {
            this.StatusCode = _statusCode;
            this.Message = _message;
        }          
        public ApiResponse(T _data,string _message)
        {
            this.Data= _data;
            this.Message = _message;
        }


        public static ApiResponse<T> SuccesWithData(T data, string message = "İşlem Başarılı", int statusCode = (int)HttpStatusCode.OK)
        {
            return new ApiResponse<T>(data, message, statusCode);
        }
        public static ApiResponse<T> SuccesWithOutData(string message = "İşlem Başarılı", int statusCode = (int)HttpStatusCode.OK)
        {
            return new ApiResponse<T>(message, statusCode);
        }
        public static ApiResponse<T> SuccesNoDataFound(string message = "Sonuç bulunamadı!", int statusCode = (int)HttpStatusCode.NotFound)
        {
            return new ApiResponse<T>(message, statusCode, ErrorInformation.NotFound());
        }
        public static ApiResponse<T> FieldValdationError(List<string>? errorMessages = null, string message = "Hata Oluştu", int statusCode = (int)HttpStatusCode.BadRequest)
        {
            return new ApiResponse<T>(message, statusCode, ErrorInformation.FieldValidationError(errorMessages));
        }

        public static ApiResponse<T> AuthenticationError(string message, int statusCode = (int)HttpStatusCode.NotFound)
        {
            return new ApiResponse<T>(message, statusCode, ErrorInformation.AuthenticationError());
        }

        public static ApiResponse<T> TokenValidationError()
        {
            return new ApiResponse<T>("Token Doğrulama Hatası!", (int)HttpStatusCode.Unauthorized, ErrorInformation.TokenValidationError());
        }

        public static ApiResponse<T> TokenNotFound()
        {
            return new ApiResponse<T>("Hata Oluştu", (int)HttpStatusCode.Unauthorized, ErrorInformation.TokenNotFoundError());
        }
        public static ApiResponse<T> Error()
        {
            return new ApiResponse<T>("Bir Hata Oluştu, Daha Sonra Tekrar Deneyiniz!!", (int)HttpStatusCode.InternalServerError, ErrorInformation.GlobalError());
        }

    }
}
