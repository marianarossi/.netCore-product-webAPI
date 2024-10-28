using System.Text.Json;
using System.Text.Json.Serialization;

namespace dotnetAPI.Utilities
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        private readonly string _dateTimeFormat;

        public DateTimeConverter(string format)
        {
            _dateTimeFormat = format;
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string dateString = reader.GetString()!;
            return DateTime.Parse(dateString, null, System.Globalization.DateTimeStyles.RoundtripKind);
            //return DateTime.ParseExact(reader.GetString()!, _dateTimeFormat, null);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_dateTimeFormat));
        }
    }
}
