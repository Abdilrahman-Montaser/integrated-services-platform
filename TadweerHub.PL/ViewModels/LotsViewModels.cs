namespace TadweerHub.PL.ViewModels;   // ⚠️ عدّل الـ namespace لو مشروعك بيستخدم غيره

// ───────────── الفلتر (بيتربط تلقائياً من الـ Query String) ─────────────
public class LotFilter
{
    public string? Q { get; set; }
    public List<string> Materials { get; set; } = new();
    public int? MinKg { get; set; }
    public int? MaxKg { get; set; }
    public string? Gov { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string Sort { get; set; } = "newest";
    public int Page { get; set; } = 1;

    public LotFilter Clone() => new()
    {
        Q = Q, Materials = new List<string>(Materials), MinKg = MinKg, MaxKg = MaxKg,
        Gov = Gov, MinPrice = MinPrice, MaxPrice = MaxPrice, Sort = Sort, Page = Page
    };

    // بيبني الـ query string (من غير page لو = 1)
    public string ToQueryString(int? page = null)
    {
        var parts = new List<string>();
        void Add(string k, object? v)
        {
            if (v is null || string.IsNullOrWhiteSpace(v.ToString())) return;
            parts.Add($"{k}={Uri.EscapeDataString(v.ToString()!)}");
        }
        Add("q", Q);
        foreach (var m in Materials) Add("materials", m);
        Add("minKg", MinKg); Add("maxKg", MaxKg);
        Add("gov", Gov);
        Add("minPrice", MinPrice); Add("maxPrice", MaxPrice);
        if (Sort != "newest") Add("sort", Sort);
        var p = page ?? 1;
        if (p > 1) Add("page", p);
        return parts.Count == 0 ? "" : "?" + string.Join("&", parts);
    }
}

public class FilterChip
{
    public string Label { get; set; } = "";
    public string RemoveQuery { get; set; } = "";   // query string بعد إزالة الشريحة دي
}

public class MaterialOption
{
    public string Value { get; set; } = "";   // القيمة في الداتا (جينز)
    public string Label { get; set; } = "";   // اللي بيظهر (جينز / دنيم)
    public int Count { get; set; }
    public bool Checked { get; set; }
}

// ───────────── Lots/Index ─────────────
public class LotsIndexVM
{
    public List<LotCardVM> Items { get; set; } = new();
    public int Total { get; set; }
    public int FactoriesCount { get; set; }
    public LotFilter Filter { get; set; } = new();
    public List<MaterialOption> Materials { get; set; } = new();
    public List<string> Governorates { get; set; } = new();
    public List<FilterChip> Chips { get; set; } = new();
    public int Page { get; set; } = 1;
    public int Pages { get; set; } = 1;
}

// ───────────── Lots/Details ─────────────
public class LotDetailsVM
{
    public LotCardVM Lot { get; set; } = new();
    public string MaterialLabel { get; set; } = "";
    public string Description { get; set; } = "";
    public int FactoryDeals { get; set; }
    public bool FactoryVerified { get; set; } = true;

    public decimal PlatformFee { get; set; }
    public decimal Delivery { get; set; }
    public decimal Total => Lot.Price + PlatformFee + Delivery;
    public decimal PricePerKg => Lot.WeightKg > 0 ? Math.Round(Lot.Price / Lot.WeightKg) : 0;

    public List<GalleryItem> Gallery { get; set; } = new();
}

public class GalleryItem
{
    public string Caption { get; set; } = "";
    public string Hex { get; set; } = "";
    public double Opacity { get; set; } = 1;
}
