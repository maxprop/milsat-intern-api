using MilsatInternAPI.Enums;

namespace MilsatInternAPI.ViewModels
{
    public class GenericResponse<T>
    {
        public bool IsSuccessful { get; set; }
        public ResponseCode ResponseCode { get; set; }
        //public string ResponseMessage { get; set; }
        public T Data { get; set; } 
    }
}
