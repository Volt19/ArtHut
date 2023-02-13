// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArtHut.Pages.Messages
{
	public static class MessagesNavPages
	{
		
		public static string Inbox => "Inbox";
		public static string Sent => "Sent";
		public static string Offers => "Offers";

		public static string InboxNavClass(ViewContext viewContext) => PageNavClass(viewContext, Inbox);
		public static string SentNavClass(ViewContext viewContext) => PageNavClass(viewContext, Sent);
		public static string OffersNavClass(ViewContext viewContext) => PageNavClass(viewContext, Offers);
		public static string PageNavClass(ViewContext viewContext, string page)
		{
			var activePage = viewContext.ViewData["ActivePage"] as string
				?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
			return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
		}
	}
}
