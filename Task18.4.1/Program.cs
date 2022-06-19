const string videoUrl = "https://www.youtube.com/watch?v=OXzugTmRQpM";
const string filePath = @"C:/SF/MyVideo.mp4";

// создадим отправителя
var sender = new Sender();

// создадим получателя
var receiver = Receiver.GetInstance();

// создадим команду на запрос информации
var commandGetInfo = new CommandGetInfo(receiver, videoUrl);

// инициализация команды
sender.SetCommand(commandGetInfo);

// выполнение
sender.Run();

// создадим команду на скачивание
var commandDownload = new CommandDownload(receiver, videoUrl,filePath);

// инициализация команды
sender.SetCommand(commandDownload);

// выполнение
sender.Run();
 
Console.ReadLine();

