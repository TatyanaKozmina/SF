const byte timePeriod = 30;
string? folderPath = Console.ReadLine();
CleanFolder(folderPath);

void CleanFolder(string? folderPath)
{
    if(folderPath == null)
        Console.WriteLine("Параметр folderPath = null");
    else
    {
        DirectoryInfo di = new DirectoryInfo(folderPath);
        if (di.Exists)
            DeleteFolders(di);
        else
            Console.WriteLine($"Папка {folderPath} не существует");
    }      
}

void DeleteFolders(DirectoryInfo di)
{
    DeleteFiles(di);

    try
    {
        DirectoryInfo[] folders = di.GetDirectories();
        foreach (var folder in folders)
        {
            try
            {               
                Console.WriteLine($"Папка {folder.FullName}, not used {(DateTime.Now - folder.LastAccessTime).TotalMinutes}");                
                DeleteFolders(folder);
                if ((DateTime.Now - folder.LastAccessTime).TotalMinutes > timePeriod)
                {
                    folder.Delete();
                }
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
}

void DeleteFiles(DirectoryInfo di)
{
    try
    {
        FileInfo[] files = di.GetFiles();
        foreach (var file in files)
        {
            try
            {
                Console.WriteLine($"Файл {file.FullName}, not used {(DateTime.Now - file.LastAccessTime).TotalMinutes}");
                if ((DateTime.Now - file.LastAccessTime).TotalMinutes > timePeriod)
                {
                    file.Delete();
                }
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
}