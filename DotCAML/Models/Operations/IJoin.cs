namespace DotCAML
{
    public interface IJoin : IJoinable
    {
        IProjectableView Select(string remoteFieldInternalName, string remoteFieldAlias);
    }
}