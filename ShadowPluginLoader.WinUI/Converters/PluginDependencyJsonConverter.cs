using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ShadowPluginLoader.WinUI.Models;

namespace ShadowPluginLoader.WinUI.Converters;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// 自定义JSON转换器，用于处理PluginDependency类型的序列化和反序列化
/// </summary>
public class PluginDependencyJsonConverter : JsonConverter<PluginDependency>
{
    /// <summary>
    /// 从JSON中读取并转换为PluginDependency对象
    /// </summary>
    /// <param name="reader">UTF-8 JSON读取器</param>
    /// <param name="typeToConvert">目标转换类型</param>
    /// <param name="options">JSON序列化选项</param>
    /// <returns>反序列化后的PluginDependency对象</returns>
    public override PluginDependency? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
            throw new JsonException("Expected StartObject");

        var id = "";
        var need = "";

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
                break;

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();
                reader.Read();

                switch (propertyName)
                {
                    case "Id":
                        id = reader.TokenType == JsonTokenType.String ? reader.GetString() ?? "" : "";
                        break;
                    case "Need":
                        need = reader.TokenType == JsonTokenType.String ? reader.GetString() ?? "" : "";
                        break;

                    default:
                        reader.Skip();
                        break;
                }
            }
        }

        return new PluginDependency(id, need);
    }

    /// <summary>
    /// 将PluginDependency对象写入JSON
    /// </summary>
    /// <param name="writer">UTF-8 JSON写入器</param>
    /// <param name="value">要序列化的PluginDependency对象</param>
    /// <param name="options">JSON序列化选项</param>
    public override void Write(Utf8JsonWriter writer, PluginDependency value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("Id", value.Id);
        writer.WriteString("Need", value.Need.ToString());
        writer.WriteEndObject();
    }
}
