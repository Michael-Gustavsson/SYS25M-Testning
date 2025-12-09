namespace infrastructure;

public interface IFileStorage
{
    string Read();
    void Write(string content);
}
