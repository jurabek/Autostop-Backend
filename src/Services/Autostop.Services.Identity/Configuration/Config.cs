using System.Collections.Generic;
using Autostop.Services.Identity.Constants;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Autostop.Services.Identity.Configuration
{
    public static class Config
    {
        public static List<TestUser> TestUsers()
        {
            return new List<TestUser>
            {
                new TestUser { Username = "test@test.com", Password = "password", SubjectId = "1" },
                new TestUser { Username = "test1@test.com", Password = "password", SubjectId = "2" }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Phone(),
                new IdentityResources.Email()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource ("estimates", "Estimates Identity Api") { UserClaims = { JwtClaimTypes.Role, JwtClaimTypes.PhoneNumber } },
                new ApiResource ("maps", "Maps Identity Api") { UserClaims = { JwtClaimTypes.Role, JwtClaimTypes.PhoneNumber } },
                new ApiResource ("rides", "Rides Identity Api") { UserClaims = { JwtClaimTypes.Role, JwtClaimTypes.PhoneNumber } }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "phone_number_authentication",
                    AllowedGrantTypes = new List<string> { IdentityConstants.GrantType.VerifyPhoneNumber },
                    ClientSecrets = { new Secret ("secret".Sha256 ()) },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.OfflineAccess
                    },
                    AllowOfflineAccess = true
                },
                
                new Client
                {
                    ClientId = "resource_owner",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret ("secret".Sha256 ()) },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "estimates",
                        "maps",
                        "rides"
                    },
                    AllowOfflineAccess = true
                },

                new Client
                {
                    ClientId = "mvc_client",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    RequireConsent = true,
                    ClientSecrets = { new Secret ("secret".Sha256()) },
                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "estimates",
                        "maps",
                        "rides"
                    },
                    AllowOfflineAccess = true
                }
            };
        }
    }
}