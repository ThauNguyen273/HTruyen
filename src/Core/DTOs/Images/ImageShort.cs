﻿namespace Core.DTOs.Images;

public record struct ImageShort
{
    public required string MediaType { get; set; }
    public byte[]? Date { get; set; }
}
