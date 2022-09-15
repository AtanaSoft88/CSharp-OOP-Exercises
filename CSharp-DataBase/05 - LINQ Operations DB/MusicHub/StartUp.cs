namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            //Task 2.All Albums Produced by Given Producer

            //int producerIdInput = 9;
            //string resultTxt = ExportAlbumsInfo(context, producerIdInput);
            //Console.WriteLine(resultTxt);


            //Task 3.Songs Above Given Duration

            int givenDuration = 4;

            string resultTxt = ExportSongsAboveDuration(context, givenDuration);
            Console.WriteLine(resultTxt);


        }
        /*
            1) Error : Export_000_001.ExportGamesByGenresZeroTest : System.InvalidCastException : Unable to cast object of type 'System.Linq.Expressions.NewExpression' to type 'System.Linq.Expressions.MethodCallExpression'.   at Microsoft.EntityFrameworkCore.InMemory.Query.Internal.

            If this mistake occurs - > Just add .ToList() earlier in the expression for judje!
         */
        //Task 2
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();
            var albumsProducedByGivenId = context.Albums.Where(x => x.ProducerId == producerId).ToList().Select(a => new
            {
                Name = a.Name,
                ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                ProducerName = a.Producer.Name,
                TotalPrice = a.Songs.Sum(s=>s.Price),
                Songs = a.Songs.Select(s => new { SongName = s.Name, SongPrice = s.Price, WriterName = s.Writer.Name })

            }).ToList();
            foreach (var albums in albumsProducedByGivenId.OrderByDescending(x => x.TotalPrice))
            {
                sb.AppendLine($"-AlbumName: {albums.Name}");
                sb.AppendLine($"-ReleaseDate: {albums.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {albums.ProducerName}");
                sb.AppendLine("-Songs:");
                int count = 0;

                foreach (var songs in albums.Songs.OrderByDescending(x => x.SongName).ThenBy(x => x.WriterName))
                {
                    count++;
                    sb.AppendLine($"---#{count}");
                    sb.AppendLine($"---SongName: {songs.SongName}");
                    sb.AppendLine($"---Price: {songs.SongPrice:f2}");
                    sb.AppendLine($"---Writer: {songs.WriterName}");
                }
                sb.AppendLine($"-AlbumPrice: {albums.TotalPrice:f2}");

            }

            return sb.ToString().TrimEnd();
        }

        //Task 3
        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songsAboveDuration = context.Songs.ToList().Where(d => d.Duration.TotalSeconds > duration).Select(s => new
            {
               SongName = s.Name,
               SongPerformer = s.SongPerformers.Select(sp=> $"{sp.Performer.FirstName} {sp.Performer.LastName}").FirstOrDefault(),
               WriterName = s.Writer.Name,
               AlbumProducer = s.Album.Producer.Name,
               DurationOfSong = s.Duration.ToString("c",CultureInfo.InvariantCulture)

            }).OrderBy(s=>s.SongName).ThenBy(w=>w.WriterName).ThenBy(p=>p.SongPerformer).ToList();
            int songNumber = 0;
            foreach (var song in songsAboveDuration)
            {
                songNumber++;
                sb.AppendLine($"-Song #{songNumber}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                sb.AppendLine($"---Performer: {song.SongPerformer}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.DurationOfSong}");

            }
            return sb.ToString().TrimEnd();
        }
    }
}
