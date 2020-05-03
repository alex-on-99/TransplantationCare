using System.Collections.Generic;
using System.Threading.Tasks;

namespace TransplantationCare.Core.Interfaces.Validation
{
    public interface IValidation<TModel>
    {
        Dictionary<string, string> Validate(TModel model);
    }
}
