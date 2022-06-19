class CommandDownload : Command
{
    private Receiver receiver;
    private string videoUrl;
    private string filePath;

    public CommandDownload(Receiver receiver, string videoUrl, string filePath)
    {
        this.receiver = receiver;
        this.videoUrl = videoUrl;
        this.filePath = filePath;
    }

    // Выполнить
    public override void Run()
    {
        receiver.DownloadVideoAsync(videoUrl, filePath);
    }

    // Отменить
    public override void Cancel()
    { }
}