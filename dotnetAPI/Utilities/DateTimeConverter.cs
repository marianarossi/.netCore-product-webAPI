using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace dotnetAPI.Utilities
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        private readonly string _dateTimeFormat;

        // Define the time zone for Brasília
        private readonly TimeZoneInfo _brasiliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

        public DateTimeConverter(string format)
        {
            _dateTimeFormat = format;
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string dateString = reader.GetString()!;
            // Parse the date string as UTC
            DateTime utcDate = DateTime.Parse(dateString, null, System.Globalization.DateTimeStyles.RoundtripKind);
            // Convert to Brasília time
            return TimeZoneInfo.ConvertTimeFromUtc(utcDate, _brasiliaTimeZone);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            // Convert Brasília time to UTC before writing
            DateTime utcDate = TimeZoneInfo.ConvertTimeToUtc(value, _brasiliaTimeZone);
            writer.WriteStringValue(utcDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")); // Return in ISO 8601 format
        }
    }
}
