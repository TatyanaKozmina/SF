string? folderPath = Console.ReadLine();
CleanFolder(folderPath);

void CleanFolder(string? folderPath)
{
    if (folderPath == null)
        Console.WriteLine("Параметр folderPath = null");
    else
    {
        DirectoryInfo di = new(folderPath);
        if (di.Exists)
        {
            Console.WriteLine($"Исходный размер папки: {CalcItemsSize(di)} байт");
            Result result = DeleteFolders(di);
            Console.WriteLine($"Удалено {result.NumFiles} файлов, {result.NumFolders} папок, освобождено {result.Size} байт");
            Console.WriteLine($"Текущий размер папки: {CalcItemsSize(di)} байт");

        }            
        else
            Console.WriteLine($"Папка {folderPath} не существует");
    }
}

Result DeleteFolders(DirectoryInfo di)
{
    Result result = DeleteFiles(di);    

    try
    {
        DirectoryInfo[] folders = di.GetDirectories();
        foreach (var folder in folders)
        {
            try
            {
                result.NumFolders++;
                Result intermediateRes = DeleteFolders(folder);                
                result.NumFolders += intermediateRes.NumFolders;
                result.NumFiles += intermediateRes.NumFiles;
                result.Size += intermediateRes.Size;

                folder.Delete();
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
    return result;
}

Result DeleteFiles(DirectoryInfo di)
{
    Result result = new() { NumFiles = 0, NumFolders = 0, Size = 0 };
    try
    {
        FileInfo[] files = di.GetFiles();
        foreach (var file in files)
        {
            try
            {
                result.NumFiles++;
                result.Size += file.Length;
                file.Delete();
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

struct Result
{
    public int NumFiles;
    public int NumFolders;
    public long Size;
}
