
public class AppLogger
{
    // Holds the single instance.
    private static AppLogger? _instance = null;

    // Private constructor prevents creating objects from outside.
    private AppLogger()
    {
    }

    public static AppLogger GetLogger()
    {
        if (_instance == null)
        {
            _instance = new AppLogger();
        }

        return _instance;
    }
}