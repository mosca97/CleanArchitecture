// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Domains.Core.Entities
{
    public class MedicalTreatment
    {
        public long Id { get; set; }
        public DateOnly Date { get; set; }
        public string Description { get; set; }

        public virtual Hive Hive { get; set; }
    }
}
