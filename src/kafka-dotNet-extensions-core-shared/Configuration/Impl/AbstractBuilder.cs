using System;
using System.Collections.Generic;
using System.Text;

namespace kafka_dotNet_extensions_core.Configuration
{
    public abstract class AbstractBuilder : IBuilder
    {
        protected Dictionary<string, object> _configuration = new Dictionary<string, object>();
    }
}
