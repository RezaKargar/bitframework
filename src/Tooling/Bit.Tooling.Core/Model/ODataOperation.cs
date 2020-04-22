﻿using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Bit.Tooling.Core.Model
{
    public class ODataOperationParameter
    {
        public string Name { get; set; } = default!;

        public ITypeSymbol Type { get; set; } = default!;
    }

    public enum ODataOperationKind
    {
        Function, Action
    }

    public class ODataOperation
    {
        public virtual ODataOperationKind Kind { get; set; }

        public virtual IMethodSymbol Method { get; set; } = default!;

        public virtual ITypeSymbol ReturnType { get; set; } = default!;

        public virtual ICollection<ODataOperationParameter> Parameters { get; set; } = new Collection<ODataOperationParameter>();
    }
}
