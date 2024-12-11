using System.Text.Json;
using System.Text.Json.Serialization;

namespace E_commerce.EF.Data.extentions
{
    public class JsonDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
          
            if (reader.TokenType == JsonTokenType.String)
            {
              
                var dateString = reader.GetString();

               
                return DateTime.ParseExact(dateString, "yyyy-MM-ddTHH:mm:ss", null);
            }

            throw new JsonException("Invalid date format");
        }

      
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss"));
        }
    }
}