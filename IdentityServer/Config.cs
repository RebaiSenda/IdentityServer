using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
       [
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
       ];


    public static IEnumerable<ApiScope> ApiScopes =>
        [
        new ApiScope(name: "resevrationApi", displayName: "ReservationAPI"),
        new ApiScope(name: "KataReservation.Api", displayName: "ReservationAPI"),
        ];

    public static IEnumerable<Client> Clients =>
       [
        new Client
        {
            ClientId = "postman",

            // no interactive user, use the clientid/secret for authentication
            AllowedGrantTypes = GrantTypes.ClientCredentials,

            // secret for authentication
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },

            // scopes that client has access to
            AllowedScopes = { "resevrationApi" }
        },
                // interactive ASP.NET Core Web App
        new Client
        {
            ClientId = "web",
            ClientSecrets = { new Secret("secret".Sha256()) },

            AllowedGrantTypes = GrantTypes.Code,
            
            // where to redirect to after login
            RedirectUris = { "https://localhost:7002/signin-oidc"},

            // where to redirect to after logout
            PostLogoutRedirectUris = { "https://localhost:7002/signout-callback-oidc" },

            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                 "KataReservation.Api"
            }
        }
       ];

}