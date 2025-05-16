// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Domains.Core.Entities;

namespace CleanArchitecture.Applications.Apiaries.Get
{
    public class ApiaryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Altitude { get; set; }
        public List<HiveDto> Hives { get; set; } = [];
    }

    public class NoteDto
    {
        public long Id { get; set; }
        public DateOnly Date { get; set; }
        public string Description { get; set; }
    }

    public class MedicalTreatmentDto
    {
        public long Id { get; set; }
        public DateOnly Date { get; set; }
        public string Description { get; set; }
    }

    public class HiveDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public HiveType HiveType { get; set; }
        public string QueeBeeYear { get; set; }
        public List<NoteDto> Notes { get; set; } = [];
        public List<MedicalTreatmentDto> Treatments { get; set; } = [];
    }
}
