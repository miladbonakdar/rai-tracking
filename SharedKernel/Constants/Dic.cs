namespace SharedKernel.Constants
{
    public static class Dic
    {
        public static class ProjectPhases
        {
            public const string Unknown = "نا معلوم";
            public const string Started = "آغاز شده است";
            public const string Finished = "پایان یافته است";
            public const string Canceled = "لغو شده است";
        }

        public static class CommandNames
        {
            public const string UpdateStatus = "بروزرسانی موقعیت تعمیرکار";
            public const string SetOtdrValue = "ثبت تست otdr";
            public const string NewProject = "عملیات جدید";
            public const string EditProject = "ویرایش عملیات";
            public const string FinishProject = "اتمام عملیات";
            public const string CancelProject = "غیرفعال کردن عملیات";
            public const string SetSetting = "بروزرسانی تنظیمات تعمیرکار";
        }

        public static class AgentEventNames
        {
            public const string NewMissionStarted = "عملیات جدید آغاز شد";
            public const string MissionCanceledFromServer = "عملیات از سمت سرور لغو شد";
            public const string TheAgentIsInFailureZone = "تعمیرکار در محل خرابی می باشد";
            public const string TheAgentFoundTheFailureLocation = "تعمیرکار محل دقیق خرابی را پیدا کرد";
            public const string GpsIsTurnedOff = "جی پی اس تعمیرکار خاموش شد";
            public const string GpsIsTurnedOn = "جی پی اس تعمیرکار زوشن شد";
            public const string GpsIsStillOff = "جی پی اس تعمیرکار  همچنان خاموش می باشد";
            public const string MissionTimedOut = "مدت زمان انجام عملیات تمام شد";
            public const string LowBattery = "باتری گوشی تعمیرکار کم می باشد";
            public const string LowSpeed = "سرعت تعمیر کار کم می باشد";
            public const string GotOutOfFailureZone = "تعمیر کار از محل خرابی خارج شد";
            public const string GotOutOfDepoZone = "تعمیر کار از محل دپو خارج شد";
            public const string ResumedAfterPhoneRestart = "پروژه بعد از روشن شدن دوباره از سر گرفته شد";
            public const string MissionFinishedAutomatically = "پروژه به صورت اتوماتیک پایان یافت";
            public const string TheFailureLocationDetectedAutomatically = "محل خرابی به صورت اتوماتیک پیدا شد";
            public const string IncomingCallFromWhitelist = "تماس دریافتی مجاز";
            public const string OutgoingCallToWhitelist = "برقراری تماس با شماره ی مجاز";
            public const string InvalidIncomingCall = "تماس دریافتی غیر مجاز";
            public const string InvalidOutgoingCall = "برقراری تماس با شماره ی غیر مجاز";
            public const string IncomingSMSFromWhitelist = "پیامک دریافتی مجاز";
            public const string OutgoingSMSToWhitelist = "ارسال پیامک به شماره ی مجاز";
            public const string InvalidIncomingSMS = "پیامک دریافتی از شماره ی غیر مجاز";
            public const string InvalidOutgoingSMS = "ارسال پیامک به شماره ی غیر مجاز";
            public const string AgentLoggedOut = "تعمیرکار از سیستم خارج شد";
            public const string AgentLoggedIn = "تعمیرکار وارد سیستم شد";
            public const string AgentIsNotMoving = "تعمیرکار حرکتی به سمت محل خرابی ندارد";
            public const string AgentCameBackToTheDepo = "تعمیرکار به محل دپو بازگشت";
            public const string OTDRTestCaptured = "تست otdr انجام شد";
            public const string OTDRTestIsNotCaptured = "تست otdr انجام نشده است";
            public const string TheAgentStartMoving = "تعمیرکار شروع به حرکت کرد";
            public const string MissionEdited = "عملیات با موفقیت بروزرسانی شد";
            public const string MissionFinished = "عملیات با موفقیت تمام شد";
            public const string MissionCanceledByAgent = "عملیات از سمت تعمیرکار لغو شد";
            public const string StatusCaptured = "جزئیات اطلاعات تعمیرکار بروزرسانی شد";
        }
    }
}