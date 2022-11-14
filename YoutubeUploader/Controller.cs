namespace YoutubeUploader
{
    class Controller
    {
        private IAction action;

        internal void SetAction(IAction action)
        {
            this.action = action;
        }

        public void Invoke() { action.Invoke(); }

        public void Undo() { action.Undo(); }

        public static void HandleError(Exception e)
        {
            Console.WriteLine("Произошла непредвиденная ошибка:");
            Console.WriteLine(e.Message);
        }
    }
}