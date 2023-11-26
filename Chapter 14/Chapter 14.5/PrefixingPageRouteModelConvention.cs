using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Chapter_14._5
{
    public class PrefixingPageRouteModelConvention
        : IPageRouteModelConvention
    {
        public void Apply(PageRouteModel model)
        {
            var selectors = model.Selectors
                .Select(selector => new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel
                    {
                        Template = AttributeRouteModel.CombineTemplates(
                            "page",
                            selector.AttributeRouteModel!.Template),
                    }
                }).ToList();
            foreach (var newSelector in selectors)
            {
                model.Selectors.Add(newSelector);
            }
        }
    }
}
