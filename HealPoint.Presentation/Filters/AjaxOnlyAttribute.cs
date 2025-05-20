using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace HealPoint.Presentation.Filters;

public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
{
	public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
	{
		var request = routeContext.HttpContext.Request;
		return request.Headers["x-requested-with"] == "XMLHttpRequest";
	}
}
