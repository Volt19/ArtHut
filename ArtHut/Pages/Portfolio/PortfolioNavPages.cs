 // Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArtHut.Pages.Portfolio
{
	public static class PortfolioNavPages
	{

        public static string Artworks => "Artworks";
        public static string AboutMyWork => "AboutMyWork";
        public static string AboutMe => "AboutMe";

        public static string ArtworksNavClass(ViewContext viewContext) => PageNavClass(viewContext, Artworks);
        public static string AboutMyWorkNavClass(ViewContext viewContext) => PageNavClass(viewContext, AboutMyWork);
        public static string AboutMeNavClass(ViewContext viewContext) => PageNavClass(viewContext, AboutMe);
        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
