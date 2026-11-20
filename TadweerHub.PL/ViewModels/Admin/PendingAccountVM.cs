namespace TadweerHub.PL.ViewModels.Admin;

// حساب بانتظار مراجعة الأدمن (شاشة الحسابات المعلقة)
public class PendingAccountVM
{
    public int Id { get; set; }
    public string Name { get; set; } = "";             // اسم الشركة أو الشخص
    public string Role { get; set; } = "factory";      // factory | workshop | driver
    public string Governorate { get; set; } = "";
    public List<string> Documents { get; set; } = new(); // أسماء المستندات المرفوعة
    public string? MissingDocument { get; set; }         // مستند ناقص (لو فيه)
    public DateTime SubmittedAt { get; set; }
}
