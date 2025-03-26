﻿namespace Domain.Dtos.Input;

public record GetProductsParams
{
    public string? ProviderId { get; set; }
    public DateTime? CreatedFrom { get; set; }
    public DateTime? CreatedTo { get; set; }
    public double? MinPrice { get; set; }
    public double? MaxPrice { get; set; }
}