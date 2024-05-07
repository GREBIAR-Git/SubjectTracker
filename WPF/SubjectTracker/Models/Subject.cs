namespace SubjectTracker.Models;

public abstract class Subject(string name, int con, int cur)
{
    protected Subject() : this(string.Empty, 0, 0)
    {
    }

    public string Name { get; set; } = name;

    public int IndexCon { get; set; } = con;

    public int IndexCur { get; set; } = cur;

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