namespace YoutubeUploader
{
    class Uploader : IAction
    {
        private Video video;

        public Uploader(Video video)
        {
            this.video = video;
        }

        public void Invoke() { video.Upload(); }

        public void Undo() { video.Delete(); }
    }
}