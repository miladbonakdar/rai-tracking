using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel
{
    public static class Dic
    {
        public static class CommandNames
        {
            public const string UpdateStatus = "بروزرسانی موقعیت تعمیرکار";
            public const string SetOtdrValue = "ثبت تست otdr";
            public const string NewProject = "عملیات حدید";
            public const string EditProject = "ویرایش عملیات";
            public const string FinishProject = "اتمام عملیات";
            public const string CancelProject = "غیرفعال کردن عملیات";
            public const string SetSetting = "بروزرسانی تنظیمات تعمیرکار";
        }
    }
}
