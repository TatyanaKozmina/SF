string? folderPath = Console.ReadLine();
long dirSize = CalcDirectorySize(folderPath);
Console.WriteLine($"Размер папки {folderPath} {dirSize} байт");

long CalcDirectorySize(string? folderPath)
{
    long result = 0;

    if (folderPath == null)
        Console.WriteLine("Параметр folderPath = null");
    else
    {
        DirectoryInfo di = new DirectoryInfo(folderPath);
        if (di.Exists)
            result = CalcItemsSize(di);            
        else
            Console.WriteLine($"Папка {folderPath} не существует");
    }    

    return result;
}

long CalcItemsSize(DirectoryInfo di)
{
    long size = 0;

    size += CalcFilesSize(di);    

    try
    {
        DirectoryInfo[] folders = di.GetDirectories();
        foreach (var folder in folders)
        {
            try
            {
                Console.WriteLine($"Папка {folder.FullName}");
                size += CalcItemsSize(folder);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
        }
    }
    catch (UnauthorizedAccessException e)
    {
        Console.WriteLine(e.Message);
    }
    catch (DirectoryNotFoundException e)
    {
        Console.WriteLine(e.Message);
    }
    return size;
}

long CalcFilesSize(DirectoryInfo di)
{
    long result = 0;

    try
    {
        FileInfo[] files = di.GetFiles();
        foreach (var file in files)
        {
            try
            {
                Console.WriteLine($"Файл {file.FullName}");
                result += file.Length;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
        }
    }
    catch (UnauthorizedAccessException e)
    {
        Console.WriteLine(e.Message);
    }
    catch (DirectoryNotFoundException e)
    {
        Console.WriteLine(e.Message);
    }

    return result;
}