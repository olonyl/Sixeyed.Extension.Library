using System.Linq;
using System.Linq.Expressions;

namespace System.Web.Mvc.Html
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString EnumDropDownListForCustom<TModel, TEnum>
            (this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> enumAccesor)
        {
            var propertyInfo = enumAccesor.ToPropertyInfo();
            var enumType = propertyInfo.PropertyType;
            var enumValues = Enum.GetValues(enumType).Cast<Enum>();
            var selectItems = enumValues.Select(x => new SelectListItem
            {
                Text = x.GetDescription(),
                Value = x.ToString()
            });
            return htmlHelper.DropDownListFor(enumAccesor, selectItems);

        }
    }
}
