using CsvHelper;
using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.XPath;


namespace WebScraper{
    class Program{
        static void Main(string[] args){

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("http://atdcomputers.com/computer-components/cooling-fans.html?limit=all");

            var HeaderNamesN = doc.DocumentNode.SelectNodes("//h2[@class='product-name']/a");
            var titles = new List<RowN>();

            foreach (var item in HeaderNamesN){

                titles.Add(new RowN {Name = item.InnerText});
            }

            using (var writer = new StreamWriter("C:/Users/mpg40/Desktop/exampleT.csv"))

            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture)){

                csv.WriteRecords(titles);
            }

            //var HeaderNamesC = doc.DocumentNode.SelectNodes("//span[starts-with(@id, 'pricediv')]");
            var HeaderNamesC = doc.DocumentNode.SelectNodes("//span[(@class='price')]");
            //var HeaderNamesC = doc.DocumentNode.SelectNodes("//span[(@class='regular-price')]");
            var prices = new List<RowC>();

            foreach (var item in HeaderNamesC){

                prices.Add(new RowC {Cost = item.InnerText});
            }

            using (var writer = new StreamWriter("C:/Users/mpg40/Desktop/exampleC.csv"))

            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture)){

                csv.WriteRecords(prices);
            }
                
        }
    }
}

class RowN{
    public string Name {get; set;}
}
class RowC{
    public string Cost {get; set;}
}