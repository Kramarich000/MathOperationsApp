static List<string> LoadHistory()
{
    if (File.Exists("history.txt"))
    {
        return new List<string>(File.ReadAllLines("history.txt"));
    }
    return new List<string>();
}
