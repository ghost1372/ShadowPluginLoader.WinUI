using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using ShadowPluginLoader.Attributes;
using ShadowPluginLoader.WinUI.Exceptions;
using ShadowPluginLoader.WinUI.Helpers;
using ShadowPluginLoader.WinUI.Models;

namespace ShadowPluginLoader.WinUI;

/// <summary>
/// BasePluginMetaData
/// </summary>
public record BasePluginMetaData : AbstractPluginMetaData
{
    /// <summary>
    /// Plugin Type
    /// </summary>
    [Meta(Exclude = true)]
    public Type MainPlugin { get; private set; } = null!;

    /// <summary>
    /// EntryPoints
    /// </summary>
    [Meta(Exclude = true)]
    public PluginEntryPointType[] EntryPoints { get; private set; } = [];

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public void ToBase(Assembly assembly)
    {
        if (Raw.TryGetProperty(nameof(MainPlugin), out var mainPluginProp) &&
            mainPluginProp.GetString() is { } mainPlugin)
        {
            MainPlugin = assembly.GetType(mainPlugin)!;
        }

        if (MainPlugin == null) throw new PluginLoadMetaException($"Not Found MainPlugin In {Raw.ToString()}");
        if (!Raw.TryGetProperty(nameof(EntryPoints), out var entryPointsProp) ||
            entryPointsProp.ValueKind != JsonValueKind.Array) return;
        var entryPoints = new List<PluginEntryPointType>();
        foreach (var item in entryPointsProp.EnumerateArray())
        {
            var name = item.GetProperty("Name").GetString();
            var type = item.GetProperty("Type").GetString();
            if (name == null || type == null) continue;
            entryPoints.Add(new PluginEntryPointType(name, assembly.GetType(type)!));
        }

        EntryPoints = entryPoints.ToArray();
    }
}