namespace MusicHub
{
    using System;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .ToArray();

            foreach (var item in albums.OrderByDescending(a => a.Price))
            {
                sb.AppendLine($"-AlbumName: {item.Name}");
                sb.AppendLine($"-ReleaseDate: {item.ReleaseDate.ToString("MM/dd/yyyy")}");
                sb.AppendLine($"-ProducerName: {item.Producer!.Name}");

                sb.AppendLine($"-Songs:");

                int count = 1;

                foreach (var song in item.Songs.OrderByDescending(s => s.Name).ThenBy(w => w.Writer))
                {
                    sb.AppendLine($"---#{count}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.Writer!.Name}");

                    count++;
                }

                sb.AppendLine($"-AlbumPrice: {item.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            TimeSpan ts = new TimeSpan(0, 0, duration);

            StringBuilder sb = new StringBuilder();

            var songs = context.Songs
                .Where(s => s.Duration > ts)
                .ToList();

            int count = 1;
            foreach (var item in songs.OrderBy(x => x.Name).ThenBy(x => x.Writer))
            {
                sb.AppendLine($"-Song #{count++}");
                sb.AppendLine($"---SongName: {item.Name}");
                sb.AppendLine($"---Writer: {item.Writer!.Name}");

                int performersCount = context.SongsPerformers
                    .Where(x => x.Song == item)
                    .Count();

                if (count != 0)
                {
                    var perforfmers = context.SongsPerformers
                        .Where(x => x.Song == item)
                        .Select(x => x.Performer)
                        .ToArray();

                    foreach (var p in perforfmers.OrderBy(x => x.FirstName + x.LastName))
                    {
                        sb.AppendLine($"---Performer: {p.FirstName} {p.LastName}");
                    }
                }

                sb.AppendLine($"---AlbumProducer: {item.Album!.Producer!.Name}");
                sb.AppendLine($"---Duration: {item.Duration.ToString("c")}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
