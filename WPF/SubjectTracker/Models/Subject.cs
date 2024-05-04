namespace SubjectTracker.Models;

public abstract class Subject
{
    protected Subject(string name, int con, int cur)
    {
        Name = name;
        IndexCon = con;
        IndexCur = cur;
    }

    protected Subject()
    {
        Name = string.Empty;
        IndexCon = 0;
        IndexCur = 0;
    }

    public string Name { get; set; }

    public int IndexCon { get; set; }

    public int IndexCur { get; set; }

    public bool BoolCon
    {
        get => IndexCon != 0;
        set => IndexCon = value ? 1 : 0;
    }

    public bool BoolCur
    {
        get => IndexCur != 0;
        set => IndexCur = value ? 1 : 0;
    }
}