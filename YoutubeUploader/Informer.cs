namespace YoutubeUploader
{
    class Informer : IAction
    {
        private Video video;

        public Informer(Video video)
        {
            this.video = video;
        }

        public void Invoke() { video.GetInfo(); }

        public void Undo() { video.ClearInfo(); }
    }
}