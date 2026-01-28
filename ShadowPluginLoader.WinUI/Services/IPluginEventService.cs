using System;
using ShadowPluginLoader.WinUI.Args;

namespace ShadowPluginLoader.WinUI.Services;

/// <summary>
/// PluginEvent Service
/// </summary>
public interface IPluginEventService
{
    /// <summary>
    /// Plugin Enabled
    /// </summary>
    event EventHandler<PluginEventArgs>? PluginEnabled;

    /// <summary>
    /// Plugin Disabled
    /// </summary>
    event EventHandler<PluginEventArgs>? PluginDisabled;

    /// <summary>
    /// Plugin Loaded
    /// </summary>
    event EventHandler<PluginEventArgs>? PluginLoaded;


    /// <summary>
    /// Plugin Plan Upgrade
    /// </summary>
    event EventHandler<PluginEventArgs>? PluginPlanUpgrade;

    /// <summary>
    /// Plugin Upgraded
    /// </summary>
    event EventHandler<PluginEventArgs>? PluginUpgraded;

    /// <summary>
    /// Plugin Plan Remove
    /// </summary>
    event EventHandler<PluginEventArgs>? PluginPlanRemove;

    /// <summary>
    /// Plugin Removed
    /// </summary>
    event EventHandler<PluginEventArgs>? PluginRemoved;
}