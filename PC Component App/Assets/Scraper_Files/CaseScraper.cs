using System;
using CsvHelper;
using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;


namespace WebScraper
{
    class Program{
        static void Main(string[] args){

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("http://www.atd-inc.com/products.asp?cat=16");

            var HeaderNames = doc.DocumentNode.SelectNodes("//span[@id='pricediv2'] | //span[@id='pricediv3'] | //span[@id='pricediv4'] | //span[@id='pricediv5'] | //span[@id='pricediv6'] | //span[@id='pricediv7'] | //span[@id='pricediv8'] | //span[@id='pricediv9']");

            var prices = new List<Row>();

            foreach (var item in HeaderNames){

                prices.Add(new Row {Comp = item.InnerText});
            }

            using (var writer = new StreamWriter("C:/Users/mpg40/Desktop/example.csv"))

            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture)){

                csv.WriteRecords(prices);
            }
                
        }
    }
}

    public class Row{

        public string Cost {get; set;}
    }
