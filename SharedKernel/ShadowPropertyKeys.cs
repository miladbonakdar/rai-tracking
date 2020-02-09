using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SharedKernel
{
    public static class ShadowPropertyKeys
    {
        public const string CreatedAt = nameof(CreatedAt);
        public const string UpdatedAt = nameof(UpdatedAt);
        public const string CreatedBy = nameof(CreatedBy);
        public const string UpdatedBy = nameof(UpdatedBy);
        public const string CreatedById = nameof(CreatedById);
        public const string UpdatedById = nameof(UpdatedById);

        public static IEnumerable<string> GetAll()
        {
            yield return CreatedById;
            yield return UpdatedById;
            yield return CreatedAt;
            yield return UpdatedAt;
            yield return CreatedBy;
            yield return UpdatedBy;
        }
    }
}