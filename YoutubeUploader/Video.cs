

using System.Diagnostics.CodeAnalysis;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace YoutubeUploader
{
    class Video
    {
        private YoutubeClient client;
        public string Url;

        public Video(YoutubeClient client, string url)
        {
            this.client = client;
            Url = url;
        }

        public async Task GetInfo()
        {
            Console.Clear();
            var desc = await client.Videos.GetAsync(Url);
            Console.WriteLine($"\nНазвание видео: {desc.Title}\n\n" +
                $"Автор: {desc.Author}\n\n" +
                $"Длительность: {desc.Duration}\n\n" +
                $"Дата создания: {desc.UploadDate.Date.ToShortDateString()}\n\n" +
                $"Описание: {desc.Description}");
        }

        public void ClearInfo()
        {
            Console.Clear();
        }

        public async Task Upload()
        {
            var videoId = VideoId.Parse(Url);
            var streamManifest = await client.Videos.Streams.GetManifestAsync(Url);
            var streamInfo = streamManifest.GetMuxedStreams().TryGetWithHighestVideoQuality();

            if (streamInfo is null)
            {
                Console.Error.WriteLine("This video has no muxed streams.");
                return;
            }

            Console.WriteLine($"\nИдет загрузка: {streamInfo.Container.Name}");
            var fileName = $"{videoId}.{streamInfo.Container.Name}";
            await client.Videos.Streams.DownloadAsync(streamInfo, $"video.{streamInfo.Container}");

            Console.WriteLine();
            if (Task.CompletedTask.IsCompletedSuccessfully)
                Console.WriteLine($"Загрузка успешно завершена в файл {fileName}");
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}