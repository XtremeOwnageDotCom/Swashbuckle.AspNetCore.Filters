﻿using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Examples;
using System.Collections.Generic;

namespace Swashbuckle.AspNetCore.Filters.Examples
{
    internal class JsonFormatter
    {
        public object FormatJson(IExamplesProvider provider, JsonSerializerSettings serializerSettings, bool includeMediaType)
        {
            object examples;
            if (includeMediaType)
            {
                examples = new Dictionary<string, object>
                {
                    {
                        "application/json", provider.GetExamples()
                    }
                };
            }
            else
            {
                examples = provider.GetExamples();
            }

            var jsonString = JsonConvert.SerializeObject(examples, serializerSettings);
            var result = JsonConvert.DeserializeObject(jsonString);
            return result;
        }
    }
}