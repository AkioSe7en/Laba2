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

    var cars = db.Cars.Include(p => p.Stock).ToList();

    DbReport DBRep = new DbReport() { DateBase = db };
    DBRep.WriteAllReport();
}