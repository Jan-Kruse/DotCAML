namespace DotCAML
{
    public interface IJoinable
    {
        IJoin InnerJoin(string lookupFieldInternalName, string alias, string fromList = null);

        IJoin LeftJoin(string lookupFieldInternalName, string alias, string fromList = null);
    }
}