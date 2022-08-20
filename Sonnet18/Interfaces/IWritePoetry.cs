namespace Sonnet18.Interfaces;
internal interface IWritePoetry
{
    void WriteLine(string line);
    void WritePoem(string title, params string[] lines);
    void Sign();
    string ReadPoem();
}
