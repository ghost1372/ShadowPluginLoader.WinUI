using System;
using ShadowObservableConfig.Attributes;
using System.Collections.ObjectModel;

namespace Config.WinUI;

/// <summary>
/// ������Ⱦģʽö��
/// </summary>
public enum EmojiRenderMode
{
    /// <summary>
    /// ԭ����Ⱦ
    /// </summary>
    Native,
    
    /// <summary>
    /// Twemoji��Ⱦ
    /// </summary>
    Twemoji,
    
    /// <summary>
    /// Segoe UI��Ⱦ
    /// </summary>
    SegoeUi,
    
    /// <summary>
    /// Apple��Ⱦ
    /// </summary>
    Apple,
    
    /// <summary>
    /// Google��Ⱦ
    /// </summary>
    Google
}

/// <summary>
/// Emoji���������
/// </summary>
[ObservableConfig(FileName = "emoji_config", DirPath = "config", Description = "Emoji�������", Version = "1.0.0")]
public partial class EmojiConfig
{
    [ObservableConfigProperty(Description = "Ĭ�ϱ����С")]
    private int defaultEmojiSize;

    [ObservableConfigProperty(Description = "�����Զ����")]
    private bool _enableAutoComplete;

    [ObservableConfigProperty(Name = "MaxEmojiHistory", Description = "��������ʷ��¼��")]
    private int _maxEmojiHistory;

    [ObservableConfigProperty(Name = "DefaultSkinTone", Description = "Ĭ�Ϸ�ɫ")]
    private string _defaultSkinTone = null!;

    [ObservableConfigProperty(Name = "AnimationSpeed", Description = "�����ٶ�")]
    private double _animationSpeed;

    [ObservableConfigProperty(Name = "RenderMode", Description = "������Ⱦģʽ")]
    private EmojiRenderMode _renderMode;

    [ObservableConfigProperty(Name = "LaunchDate", Description = "��������")]
    private DateTime _launchDate;

    [ObservableConfigProperty(Name = "Settings", Description = "��������")]
    private NestedSettings _settings = new();

    [ObservableConfigProperty(Name = "FavoriteEmojis", Description = "�ղصı����б�")]
    private ObservableCollection<string> _favoriteEmojis = new ();

    [ObservableConfigProperty(Name = "CustomSettings", Description = "�Զ��������б�")]
    private ObservableCollection<NestedSettings> _customSettings = new();
}

/// <summary>
/// �ڲ�������ʾ��
/// </summary>
[ObservableConfig(Description = "Ƕ������", Version = "1.0.0")]
public partial class NestedSettings
{
    [ObservableConfigProperty(Name = "NestedValue", Description = "Ƕ��ֵ")]
    private string _nestedValue;

    [ObservableConfigProperty(Name = "NestedNumber", Description = "Ƕ������")]
    private int _nestedNumber;

    [ObservableConfigProperty(Name = "NestedBoolean", Description = "Ƕ�ײ���ֵ")]
    private bool _nestedBoolean;

}