﻿using CAML.Models.Operations;
using CAML.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAML.Models.View
{
    public interface IProjectableView : IJoinable
    {
        IQuery Query();

        IView RowLimit(int limit, bool? paged);

        IView Scope(ViewScope scope);

        IProjectableView Select(string remoteFieldInternalName, string remoteFieldAlias);
    }
}
