namespace GDSCMobileApp.Extensions;

public class LangueExtension : IMarkupExtension
{
    IStringLocalizer<MyString> _localizer;

    public LangueExtension()
    {
        _localizer = ServiceHelper.GetService<IStringLocalizer<MyString>>();
    }
    public string Key { get; set; } = string.Empty;


    public object ProvideValue(IServiceProvider serviceProvider)
    {
        string localizedText = _localizer[Key];
        return localizedText;
    }
  
}
