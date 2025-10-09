using System.Text.Json;
using JetBrains.Annotations;

namespace Jsoft
{
    /// <summary>
    /// Represents the abstract base class for Twitch API data transfer objects.
    /// </summary>
    [PublicAPI]
    public abstract class TwitchDto
    {
        /// <summary>
        /// Parses the supplied JSON into a new instance of <see cref="TValue"/> using the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="json">The JSON string to parse into a new instance of <see cref="TValue"/>.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        /// <typeparam name="TValue">The type of Twitch API data transfer object to convert from JSON.</typeparam>
        /// <returns>The new <see cref="TValue"/> instance.</returns>
        /// <exception cref="JsonException">Unable to parse <typeparamref name="TValue"/> from JSON.</exception>
        public static TValue Parse< TValue >( string json, JsonSerializerOptions options = default )
        where TValue : TwitchDto
        {
            var typeToConvert = typeof(TValue);
            var deserialized  = JsonSerializer.Deserialize(json, typeToConvert, options) ?? throw new JsonException($"Unable to parse type '{typeToConvert}'.");
            return (TValue)deserialized;
        }
        
        /// <summary>
        /// Returns the JSON representation of the current instance using the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">An object that specifies serialization options to use.</param>
        /// <returns>The JSON representation of the current instance.</returns>
        public string ToJson( JsonSerializerOptions options = default )
        {
            var typeToConvert = this.GetType();
            return JsonSerializer.Serialize(this, typeToConvert, options);
        }
        
        /// <summary>
        /// Returns the JSON representation of the current instance.
        /// </summary>
        /// <returns>The JSON representation of the current instance.</returns>
        /// <remarks>default(<see cref="JsonSerializerOptions"/>) is used for the serialization to JSON.</remarks>
        public override string ToString()
            => this.ToJson();
    }
}
