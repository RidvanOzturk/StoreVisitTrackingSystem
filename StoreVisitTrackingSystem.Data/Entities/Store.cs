﻿namespace StoreVisitTrackingSystem.Data.Entities;

public class Store
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual List<Visit> Visits { get; set; } = [];
}