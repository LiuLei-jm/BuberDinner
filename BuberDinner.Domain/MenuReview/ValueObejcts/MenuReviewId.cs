﻿using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.MenuReview.ValueObejcts;
public sealed class MenuReviewId : ValueObject
{
    public Guid Value { get; }

    public MenuReviewId(Guid value)
    {
        Value = value;
    }
    public static MenuReviewId CreateUnique()
    {
        return new MenuReviewId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
