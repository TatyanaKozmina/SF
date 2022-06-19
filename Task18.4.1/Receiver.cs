using YoutubeExplode;

class Receiver
{
    private static Receiver Instance;
    private YoutubeClient youtubeClient;

    // Приватный конструктор
    private Receiver()
    {
        youtubeClient = new YoutubeClient();
    }

    // Конструктор вызывается для создания объекта, если он отсутствует 
    public static Receiver GetInstance()
    {
        if (Instance == null)
            Instance = new Receiver();

        return Instance;
    }

    async public void GetInfoAsync(string videoUrl)
    {
        var video = await youtubeClient.Videos.GetAsync(videoUrl);
        Console.WriteLine($"Название: {video.Title}");
        Console.WriteLine($"Продолжительность: {video.Duration}");
        Console.WriteLine($"Автор: {video.Author}");
    }

    async public void DownloadVideoAsync(string videoUrl, string filePath)
    {
        // Скачиваем только из видео-потока mp4. Выбираем поток минимального размера
        var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(videoUrl);
        var streams = streamManifest.GetVideoStreams().Where(s => s.Container.Name.Equals("mp4"));
        var stream = streams.Aggregate((x, y) => x.Size.Bytes < y.Size.Bytes ? x : y);
        await youtubeClient.Videos.Streams.DownloadAsync(stream, filePath);
        Console.WriteLine("Скачивание завершено.");
    }
}