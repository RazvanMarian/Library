using Library.Application.Abstractions.Repositories;
using Library.Core.Abstractions;
using Newtonsoft.Json;

namespace Library.Infrastructure.Abstractions;

public class Repository<TModel> : IRepository<TModel> where TModel : class, IModel
{
    public virtual TModel? Add(TModel model)
    {
        if (entities.Contains(model))
        {
            return null;
        }
        else
        {
            entities.Add(model);
            return model;
        }
    }

    public virtual TModel? Delete(TModel model)
    {
        if (entities.Contains(model))
        {
            if (entities.Remove(model))
                return model;
            else
                return null;
        }
        else return null;
    }

    public virtual List<TModel> GetAll()
        =>  entities;
   

    public virtual TModel? Update(TModel model)
    {
        if (entities.Contains(model))
        {
            TModel? temp = entities.Find(m => m.Key == model.Key);
            temp = model;
            return model;
        }
        else
        {
            return null;
        }
    }

    public virtual TModel? Get(string key)
        => entities.Find(m => m.Key == key);

    public int Count()
    {
        return entities.Count;
    }

    protected List<TModel> entities = new List<TModel>();
}
