// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Presentations;

public class ApiaryApiResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public double? Altitude { get; set; }
    public List<HiveApiResponse> Hives { get; set; } = [];
}

public class HiveApiResponse
{
    public long Id { get; set; }
    public long ApiaryId { get; set; }
    public string Name { get; set; }
    public string QueenBeeYear { get; set; }
    public List<NoteApiResponse> Notes { get; set; } = [];
    public List<TreatmentApiResponse> Treatments { get; set; } = [];
}


public class NoteApiResponse
{
    public long Id { get; set; }
    public DateOnly Date { get; set; }
    public string Description { get; set; }
}


public class TreatmentApiResponse
{
    public long Id { get; set; }
    public DateOnly Date { get; set; }
    public string Description { get; set; }
}
