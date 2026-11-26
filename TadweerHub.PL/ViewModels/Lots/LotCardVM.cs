namespace TadweerHub.PL.ViewModels.Lots;

public class LotCardVM
{
    public string Code { get; set; } = "";          
    public string Name { get; set; } = "";
    public string Material { get; set; } = "";      
    public string Condition { get; set; } = "";     
    public string ColorName { get; set; } = "";
    public string ColorHex { get; set; } = "#C4962C";
    public bool IsLight { get; set; }               
    public decimal WeightKg { get; set; }
    public int RollsCount { get; set; }
    public decimal Price { get; set; }              
    public string Governorate { get; set; } = "";
    public string Factory { get; set; } = "";
    public string Status { get; set; } = "active";  
}
