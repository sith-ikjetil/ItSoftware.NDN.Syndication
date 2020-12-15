using System;
using ItSoftware.Syndication;
using ItSoftware.Syndication.Atom;
using ItSoftware.Syndication.Rdf;
using ItSoftware.Syndication.Rss;
namespace TestApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			string rssUrl = "http://feeds.bbci.co.uk/news/world/rss.xml";
			var xFeed = Syndication.Load(new Uri(rssUrl));
			
			if ( xFeed is Atom )
			{
				Console.WriteLine("FEED IS ATOM");

			}
			else if ( xFeed is Rdf )
			{
				Console.WriteLine("FEED IS RDF");

			}
			else if (xFeed is Rss ) 
			{
				Console.WriteLine("FEED IS RSS");
				
				var rss = xFeed as Rss;
				foreach (var item in rss.Channel.Items)
				{
					Console.WriteLine($"Title: {item.Title}");
					Console.WriteLine($"Description: {item.Description}");
					Console.WriteLine();
				}
				Console.WriteLine($"Found {rss.Channel.Items.Count} items.");
				Console.WriteLine();
			}
		}
	}
}
