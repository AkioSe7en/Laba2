using Laba2;

using (ApplicationContext db = new ApplicationContext())
{
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

    // ЗАДАНИЕ 1 -----------------------------------------------------------------------------------------------------
    WriteLine("Задание 1. Alfa Romeo на складе.");
    var z1 = db.Cars.Where(p => p.Name == "Alfa Romeo").Where(p => p.IsStock == true).ToList();
    foreach (var z in z1)
    {
        WriteLine($"{z.Name} {z.Cost}$ В наличии:{z.IsStock}");
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

    DbReport DBRep = new DbReport() { DateBase = db };
    DBRep.WriteAllReport();
}