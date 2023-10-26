namespace ProduManApplicationServices.API.Domain;

public class BaseResponse<T> : ErrorResponseBase
{
    public T Data { get; set; }
}