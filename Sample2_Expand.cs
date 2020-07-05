using System;
using JsonLD.Core;
using Newtonsoft.Json.Linq;

namespace JsonLD.Demo
{
    public class Sample2_Expand
    {
        public static JArray Run()
        {
            var compacted = Sample1_Compact.Run();
            var expanded = JsonLdProcessor.Expand(compacted);
            Console.WriteLine(expanded);

            /*

            Output:
            [
                {
                    "@id": "http://example.org/ld-experts",
                    "http://schema.org/member": [
                        {
                            "http://schema.org/url": [
                                {
                                    "@id": "http://manu.sporny.org/"
                                }
                            ],
                            "http://schema.org/image": [
                                {
                                    "@id": "http://manu.sporny.org/images/manu.png"
                                }
                            ],
                            "http://schema.org/name": [
                                {
                                    "@value": "Manu Sporny"
                                }
                            ]
                        }
                    ]
                }
            ]

            */

            return expanded;
        }
    }
}