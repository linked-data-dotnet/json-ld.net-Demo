using System;
using JsonLD.Core;

namespace JsonLD.Demo
{
    public static class Sample7_FromRDF
    {

        internal static void Run()
        {
            var serialized = Sample6_ToRDF.Run();
            var opts = new JsonLdOptions();
            var jsonld = JsonLdProcessor.FromRDF(serialized, opts);
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
                    "@id": "http://example.org/ld-experts",
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