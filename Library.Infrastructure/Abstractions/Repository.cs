using Library.Application.Abstractions.Repositories;
using Library.Core.Abstractions;
using Newtonsoft.Json;

namespace Library.Infrastructure.Abstractions;

public class Repository<TModel> : IRepository<TModel> where TModel : class, IModel
{
    public virtual TModel? Add(TModel model)
    {
        if (entities.Find(m => m.Key == model.Key) is not null)
        {
            return null;
        }
        else
        {
            entities.Add(model);
            return model;
        }
    }

    public virtual List<TModel> GetAll()
        =>  entities;
   
    public virtual TModel? Update(TModel model)
    {
        var entity = entities.Find(m => m.Key == model.Key);
        if (entity is not null)
        {
            entity = model;
            return model;
        }
        else
        {
            return null;
        }
    }

    public virtual TModel? Get(string key)
        => entities.Find(m => m.Key == key);

    protected List<TModel> entities = new List<TModel>();
}
