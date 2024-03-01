namespace BridgeExample.Models;

public abstract class PersonSaverLoaderFactory(ILoaderFactory loaderFactory, ISaverFactory saverFactory)
{
    public virtual bool IsMatch(string path)
    {
        return _loaderFactory.IsMatch(path) &&
               _saverFactory.IsMatch(path);
    }

    public virtual IPersonLoader CreateLoader()
    {
        return _loaderFactory.CreateLoader();
    }

    public virtual IPersonSaver CreateSaver()
    {
        return _saverFactory.CreateSaver();
    }

    private ILoaderFactory _loaderFactory = loaderFactory;
    private ISaverFactory _saverFactory = saverFactory;
}