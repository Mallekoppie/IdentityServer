using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerCustomClaims
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile()                    
                };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
                {
                    new Client
                    {
                        ClientId = "client",

                        AllowedGrantTypes = {
                                                GrantType.Hybrid,
                                                GrantType.ClientCredentials,
                                                GrantType.ResourceOwnerPassword                                                
                                            },
                        // secret for authentication
                        ClientSecrets =
                                    {
                            new Secret("secret".Sha256())
                                    },

                        // scopes that client has access to
                        AllowedScopes = { "api1", "openid" },
                        AccessTokenType = AccessTokenType.Jwt,
                        AllowOfflineAccess = true,
                        AlwaysIncludeUserClaimsInIdToken = true,
                        AlwaysSendClientClaims = true,                        
                        
                    }
    };
}
    }
}
