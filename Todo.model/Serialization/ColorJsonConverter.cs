using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Todo.model.Serialization
{
    public class ColorJsonConverter : JsonConverter<Color>
    {
        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);

            JsonElement root = document.RootElement;

            int r = root.GetProperty("R").GetInt32();
            int g = root.GetProperty("G").GetInt32();
            int b = root.GetProperty("B").GetInt32();
            int a = root.GetProperty("A").GetInt32();

            return Color.FromArgb(a, r, g, b);
        }

        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("R", value.R);
            writer.WriteNumber("G", value.G);
            writer.WriteNumber("B", value.B);
            writer.WriteNumber("A", value.A);
            writer.WriteEndObject();
        }
    }
}
