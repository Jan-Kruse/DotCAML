namespace DotCAML
{
    public interface IUserFieldExpression
    {
        IExpression EqualToCurrentUser();

        IExpression IsInCurrentUserGroups();

        IExpression IsInSPGroup(int groupId);

        IExpression IsInSPWebGroups();

        IExpression IsInSPWebAllUsers();

        IExpression IsInSPWebUsers();

        INumberFieldExpression Id();

        ITextFieldExpression ValueAsText();
    }
}