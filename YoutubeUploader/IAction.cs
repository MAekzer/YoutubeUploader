namespace YoutubeUploader
{
    interface IAction
    {
        Task Invoke();
        void Undo();
    }
}