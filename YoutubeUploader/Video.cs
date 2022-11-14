

using System.Diagnostics.CodeAnalysis;
using YoutubeExplode;
using YoutubeExplode.Converter;
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

        public void GetInfo()
        {
            Console.Clear();
            var desc = client.Videos.GetAsync(Url).Result;
            Console.WriteLine($"Название видео: {desc.Title}\n\n" +
                $"Автор: {desc.Author}\n\n" +
                $"Длительность: {desc.Duration}\n\n" +
                $"Дата создания: {desc.UploadDate.Date.ToShortDateString()}\n\n" +
                $"Описание: {desc.Description}");
        }

        public void ClearInfo()
        {
            Console.Clear();
        }

        public async void Upload()
        {
            var streamManifest = await client.Videos.Streams.GetManifestAsync(Url);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

            await client.Videos.Streams.DownloadAsync(streamInfo, $"video.{streamInfo.Container}");
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}