using Microsoft.AspNetCore.Http;

namespace TadweerHub.PL.Mock
{
    // مؤقت: بيحاكي "المستخدم الحالي" من كوكي بيتحط عن طريق /Dev/Role/{role}.
    // لما نركّب تسجيل الدخول الحقيقي، الملف ده بيتمسح وبنقرأ من User.Identity.
    public static class MockSession
    {
        public const string CookieName = "tw-role";

        public static string Role(HttpContext ctx) => ctx.Request.Cookies[CookieName] ?? "guest";

        public static (string Label, string Name, string Sub, string Initials) User(string role) => role switch
        {
            "workshop" => ("الورشة",  "ورشة النور",        "WS-409",  "ور"),
            "factory"  => ("المصنع",  "مصنع النيل للنسيج", "FAC-102", "مص"),
            "driver"   => ("السائق",  "محمود السيد",       "DR-318",  "مح"),
            "admin"    => ("الإدارة", "إدارة تدوير",       "Admin",   "أد"),
            _          => ("", "", "", "")
        };

        // الصفحة الرئيسية لكل دور (لوحته)
        public static (string Controller, string Action) HomeRoute(string role) => role switch
        {
            "workshop" => ("Lots", "Index"),
            "factory"  => ("Factory", "Dashboard"),
            "driver"   => ("Driver", "Index"),
            "admin"    => ("Admin", "Dashboard"),
            _          => ("Home", "Index")
        };
    }
}
