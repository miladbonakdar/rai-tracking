using Newtonsoft.Json;

namespace SharedKernel
{
    public class Result<TContent>
    {
        public string Message { get; }
        public int StatusCode { get; }
        public bool Ok { get; }
        public TContent Data { get; }

        private Result(string message, int statusCode, bool ok, TContent data)
        {
            Message = message;
            StatusCode = statusCode;
            Ok = ok;
            Data = data;
        }

        public static Result<TContent> Success(string message = "با موفقیت انجام شد", TContent data = default)
            => new Result<TContent>(message, 200, true, data);
        public static Result<TContent> Error(string message = "مشکلی رخ داده است", TContent data = default)
            => new Result<TContent>(message, 500, false, data);
        public static Result<TContent> BadRequest(string message = "درخواست شما نا معتبر می باشد", TContent data = default)
            => new Result<TContent>(message, 400, false, data);
        public static Result<TContent> NotFound(string message = "درخواست شما یافت نشد", TContent data = default)
            => new Result<TContent>(message, 404, false, data);
        public static Result<TContent> Create(string message, int statusCode, bool ok, TContent data = default)
            => new Result<TContent>(message, statusCode, ok, data);

        public override string ToString()
            => JsonConvert.SerializeObject(this);
    }
}
