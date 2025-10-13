using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Jsoft.Converters
{
    /// <summary>
    /// Represents the abstract base class for a JSON converter for Twitch API data transfer objects.
    /// </summary>
    /// <typeparam name="TValue">The type of Twitch API data transfer object to convert to or from JSON.</typeparam>
    [PublicAPI]
    public abstract class TwitchDtoConverter< TValue > : JsonConverter<TValue>
    where TValue : ITwitchDto
    {
        private static Type genericType = typeof(TValue);
        
        /// <inheritdoc />
        public override bool CanConvert( Type typeToConvert )
            => typeToConvert.IsAbstract && isAssignable(typeToConvert);
        
        private static bool isAssignable( Type typeToConvert )
            => genericType.IsAssignableFrom(typeToConvert);
        
        /// <summary>
        /// Determines the type to convert to based on the specified <paramref name="reader"/> and supplied <paramref name="typeToConvert"/>.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <returns>The type determined to be converted.</returns>
        protected abstract Type DetermineTypeToConvert( Utf8JsonReader reader, Type typeToConvert );
        
        private static void ensureAssignable( Type typeToConvert )
        {
            if (!isAssignable(typeToConvert)) throw new JsonException($"Type '{typeToConvert}' must be assignable to type '{genericType}'.");
        }
        
        /// <inheritdoc />
        [CanBeNull]
        public override TValue Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
        {
            typeToConvert = this.DetermineTypeToConvert(reader, typeToConvert);
            ensureAssignable(typeToConvert);
            return (TValue)JsonSerializer.Deserialize(ref reader, typeToConvert, options);
        }
        
        /// <inheritdoc />
        public override void Write( Utf8JsonWriter writer, TValue value, JsonSerializerOptions options )
        {
            var typeToConvert = value.GetType();
            JsonSerializer.Serialize(writer, value, typeToConvert, options);
        }
    }
}
