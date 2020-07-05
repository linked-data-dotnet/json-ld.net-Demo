using Res = JsonLD.Demo.Resources.Resources;
using System;
using JsonLD.Core;
using Newtonsoft.Json.Linq;

namespace JsonLD.Demo
{
    public class SampleA_RemoteDocumentLoader
    {
        private static readonly string _docJson = Res.ReadString("doc.json");

        public class CustomDocumentLoader : DocumentLoader
        {
            private static readonly string _cachedExampleOrgContext = Res.ReadString("context.json");

            public override RemoteDocument LoadDocument(string url)
            {
                if (url == "http://example.org/context.jsonld") // we have this cached locally
                {
                    var doc = new JObject(new JProperty("@context", JObject.Parse(_cachedExampleOrgContext)));
                    return new RemoteDocument(url, doc);
                }
                else
                {
                    return base.LoadDocument(url);
                }
            }
        }

        public static void Run()
        {
            var doc = JObject.Parse(_docJson);
            var remoteContext = JObject.Parse("{'@context':'http://example.org/context.jsonld'}");
            var opts = new JsonLdOptions { documentLoader = new CustomDocumentLoader() };
            var compacted = JsonLdProcessor.Compact(doc, remoteContext, opts);
            Console.WriteLine(compacted);

            /*

            Output:
            {
                "@id": "http://example.org/ld-experts",
                "member": {
                    "@type": "Person",
                    "image": "http://manu.sporny.org/images/manu.png",
                    "name": "Manu Sporny",
                    "homepage": "http://manu.sporny.org/"
                },
                "name": "LD Experts"
            }

            */
        }
    }
}