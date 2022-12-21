using Firebase.Database;
using Firebase.Database.Query;
using GDSCMobileApp.Customs;

namespace GDSCMobileApp.Services;

public class FirebaseManager<T> : IDatabaseManager<T> where T : new()
{
    FirebaseClient firebase = new FirebaseClient(Constants.FirebaseAdresse, new FirebaseOptions()
    {
        AuthTokenAsyncFactory = () => Task.FromResult(Constants.FirebaseKey)
    });
  
    public async Task<bool> AddElement(T element)
    {
        try
        {
            await firebase.Child(element.GetType().Name).PostAsync(element);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> Delete(string Id, string tablename = "")
    {
        try
        {
            await firebase.Child(tablename).Child(Id).DeleteAsync();
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }

    public async Task<T> Get(string Id, string tablename = "")
    {
        try
        {
            var task = await firebase.Child(tablename).Child(Id).OnceAsync<T>();
            return task.First().Object;
        }
        catch (Exception)
        {

            return new T();
        }
    }

    public async Task<List<T>> GetAllElements()
    {
        try
        {
            var task = await firebase.Child(nameof(T)).OnceAsListAsync<T>() ;
            var data =  task.Select(f => new T());
            return data.ToList();
        }
        catch (Exception)
        {
            return new List<T>();
        }
    }

    public async Task<bool> UpdateElement(T element, string Id)
    {
        try
        {
            await firebase.Child(nameof(T)).Child(Id.ToString()).PutAsync(element);
            return true;
        }
        catch (Exception )
        {
            return false;
        }
    }
}
