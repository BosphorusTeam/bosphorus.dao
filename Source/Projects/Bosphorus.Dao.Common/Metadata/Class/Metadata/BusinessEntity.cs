using System;
using Bosphorus.Dao.Common.Metadata.Core;

namespace Bosphorus.Dao.Common.Metadata.Class.Metadata
{
    public class BusinessEntity: IMetadata<Type>
    {
        public Type Owner { get; set; }
    }
}