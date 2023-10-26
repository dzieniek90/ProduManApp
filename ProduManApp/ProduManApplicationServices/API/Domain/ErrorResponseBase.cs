using ProduManApplicationServices.API.ErrorHandling;

namespace ProduManApplicationServices.API.Domain;

public class ErrorResponseBase
{
    public ErrorModel Error { get; set; }
}

public class ErrorModel
{
    public ErrorModel(string error)
    {
        Error = error;
    }
    public string Error { get;}
}