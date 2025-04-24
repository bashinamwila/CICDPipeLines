using Csla.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CICDPipeLines.BusinessLibrary.Tests
{
    public class CslaTestFixture
    {
        public IServiceProvider Services { get; }

        public CslaTestFixture()
        {
            var services = new ServiceCollection();
            services.AddCsla();
            Services = services.BuildServiceProvider();
        }
    }
}
