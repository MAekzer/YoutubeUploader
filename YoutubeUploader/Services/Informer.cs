namespace YoutubeUploader.Services
{
    class Informer : IAction
    {
        private readonly Video video;

        public Informer(Video video)
        {
            this.video = video;
        }

        public async Task Invoke()
        { 
            await video.GetInfo();
        }

        public void Undo() { video.ClearInfo(); }
    }
}