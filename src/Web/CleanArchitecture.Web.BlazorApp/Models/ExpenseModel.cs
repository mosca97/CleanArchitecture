// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Web.BlazorApp.Models;

public class ExpenseModel
{
    public long Id { get; set; }
    [Required]

    [JsonIgnore]
    public string CategoryIdString { get; set; }

    public long CategoryId
    {
        get
        {
            return long.Parse(CategoryIdString);
        }
        set
        {
            CategoryId = value;
        }
    }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    [Required]
    [Range(0.1, double.MaxValue)]
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "EUR";
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
}

public enum Currency
{
    USD,
    EUR,
    GBP,
    JPY,
    CNY
}
