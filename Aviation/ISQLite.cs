using System;

namespace Aviation
{
    public interface ISQLite
    {
        SQLite.Net.Interop.ISQLitePlatform GetConnection();
        string GetPath();
    }
}
