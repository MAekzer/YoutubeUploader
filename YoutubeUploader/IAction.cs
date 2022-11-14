namespace YoutubeUploader
{
    interface IAction
    {
        void Invoke();
        void Undo();
    }
}