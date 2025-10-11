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
        /// <inheritdoc />
        public override bool Equals( object obj )
        {
            var typeToConvert = obj.GetType();
            var json = JsonSerializer.Serialize(obj, typeToConvert);
            return this.Equals(json);
        }
        
        /// <summary>
        /// Determines whether the specified JSON is equal to the current object's JSON representation.
        /// </summary>
        /// <param name="json">The JSON to compare with the current object's JSON representation.</param>
        /// <returns>
        /// <see langword="true"/> if the specified JSON is equal to the current object's JSON representation;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public bool Equals( string json )
            => this.ToJson().Equals(json);
        
        /// <inheritdoc />
        public override int GetHashCode()
            => this.ToJson().GetHashCode();
        
        /// <summary>
        /// Parses the supplied JSON into a new instance of <see cref="TValue"/>.
        /// </summary>
        /// <param name="json">The JSON string to parse into a new instance of <see cref="TValue"/>.</param>
        /// <typeparam name="TValue">The type of Twitch API data transfer object to convert from JSON.</typeparam>
        /// <returns>The new <see cref="TValue"/> instance.</returns>
        /// <exception cref="JsonException">Unable to parse <typeparamref name="TValue"/> from JSON.</exception>
        public static TValue Parse< TValue >( string json )
        where TValue : TwitchDto
        {
            var typeToConvert = typeof(TValue);
            var deserialized  = JsonSerializer.Deserialize(json, typeToConvert) ?? throw new JsonException($"Unable to parse type '{typeToConvert}'.");
            return (TValue)deserialized;
        }
        
        /// <summary>
        /// Returns the JSON representation of the current instance.
        /// </summary>
        /// <returns>The JSON representation of the current instance.</returns>
        public string ToJson()
        {
            var typeToConvert = this.GetType();
            return JsonSerializer.Serialize(this, typeToConvert);
        }
        
        /// <summary>
        /// Returns the JSON representation of the current instance.
        /// </summary>
        /// <returns>The JSON representation of the current instance.</returns>
        public override string ToString()
            => this.ToJson();
    }
}
