using System.Data.Common;

namespace Foodie.Core.Repositories;

public class BaseRepository(DbConnection connection): IDisposable
{
    protected readonly DbConnection Connection = connection;
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            Connection.Close();
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
