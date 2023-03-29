namespace Library.Application.Abstractions.Repositories;

public interface IRepository<TModel> where TModel : class
{
    TModel? Add(TModel model);
    TModel? Update(TModel model);
    List<TModel> GetAll();
    TModel? Get(string key);
    TModel? Delete(TModel model);
    int Count();
}
