using Laba2;

var stocks = new List<Stock>
{
    new() {Town = "Бийск"},
    new() {Town = "Барнаул"},
    new() {Town = "село Черга"},
    new() {Town = "Санкт-Петербург"}
};
    
var cars = CarGenerator.GetCars(stocks);