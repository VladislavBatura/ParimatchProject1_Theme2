using System.Text.Json;
using System.Text.Json.Serialization;
using Project1_Theme2.Models;

namespace Project1_Theme2.Logic;

public class JsonHandler : JsonConverter<Figure>
{
    private enum TypeDiscriminator
    {
        Figure = 0,
        Line = 1,
        Rectangle = 2,
        Triangle = 3,
        Circle = 4
    }

    public override bool CanConvert(Type type)
    {
        return typeof(Figure).IsAssignableFrom(type);
    }

    public override Figure Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        if (!reader.Read()
                || reader.TokenType != JsonTokenType.PropertyName
                || reader.GetString() != "TypeDiscriminator")
        {
            throw new JsonException();
        }

        if (!reader.Read() || reader.TokenType != JsonTokenType.Number)
        {
            throw new JsonException();
        }

        Figure baseClass;
        TypeDiscriminator typeDiscriminator = (TypeDiscriminator)reader.GetInt32();
        switch (typeDiscriminator)
        {
            case TypeDiscriminator.Line:
                if (!reader.Read() || reader.GetString() != "TypeValue")
                {
                    throw new JsonException();
                }
                if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }
                baseClass = (Line)JsonSerializer.Deserialize(ref reader, typeof(Line));
                break;
            case TypeDiscriminator.Rectangle:
                if (!reader.Read() || reader.GetString() != "TypeValue")
                {
                    throw new JsonException();
                }
                if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }
                baseClass = (Rectangle)JsonSerializer.Deserialize(ref reader, typeof(Rectangle));
                break;
            case TypeDiscriminator.Triangle:
                if (!reader.Read() || reader.GetString() != "TypeValue")
                {
                    throw new JsonException();
                }
                if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }
                baseClass = (Triangle)JsonSerializer.Deserialize(ref reader, typeof(Triangle));
                break;
            case TypeDiscriminator.Circle:
                if (!reader.Read() || reader.GetString() != "TypeValue")
                {
                    throw new JsonException();
                }
                if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }
                baseClass = (Circle)JsonSerializer.Deserialize(ref reader, typeof(Circle));
                break;
            default:
                throw new NotSupportedException();
        }

        if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject)
        {
            throw new JsonException();
        }

        return baseClass;
    }

    public override void Write(
        Utf8JsonWriter writer,
        Figure value,
        JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        if (value is Line line)
        {
            writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Line);
            writer.WritePropertyName("TypeValue");
            JsonSerializer.Serialize(writer, line);
        }
        else if (value is Rectangle rectangle)
        {
            writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Rectangle);
            writer.WritePropertyName("TypeValue");
            JsonSerializer.Serialize(writer, rectangle);
        }
        else if (value is Triangle triangle)
        {
            writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Triangle);
            writer.WritePropertyName("TypeValue");
            JsonSerializer.Serialize(writer, triangle);
        }
        else if (value is Circle circle)
        {
            writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Circle);
            writer.WritePropertyName("TypeValue");
            JsonSerializer.Serialize(writer, circle);
        }
        else
        {
            throw new NotSupportedException();
        }

        writer.WriteEndObject();
    }
}
