using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Jsoft.Converters
{
    [PublicAPI]
    public class StringDateTimeConverter : JsonConverter<DateTime>
    {
        /// <inheritdoc />
        public override DateTime Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
        {
            var dateTimeStr = reader.GetString();
            return DateTime.Parse(dateTimeStr, Globals.DateTimeFormat);
        }
        
        /// <inheritdoc />
        public override void Write( Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options )
        {
            var dateTimeStr = value.ToString(Globals.DateTimeFormat);
            writer.WriteStringValue(dateTimeStr);
        }
    }
}
