using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;
using System.Threading.Tasks;

namespace MainProject.Binders;

public class DecimalModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
            throw new ArgumentNullException(nameof(bindingContext));

        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

        if (valueProviderResult != ValueProviderResult.None)
        {
            string value = valueProviderResult.FirstValue;

            if (!string.IsNullOrEmpty(value))
            {
                
                value = value.Replace(".", ",");

                if (decimal.TryParse(value, NumberStyles.Number, new CultureInfo("pt-BR"), out decimal result))
                {
                    bindingContext.Result = ModelBindingResult.Success(result);
                }
            }
        }

        return Task.CompletedTask;
    }
}
