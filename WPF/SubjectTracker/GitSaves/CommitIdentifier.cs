namespace SubjectTracker.GitSaves;

internal class CommitIdentifier
{
    public CommitIdentifier(int hashCode, string name)
    {
        HashCode = hashCode;
        Name = name;
    }

    public int HashCode { get; }
    public string Name { get; }
}