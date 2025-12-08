﻿
using System.Globalization;
using Newtonsoft.Json;

namespace datingApp.Extensions;

/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public class DateOnlyJsonConverterExtension: JsonConverter<DateOnly>
{
    private const string DateFormat = "yyyy-MM-dd";

    public override DateOnly ReadJson(JsonReader reader, Type objectType, DateOnly existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        return DateOnly.ParseExact((string)reader.Value, DateFormat,  CultureInfo.InvariantCulture);
    }

    public override void WriteJson(JsonWriter writer, DateOnly value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString(DateFormat, CultureInfo.InvariantCulture));
    }
}