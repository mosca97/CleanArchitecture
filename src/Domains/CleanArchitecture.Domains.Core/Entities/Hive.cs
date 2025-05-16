// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Domains.Core.Entities
{
    public class Hive
    {
        public long Id { get; set; }
        public long ApiaryId { get; set; }
        public string Name { get; set; }
        public HiveType HiveType { get; set; }
        public string QueeBeeYear { get; set; }
        public List<Note> Notes { get; set; } = [];
        public List<MedicalTreatment> Treatments { get; set; } = [];

        public virtual Apiary Apiary { get; set; }
    }
}
