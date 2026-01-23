using NuGet.Versioning;
using ShadowPluginLoader.Attributes;
using ShadowPluginLoader.WinUI.Interfaces;
using ShadowPluginLoader.WinUI.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using ShadowPluginLoader.WinUI.Helpers;

namespace ShadowPluginLoader.WinUI;

/// <summary>
/// Abstract PluginMetaData
/// </summary>
public abstract record AbstractPluginMetaData : IPluginMetaData
{
    /// <summary>
    /// <inheritdoc cref="IPluginMetaData.Id"/>
    /// </summary>
    [Meta(Required = true)]
    public string Id { get; init; } = null!;

    /// <summary>
    /// <inheritdoc cref="IPluginMetaData.Name"/>
    /// </summary>
    [Meta(Required = true)]
    public string Name { get; init; } = null!;

    /// <summary>
    /// <inheritdoc cref="IPluginMetaData.BuiltIn"/>
    /// </summary>
    [Meta(Exclude = true)]
    public bool BuiltIn { get; init; }

    /// <summary>
    /// <inheritdoc cref="IPluginMetaData.DllName"/>
    /// </summary>
    [Meta(Exclude = true)]
    public string DllName { get; init; } = null!;


    /// <summary>
    /// <inheritdoc cref="IPluginMetaData.Version"/>
    /// </summary>
    [Meta(Required = true, AsString = true)]
    public NuGetVersion Version { get; init; } = null!;

    /// <summary>
    /// <inheritdoc cref="IPluginMetaData.SdkVersion"/>
    /// </summary>
    [Meta(Required = false, AsString = true)]
    public VersionRange SdkVersion { get; init; } = null!;


    /// <summary>
    /// <inheritdoc cref="IPluginMetaData.Priority"/>
    /// </summary>
    [Meta(Required = false)]
    public int Priority { get; init; }

    /// <summary>
    /// <inheritdoc cref="IPluginMetaData.Dependencies"/>
    /// </summary>
    [Meta(Exclude = true, AsString = true)]
    public PluginDependency[] Dependencies { get; init; } = [];


    /// <summary>
    /// 
    /// </summary>
    private static readonly Type TargetTypeList = typeof(PluginEntryPointType[]);

    /// <summary>
    /// <inheritdoc cref="IPluginMetaData.Raw"/>
    /// </summary>
    [Meta(Exclude = true)]
    public JsonElement Raw { get; private set; }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <typeparam name="TMeta"></typeparam>
    /// <returns></returns>
    public static TMeta? ToMeta<TMeta>(string content) where TMeta : AbstractPluginMetaData
    {
        using var doc = JsonDocument.Parse(content);
        var root = doc.RootElement;

        var meta = root.Deserialize<TMeta>(MetaDataHelper.Options);
        if (meta != null) meta.Raw = root.Clone();
        return meta;
    }

    
}