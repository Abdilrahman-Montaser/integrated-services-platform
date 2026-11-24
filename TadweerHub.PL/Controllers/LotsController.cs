using Microsoft.AspNetCore.Mvc;
using TadweerHub.PL.Mock;
using TadweerHub.PL.ViewModels;   // ⚠️ عدّل الـ namespaces لو مختلفة

namespace TadweerHub.PL.Controllers;

[Route("Lots")]
public class LotsController : Controller
{
    private const int PageSize = 6;
    private const decimal FeeRate = 0.02m;           // رسوم المنصة 2%
    private const decimal DeliveryEstimate = 850m;   // مؤقت لحد ما يتحدد من الداتا

    // اسم العرض لكل خامة
    private static readonly Dictionary<string, string> MaterialLabels = new()
    {
        ["جينز"] = "جينز / دنيم"
    };
    private static string Label(string m) => MaterialLabels.TryGetValue(m, out var l) ? l : m;

    // ───────────── /Lots ─────────────
    [HttpGet("")]
    public IActionResult Index([FromQuery] LotFilter f)
    {
        var all = MockData.Lots;
        var q = all.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(f.Q))
        {
            var s = f.Q.Trim();
            q = q.Where(l => l.Name.Contains(s) || l.Factory.Contains(s) ||
                             l.Material.Contains(s) ||
                             l.Code.Contains(s, StringComparison.OrdinalIgnoreCase));
        }
        if (f.Materials.Any())                 q = q.Where(l => f.Materials.Contains(l.Material));
        if (f.MinKg is not null)               q = q.Where(l => l.WeightKg >= f.MinKg);
        if (f.MaxKg is not null)               q = q.Where(l => l.WeightKg <= f.MaxKg);
        if (!string.IsNullOrWhiteSpace(f.Gov)) q = q.Where(l => l.Governorate == f.Gov);
        if (f.MinPrice is not null)            q = q.Where(l => l.Price >= f.MinPrice);
        if (f.MaxPrice is not null)            q = q.Where(l => l.Price <= f.MaxPrice);

        q = f.Sort switch
        {
            "price_asc"  => q.OrderBy(l => l.Price),
            "price_desc" => q.OrderByDescending(l => l.Price),
            "weight"     => q.OrderByDescending(l => l.WeightKg),
            _            => q.OrderByDescending(l => l.Code)   // الأحدث أولاً (الكود الأكبر = الأحدث)
        };

        var list = q.ToList();
        var pages = Math.Max(1, (int)Math.Ceiling(list.Count / (double)PageSize));
        var page = Math.Clamp(f.Page, 1, pages);
        f.Page = page;

        var vm = new LotsIndexVM
        {
            Items = list.Skip((page - 1) * PageSize).Take(PageSize).ToList(),
            Total = list.Count,
            FactoriesCount = all.Select(l => l.Factory).Distinct().Count(),
            Filter = f,
            Page = page,
            Pages = pages,
            Governorates = all.Select(l => l.Governorate).Distinct().OrderBy(x => x).ToList(),
            Materials = all.GroupBy(l => l.Material)
                           .Select(g => new MaterialOption
                           {
                               Value = g.Key,
                               Label = Label(g.Key),
                               Count = g.Count(),
                               Checked = f.Materials.Contains(g.Key)
                           })
                           .OrderByDescending(m => m.Count).ToList(),
            Chips = BuildChips(f)
        };
        return View(vm);
    }

    // ───────────── /Lots/Details/LOT-0412 ─────────────
    [HttpGet("Details/{code}")]
    public IActionResult Details(string code)
    {
        var lot = MockData.Lots.FirstOrDefault(l =>
            l.Code.Equals(code, StringComparison.OrdinalIgnoreCase));
        if (lot is null) return NotFound();

        var vm = new LotDetailsVM
        {
            Lot = lot,
            MaterialLabel = Label(lot.Material),
            // ⚠️ بيانات مؤقتة (مش في MockData) — اطلبها من منتصر لو عايزها تتخزن
            FactoryDeals = 41,
            Description = $"بواقي إنتاج {lot.Factory} — {lot.Name}، حالة اللوط: {lot.Condition}، " +
                          $"لون {lot.ColorName}. مخزّنة في مكان جاف، ومناسبة لورش التفصيل والخياطة.",
            PlatformFee = Math.Round(lot.Price * FeeRate, 2),
            Delivery = DeliveryEstimate,
            Gallery = new()
            {
                new() { Caption = "رولات",      Hex = lot.ColorHex, Opacity = 1.0 },
                new() { Caption = "قريب",       Hex = lot.ColorHex, Opacity = 0.85 },
                new() { Caption = "ملمس",       Hex = lot.ColorHex, Opacity = 0.7 },
                new() { Caption = "ورقة الوزن", Hex = "#E8E0CE",    Opacity = 1.0 },
            }
        };
        return View(vm);
    }

    // ───────────── مساعد: شرايح الفلاتر النشطة ─────────────
    private static List<FilterChip> BuildChips(LotFilter f)
    {
        var chips = new List<FilterChip>();
        FilterChip Make(string label, Action<LotFilter> remove)
        {
            var c = f.Clone(); remove(c); c.Page = 1;
            return new FilterChip { Label = label, RemoveQuery = c.ToQueryString() };
        }

        if (!string.IsNullOrWhiteSpace(f.Q))
            chips.Add(Make($"بحث: {f.Q}", c => c.Q = null));
        foreach (var m in f.Materials)
            chips.Add(Make(Label(m), c => c.Materials.Remove(m)));
        if (f.MinKg != null || f.MaxKg != null)
            chips.Add(Make($"{f.MinKg ?? 0}-{(f.MaxKg?.ToString() ?? "∞")} كجم",
                           c => { c.MinKg = null; c.MaxKg = null; }));
        if (!string.IsNullOrWhiteSpace(f.Gov))
            chips.Add(Make(f.Gov!, c => c.Gov = null));
        if (f.MinPrice != null || f.MaxPrice != null)
            chips.Add(Make($"السعر {f.MinPrice?.ToString("N0") ?? "0"}-{f.MaxPrice?.ToString("N0") ?? "∞"} ج.م",
                           c => { c.MinPrice = null; c.MaxPrice = null; }));
        return chips;
    }
}
