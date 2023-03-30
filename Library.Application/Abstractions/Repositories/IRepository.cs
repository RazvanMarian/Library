namespace Library.Application.Abstractions.Repositories;

public interface IRepository<TModel> where TModel : class
{
    TModel? Add(TModel model);
    TModel? Update(TModel model);
    TModel? Get(string key);
    List<TModel> GetAll();
}
