// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Domains.Budget.ValueObjects
{
    [Owned]
    public class Money : IEquatable<Money>
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        public Money(decimal amount, string currency)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be less then 0.", nameof(amount));
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
            Amount = amount;
        }

        public bool Equals(Money other)
        {
            if (other is null) return false;
            return Amount == other.Amount && Currency.Equals(other.Currency);
        }
    }
}
