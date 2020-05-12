using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Infrastructure
{
    class KavenegarApi
    {
        private readonly string _apiKey;

        public KavenegarApi(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<AccountInfo> AccountInfo()
        {
            try
            {
                var res = await RequestFactory($"/account/info.json");
                if (!res.IsSuccessStatusCode)
                    throw KavehnegarApiException.Factory((int) res.StatusCode);

                var info = await ReadFromResponseContent<AccountInfo>(res.Content);
                return info;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Send(string lineNumber, string receiver, string content)
        {
            try
            {
                var res = await RequestFactory($"/sms/send.json?receptor={receiver}" +
                                               $"&message={HttpUtility.UrlEncode(content)}&sender={lineNumber}");
                if (!res.IsSuccessStatusCode)
                {
                    throw KavehnegarApiException.Factory((int) res.StatusCode);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task SendMany(string lineNumber, IEnumerable<string> receivers, string content)
        {
            var builder = new StringBuilder();
            foreach (var receiver in receivers) builder.Append(receiver + ",");
            var phones = builder.ToString();
            return Send(lineNumber, phones.Substring(0, phones.Length - 1), content);
        }

        private Task<HttpResponseMessage> RequestFactory(string fullPath)
        {
            var client = new HttpClient();
            return client.GetAsync($"https://api.kavenegar.com/v1/{_apiKey}{fullPath}");
        }

        private async Task<T> ReadFromResponseContent<T>(HttpContent content) where T : class
        {
            var contentString = await content.ReadAsStringAsync();
            var obj = JObject.Parse(contentString);
            return obj["entries"].ToObject<T>();
        }
    }


    class KavehnegarApiException : Exception
    {
        private int Code { get; }

        public KavehnegarApiException(int code, string message) : base(message)
        {
            Code = code;
        }

        public static KavehnegarApiException Factory(int code)
        {
            switch (code)
            {
                case 401:
                    return new KavehnegarApiException(code, "حساب کاربری غیر فعال است");
                case 403:
                    return new KavehnegarApiException(code, "حساب کاربری معتبر نمی‌باشد");
                case 400:
                    return new KavehnegarApiException(code, "پارامترها ناقص هستند");
                case 402:
                    return new KavehnegarApiException(code, "عملیات ناموفق بود");
                case 404:
                    return new KavehnegarApiException(code, "	متدی با این نام پیدا نشده است");
                case 405:
                    return new KavehnegarApiException(code, "متد فراخوانی Get یا Post اشتباه است");
                case 409:
                    return new KavehnegarApiException(code, "سرور قادر به پاسخگوئی نیست بعدا تلاش کنید");
                case 411:
                    return new KavehnegarApiException(code, "دریافت کننده نامعتبر است");
                case 412:
                    return new KavehnegarApiException(code, "ارسال کننده نامعتبر است");
                case 413:
                    return new KavehnegarApiException(code, "پیام خالی است و یا طول پیام بیش از حد مجاز می‌باشد");
                case 414:
                    return new KavehnegarApiException(code, "حجم درخواست بیشتر از حد مجاز است");
                case 415:
                    return new KavehnegarApiException(code, "اندیس شروع بزرگ تر از کل تعداد شماره های مورد نظر است");
                case 416:
                    return new KavehnegarApiException(code, "IP سرویس مبدا با تنظیمات مطابقت ندارد");
                case 417:
                    return new KavehnegarApiException(code, "تاریخ ارسال اشتباه است و فرمت آن صحیح نمی باشد");
                case 418:
                    return new KavehnegarApiException(code, "اعتبار شما کافی نمی‌باشد");
                case 419:
                    return new KavehnegarApiException(code, "طول آرایه متن و گیرنده و فرستنده هم اندازه نیست");
                case 420:
                    return new KavehnegarApiException(code, "استفاده از لینک در متن پیام برای شما محدود شده است");
                case 422:
                    return new KavehnegarApiException(code, "داده ها به دلیل وجود کاراکتر نامناسب قابل پردازش نیست");
                case 424:
                    return new KavehnegarApiException(code, "الگوی مورد نظر پیدا نشد");
                case 426:
                    return new KavehnegarApiException(code, "استفاده از این متد نیازمند سرویس پیشرفته می‌باشد");
                case 427:
                    return new KavehnegarApiException(code, "استفاده از این خط نیازمند ایجاد سطح دسترسی می باشد");
                case 428:
                    return new KavehnegarApiException(code, "ارسال کد از طریق تماس تلفنی امکان پذیر نیست");
                case 429:
                    return new KavehnegarApiException(code, "IP محدود شده است");
                case 431:
                    return new KavehnegarApiException(code, "	ساختار کد صحیح نمی‌باشد");
                case 432:
                    return new KavehnegarApiException(code, "پارامتر کد در متن پیام پیدا نشد");
                default:
                    return new KavehnegarApiException(500, "unknown kavehnegar http code");
            }
        }
    }


    class AccountInfo
    {
        public AccountInfo()
        {
        }

        [JsonProperty("remaincredit")] public long RemainingCredit { get; set; }
        [JsonProperty("expiredate")] public long ExpireDateUnixTime { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
        
        [JsonIgnore] public DateTime ExpireDate => 
            new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc)
                .AddSeconds( ExpireDateUnixTime ).ToLocalTime();
    }
}