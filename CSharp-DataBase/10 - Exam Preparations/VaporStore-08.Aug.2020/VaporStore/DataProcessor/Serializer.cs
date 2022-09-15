namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		//Here we dont need DTO's but recommended to use . Just use Anonymous objects for JSON Export!
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{ 
			var genres = context.Genres.ToList().Where(x => genreNames.Contains(x.Name)).Select(x => new
			{
				Id = x.Id,
				Genre = x.Name,				
				Games = x.Games.Select(g => new
				{
					Id = g.Id,
					Title = g.Name,
					Developer = g.Developer.Name,
					Tags = string.Join(", ",g.GameTags.Select(x=>x.Tag.Name)),
					Players = g.Purchases.Count()
				}).Where(g=>g.Players>0).OrderByDescending(x=>x.Players).ThenBy(x=>x.Id).ToList(),
				TotalPlayers = x.Games.Sum(p => p.Purchases.Count()),
			}).OrderByDescending(x=>x.TotalPlayers).ThenBy(x=>x.Id).ToList();
			var stringFmJson = JsonConvert.SerializeObject(genres, Formatting.Indented);
			return stringFmJson;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{ // For the task with XML Export we MUST use DTO's
			var rootName = "Users";

			var userPurchasesByTypeDto = context.Users.ToList().Where(x => x.Cards.Any(c => c.Purchases.Any(p=>p.Type.ToString()==storeType))).Select(u => new ExportUserPurchasesDTO
			{				
				Username = u.Username,
				TotalSpent = u.Cards.Sum(p=>p.Purchases.Where(t=>t.Type.ToString()==storeType).Sum(g=>g.Game.Price)),
				Purchases = u.Cards.SelectMany(p => p.Purchases).Where(p=>p.Type.ToString()==storeType).Select(x => new PurchaseExportDTO
				{
					CardNumber = x.Card.Number,
					Cvc = x.Card.Cvc,
					Date = x.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
					Game = new GameExortDTO
					{
						GameTitle = x.Game.Name,
						Genre = x.Game.Genre.Name,
						Price = x.Game.Price
					}

				}).OrderBy(x=>x.Date).ToArray()
			}).OrderByDescending(x => x.TotalSpent).ThenBy(u=>u.Username).ToArray();
			var purchases = SerializerCustom<ExportUserPurchasesDTO[]>(userPurchasesByTypeDto,rootName);
			return purchases;
		}

		private static string SerializerCustom<T>(T dto, string rootName)
		{
			StringBuilder sb = new StringBuilder();

			XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
			XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
			namespaces.Add(string.Empty, string.Empty); // This way we delete any namespaces trails for judje!

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

			using StringWriter writer = new StringWriter(sb);
			xmlSerializer.Serialize(writer, dto, namespaces);

			return sb.ToString().TrimEnd();
		}       // Usefull Method fm ClassDto[] to XML file
	}
}