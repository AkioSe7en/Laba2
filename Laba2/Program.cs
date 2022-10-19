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


    WriteLine("Задание 1. Alfa Romeo на складе.");
    var z1 = db.Cars.Where(p => p.Name == "Alfa Romeo").Where(p => p.IsStock == true).ToList();
    foreach (var z in z1)
    {
        WriteLine($"{z.Name} {z.Cost}$ В наличии:{z.IsStock}");
    }

    DbReport DBRep = new DbReport() { DateBase = db };
    DBRep.WriteAllReport();
}