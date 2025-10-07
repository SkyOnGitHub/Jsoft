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
    where TValue : TwitchDto
    {
        /// <inheritdoc />
        public override bool CanConvert( Type typeToConvert )
            => canConvert(typeof(TValue), typeToConvert);
        
        private static bool canConvert( Type genericType, Type typeToConvert )
            => genericType.IsAssignableFrom(typeToConvert);
        
        /// <summary>
        /// Determines the type to convert to based on the specified <paramref name="reader"/> and supplied <paramref name="typeToConvert"/>.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <returns>The type determined to be converted.</returns>
        protected abstract Type DetermineTypeToConvert( Utf8JsonReader reader, Type typeToConvert );
        
        private static void ensureCanConvert( Type genericType, Type typeToConvert )
        {
            if (!canConvert(genericType, typeToConvert)) throw new JsonException($"Type '{typeToConvert}' must be assignable to type '{genericType}'.");
        }
        
        private static void ensureNotAbstract( Type typeToConvert )
        {
            if (typeToConvert.IsAbstract) throw new JsonException($"Type '{typeToConvert}' must be non-abstract.");
        }
        
        private static void ensureNotSealed( Type genericType )
        {
            if (genericType.IsSealed) throw new JsonException($"Type must be '{genericType}'.");
        }
        
        /// <inheritdoc />
        [CanBeNull]
        public override TValue Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
        {
            var genericType = typeof(TValue);
            
            if (!genericType.Equals(typeToConvert)) {
                ensureNotSealed(genericType);
                ensureCanConvert(genericType, typeToConvert);
            }
            
            if (!typeToConvert.IsSealed) {
                typeToConvert = this.DetermineTypeToConvert(reader, typeToConvert);
                ensureNotAbstract(typeToConvert);
                ensureCanConvert(genericType, typeToConvert);
            }
            
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
