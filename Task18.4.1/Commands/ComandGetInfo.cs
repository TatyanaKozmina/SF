class CommandGetInfo : Command
{
    Receiver receiver;
    private string videoUrl;

    public CommandGetInfo(Receiver receiver, string videoUrl)
    {
        this.receiver = receiver;
        this.videoUrl = videoUrl;
    }

    // Выполнить
    public override void Run()
    {
        receiver.GetInfoAsync(videoUrl);
    }

    // Отменить
    public override void Cancel()
    { }
}