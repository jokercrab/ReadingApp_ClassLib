using System.Diagnostics;
using System.Text.Json;
using General.DataModels;

namespace WuxiaApp.Servs;

public class Services
{
    public Services()
    {
    }

    List<Book> bookList;
    public async Task<List<Book>> GetBooks()
    {

        if (bookList?.Count > 0)
            return bookList;
        try
        {
            var contents = await File.ReadAllTextAsync(Path.Combine(FileSystem.Current.AppDataDirectory, "library.dat"));
            bookList = JsonSerializer.Deserialize<List<Book>>(contents);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return bookList;
    }

    public async Task CopyLibraryFile(string sourceFile, string targetFileName)
    {
        using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(sourceFile);
        using StreamReader reader = new StreamReader(fileStream);

        string content = await reader.ReadToEndAsync();


        string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, targetFileName);

        using FileStream outputStream = File.OpenWrite(targetFile);
        using StreamWriter streamWriter = new StreamWriter(outputStream);

        await streamWriter.WriteAsync(content);
    }

    public async void DeleteLastBook()
    {
        bookList?.RemoveAt(bookList.Count - 1);
        var content = JsonSerializer.Serialize(bookList);
        //using var stream = await FileSystem.OpenAppPackageFileAsync("library");
        //using var writer = new StreamWriter(stream,);
        //await writer.WriteLineAsync(content);

    }

    public void AddNewBook(Book book)
    {
        bookList.Add(book);
    }
}

