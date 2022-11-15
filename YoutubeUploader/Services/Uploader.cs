namespace YoutubeUploader.Services
{
    class Uploader : IAction
    {
        private Video video;

        public Uploader(Video video)
        {
            this.video = video;
        }

        public async Task Invoke()
        {
            await video.Upload();
        }

        public void Undo() { video.Delete(); }
    }
}