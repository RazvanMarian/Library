using System.ComponentModel.DataAnnotations;

namespace Library.Dtos;

public abstract class DtoValidator
{
    public virtual List<ValidationResult> Validate()
    {
        var context = new ValidationContext(this, serviceProvider: null, items: null);
        var errorResults = new List<ValidationResult>();
        Validator.TryValidateObject(this, context, errorResults, true);

        return errorResults;
    }
}
