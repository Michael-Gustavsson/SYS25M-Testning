namespace infrastructure.Serialization;

public class JsonStorage(string filePath) : IFileStorage
{
    public string Read()
    {
        if (!File.Exists(filePath))
        {
            return string.Empty;
        }

        return File.ReadAllText(filePath);
    }

    public void Write(string content)
    {
        File.WriteAllText(filePath, content);
    }
}
