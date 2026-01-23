using NuGet.Versioning;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ShadowPluginLoader.WinUI.Converters;

/// <summary>
/// 自定义的 JSON 转换器，用于处理 NuGetVersion 类型的序列化和反序列化
/// </summary>
public class NuGetVersionJsonConverter : JsonConverter<NuGetVersion>
{
    /// <summary>
    /// 将 JSON 数据反序列化为 NuGetVersion 对象
    /// </summary>
    /// <param name="reader">UTF-8 JSON 读取器</param>
    /// <param name="typeToConvert">要转换的目标类型</param>
    /// <param name="options">JSON 序列化选项</param>
    /// <returns>反序列化后的 NuGetVersion 对象</returns>
    public override NuGetVersion? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // 从读取器中获取字符串值并创建新的 NuGetVersion 实例
        return new NuGetVersion(reader.GetString()!);
    }

    /// <summary>
    /// 将 NuGetVersion 对象序列化为 JSON 数据
    /// </summary>
    /// <param name="writer">UTF-8 JSON 写入器</param>
    /// <param name="value">要序列化的 NuGetVersion 对象</param>
    /// <param name="options">JSON 序列化选项</param>
    public override void Write(Utf8JsonWriter writer, NuGetVersion value, JsonSerializerOptions options)
    {
        // 将 NuGetVersion 对象的字符串表示形式写入 JSON 输出
        writer.WriteStringValue(value.ToString());
    }
}