﻿namespace DotCAML
{
    public interface IProjectableView : IJoinable
    {
        IQuery Query();

        IView RowLimit(int limit, bool? paged);

        IView Scope(ViewScope scope);

        IProjectableView Select(string remoteFieldInternalName, string remoteFieldAlias);
    }
}