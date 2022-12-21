using SQLite;

namespace GDSCMobileApp.Services;

public class SqlLiteDatabaseManager<T> : IDatabaseManager<T> where T : new()
{
    public static SQLiteAsyncConnection Connection { get; set; }
    
    public SqlLiteDatabaseManager(string database)
    {
        Connection = new SQLiteAsyncConnection(database);
        Connection.CreateTableAsync<T>().Wait();
    }

    public async Task<bool> AddElement(T element)
    {
        if (Connection == null)
            return false;
        if (element != null)
            await Connection.DeleteAsync(element);
        return true;
    }

    public async Task<bool> Delete(string Id, string tablename = "")
    {
        int temp = 0;
        if (Connection == null)
            return false;
        var data = Connection.GetAsync<T>(Id).Result;
        if(data is not null)
            temp = await Connection.DeleteAsync(data);
        return temp > 0 ;
    }

    public async Task<T> Get(string Id, string tablename = "")
    {
        if (Connection == null)
            return new T();
        return await Connection.GetAsync<T>(Id);
    }

    public async Task<List<T>> GetAllElements()
    {
        if (Connection == null)
            return new List<T>();
        var list = await Connection.Table<T>().ToListAsync();
        return list;
    }

    public async Task<bool> UpdateElement(T element, string Id)
        =>   await Connection.UpdateAsync(element) > 0;
    
}

