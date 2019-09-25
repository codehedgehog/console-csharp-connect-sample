/*
	Copyright (c) 2019 Microsoft Corporation. All rights reserved. Licensed under the MIT license.
	See LICENSE in the project root for license information.
*/

using Microsoft.Graph;
using Microsoft.Identity.Client;
using netfx_console_csharp_connect_sample.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace netfx_console_csharp_connect_sample
{
	/// <summary>
	/// This static class returns a fully constructed
	/// instance of the GraphServiceClient with the client
	/// data to be used when authenticating requests to the Graph API
	/// </summary>
	public static class GraphClientFactory
	{
		public static GraphServiceClient GetGraphServiceClient(string clientId, string authority, IEnumerable<string> scopes)
		{
			var authenticationProvider = CreateAuthorizationProvider(clientId, authority, scopes);
			return new GraphServiceClient(authenticationProvider);
		}

		private static IAuthenticationProvider CreateAuthorizationProvider(string clientId, string authority, IEnumerable<string> scopes)
		{
			PublicClientApplication clientApplication = (PublicClientApplication)PublicClientApplicationBuilder.Create(clientId: clientId).WithAdfsAuthority(authorityUri: authority).Build();
			return new MsalAuthenticationProvider(clientApplication, scopes.ToArray());
		}
	}
}