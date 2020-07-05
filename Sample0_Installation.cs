using JsonLD.Core;
using Newtonsoft.Json.Linq;
using System;

namespace JsonLD.Demo
{
    public static class Sample0_Installation
    {

        public static void Run()
        {
            var json = "{'@context':{'test':'http://www.example.org/'},'test:hello':'world'}";
            var document = JObject.Parse(json);
            var expanded = JsonLdProcessor.Expand(document);
            Console.WriteLine(expanded);
        }
    }
}