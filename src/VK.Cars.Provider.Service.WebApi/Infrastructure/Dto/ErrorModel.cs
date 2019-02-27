namespace VK.Cars.Provider.Service.WebApi.Infrastructure.Dto
{
    public class ErrorModel
    {
        public int Code { get; set; }

        public string ErrorCode { get; set; }

        public string Message { get; set; }

        public string TraceId { get; set; }

        public object Data { get; set; }
    }
}
