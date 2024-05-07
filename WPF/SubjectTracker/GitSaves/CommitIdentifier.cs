namespace SubjectTracker.GitSaves;

internal class CommitIdentifier(int hashCode, string name)
{
    public int HashCode { get; } = hashCode;
    public string Name { get; } = name;
}