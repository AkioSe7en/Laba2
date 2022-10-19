using Laba2;

using (ApplicationContext db = new ApplicationContext())
{
    //----------------------------------------------------------------------------
    /*var stocks = new List<Stock>
    {
        new() { Town = "Бийск" },
        new() { Town = "Барнаул" },
        new() { Town = "село Черга" },
        new() { Town = "Санкт-Петербург" }
    };
    var cars = CarGenerator.GetCars(stocks);

    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    db.Cars.AddRange(cars);
    db.Stocks.AddRange(stocks);
    db.SaveChanges();*/
    //----------------------------------------------------------------------------

    // ЗАДАНИЕ 1 -----------------------------------------------------------------------------------------------------
    WriteLine("Задание 1. Alfa Romeo на складе.");
    var z1 = db.Cars.Where(p => p.Name == "Alfa Romeo").Where(p => p.IsStock == true).ToList();
    foreach (var z in z1)
    {
        WriteLine($"{z.Name} {z.Cost}$ ");
    }

    WriteLine();

    // ЗАДАНИЕ 2 -----------------------------------------------------------------------------------------------------
    WriteLine("Задание 2. Склады, где есть BMW:");
    var z2 = db.Cars.Where(p => p.Name.Contains("BMW")).Select(p => p.Stock).Distinct().ToList();
    foreach (var z in z2)
    {
        WriteLine($"{z.Town}");
    }

    WriteLine();

    // ЗАДАНИЕ 3 -----------------------------------------------------------------------------------------------------
    WriteLine("Задание 3. Машины дешевле 10000$:");
    var z3 = db.Cars.Where(p => p.Cost < 10000).ToList();
    foreach (var z in z3)
    {
        WriteLine($"{z.Name} {z.Cost}$ {z.DataRelease} года.");
    }

    WriteLine();

    // ЗАДАНИЕ 4 -----------------------------------------------------------------------------------------------------
    WriteLine("Задание 4. Машины с пометкой:");
    var z4 = db.Cars.Where(p => p.Remark != "").OrderBy(p => p.Name).ToList();
    foreach (var z in z4)
    {
        WriteLine($"{z.Name} {z.Cost}$ {z.DataRelease} года. Пометка: {z.Remark}");
    }

    WriteLine();

    // ЗАДАНИЕ 5 -----------------------------------------------------------------------------------------------------
    WriteLine("Задание 5. Склады с машинами 2000-2005 г:");
    var z5 = db.Cars.Where(p => p.DataRelease >= 2000 && p.DataRelease <= 2005).GroupBy(c => c.Stock.Town)
        .Select(g => new { Name = g.Key, Count = g.Count() }).ToList();
    foreach (var z in z5)
    {
        WriteLine(z.Name + " " + z.Count);
    }

    WriteLine();

    // ЗАДАНИЕ 6 -----------------------------------------------------------------------------------------------------
    WriteLine("Задание 6. Машины до 2000 года:");
    var z6 = db.Cars.Where(p => p.DataRelease < 2000).OrderBy(p => p.DataRelease).ToList();
    foreach (var z in z6)
    {
        WriteLine($"{z.Name} {z.Cost}$ {z.DataRelease} года");
    }

    WriteLine();

    DbReport DBRep = new DbReport() { DateBase = db };
    DBRep.WriteAllReport();
}