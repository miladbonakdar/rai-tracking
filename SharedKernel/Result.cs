using Newtonsoft.Json;

namespace SharedKernel
{
    public class Result<TContent>
    {
        public string Message { get; }
        public int StatusCode { get; }
        public bool Ok { get; }
        public TContent Data { get; }

        protected Result(string message, int statusCode, bool ok, TContent data)
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
    
    public class Result : Result<bool>
    {
        protected Result(string message, int statusCode, bool ok, bool data) 
            : base(message, statusCode, ok, data)
        {
        }
        
        
        public new static Result Success(string message = "با موفقیت انجام شد", bool data = true)
            => new Result(message, 200, true, data);
        public new static Result Error(string message = "مشکلی رخ داده است", bool data = false)
            => new Result(message, 500, false, data);
        public new static Result BadRequest(string message = "درخواست شما نا معتبر می باشد", bool data = false)
            => new Result(message, 400, false, data);
        public new static Result NotFound(string message = "درخواست شما یافت نشد", bool data = false)
            => new Result(message, 404, false, data);
        public new static Result Create(string message, int statusCode, bool ok, bool data = default)
            => new Result(message, statusCode, ok, data);
    }
}
