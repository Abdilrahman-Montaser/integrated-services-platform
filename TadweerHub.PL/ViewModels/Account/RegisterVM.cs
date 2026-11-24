using System.ComponentModel.DataAnnotations;

namespace TadweerHub.PL.ViewModels.Account;

public class RegisterVM
{
    [Required(ErrorMessage = "اختر نوع الحساب")]
    public string Role { get; set; } = "workshop"; // workshop | factory | driver

    [Required(ErrorMessage = "الاسم بالكامل مطلوب")]
    public string FullName { get; set; } = "";

    [Required(ErrorMessage = "رقم الهاتف مطلوب")]
    public string Phone { get; set; } = "";

    [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
    [EmailAddress(ErrorMessage = "صيغة البريد الإلكتروني غير صحيحة")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "كلمة المرور مطلوبة")]
    [MinLength(6, ErrorMessage = "كلمة المرور 6 أحرف على الأقل")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";

    [Required(ErrorMessage = "اختر المحافظة")]
    public string Governorate { get; set; } = "القاهرة";

    // حقول المصنع / الورشة
    public string? EntityName { get; set; }
    public string? Address { get; set; }

    // حقول السائق
    public string? VehicleType { get; set; }
    public string? PlateNumber { get; set; }
}