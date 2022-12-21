using GDSCMobileApp.Extensions;

namespace GDSCMobileApp.Services;

public class TranslateService : ITranslate
{
    private IServiceProvider _serviceProvider { get; set; }

    public TranslateService(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public string GetValue(string key)
        => (string)new LangueExtension()
        {
            Key = key
        }.ProvideValue(_serviceProvider);


}
