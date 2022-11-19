using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTechnicalTest.Tests.Mocks
{
    public class ConfigurationGetJwtKeyMock : IConfiguration
    {
        public string? this[string key] { 
            get => "k_Ar0BKcNW8M1CtZzc7xT86wDOI8T54bwqxrLQBzL4AfQ6gr6buRv9r3JOUDE0rllqNuE0TdwDNAGVMvlEFbuTPLhOFmoXL"; 
            set => throw new NotImplementedException(); 
        }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new NotImplementedException();
        }

        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        public IConfigurationSection GetSection(string key)
        {
            throw new NotImplementedException();
        }
    }
}
