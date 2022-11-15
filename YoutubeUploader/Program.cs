using YoutubeExplode;
using YoutubeUploader.Services;

namespace YoutubeUploader
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = String.Empty;
            string option = String.Empty;

            //Получаем ссылку на видео
            if (args.Length == 0)
            {
                Console.Write("Укажите ссылку на Youtube видео: ");
                url = Console.ReadLine();
            }
            else
                url = args[0];

            Video video = new(new YoutubeClient(), url);
            Controller controller = new();

            //Выбираем нужную функцию
            if (args.Length < 2)
            {
                Console.WriteLine("Укажите нужную функцию:\nПоказать инфомацию о видео - 1\nСкачать видео - 2");
                option = Console.ReadKey().KeyChar.ToString();
            }
            else
                option = args[1];

            try
            {
                switch (option)
                {
                    case "1":
                        controller.SetAction(new Informer(video));
                        await controller.Invoke();
                        break;
                    case "2":
                        controller.SetAction(new Uploader(video));
                        await controller.Invoke();
                        break;
                    default:
                        Console.WriteLine("Ошибка: требуется ввести 1 или 2 для выбора функции");
                        break;
                }
            }
            catch (Exception e)
            {
                Controller.HandleError(e);
            }
        }
    }
}