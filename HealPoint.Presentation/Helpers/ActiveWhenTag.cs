﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HealPoint.Presentation.Helpers;

[HtmlTargetElement("a", Attributes = "active-when")]
public class ActiveWhenTag : TagHelper
{
	public string? ActiveWhen { get; set; }

	[ViewContext]
	[HtmlAttributeNotBound]
	public ViewContext? ViewContextData { get; set; }

	public override void Process(TagHelperContext context, TagHelperOutput output)
	{
		if (string.IsNullOrEmpty(ActiveWhen))
			return;
		var currentController = ViewContextData?.RouteData.Values["controller"] ?? "";

		if (currentController.ToString()!.Equals(ActiveWhen))
		{
			if (output.Attributes.ContainsName("class"))
				output.Attributes.SetAttribute("class", $"{output.Attributes["class"].Value} active");
			else
				output.Attributes.SetAttribute("class", "active");

		}
	}
}
