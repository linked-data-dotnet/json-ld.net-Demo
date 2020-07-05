using System;
using JsonLD.Core;
using Newtonsoft.Json.Linq;

namespace JsonLD.Demo
{
    public static class Sample9_CustomRDFParser
    {

        private static readonly string _serialized = Sample6_ToRDF.Run();

        private class CustomRDFParser : IRDFParser
        {
            public RDFDataset Parse(JToken input)
            {
                // by public decree, references to example.org are normalized to https going forward...
                var converted = ((string)input).Replace("http://example.org/", "https://example.org/");
                return RDFDatasetUtils.ParseNQuads(converted);
            }
        }

        internal static void Run()
        {
            var parser = new CustomRDFParser();
            var jsonld = JsonLdProcessor.FromRDF(_serialized, parser);
            Console.WriteLine(jsonld);

            /*

            Output:
            [
                {
                    "@id": "_:b0",
                    "http://schema.org/image": [
                        {
                            "@id": "http://manu.sporny.org/images/manu.png"
                        }
                    ],
                    "http://schema.org/name": [
                        {
                            "@value": "Manu Sporny"
                        }
                    ],
                    "http://schema.org/url": [
                        {
                            "@id": "http://manu.sporny.org/"
                        }
                    ],
                    "@type": [
                        "http://schema.org/Person"
                    ]
                },
                {
                    "@id": "https://example.org/ld-experts",
                    "http://schema.org/member": [
                        {
                            "@id": "_:b0"
                        }
                    ],
                    "http://schema.org/name": [
                        {
                            "@value": "LD Experts"
                        }
                    ]
                }
            ]
            */
        }
    }
}