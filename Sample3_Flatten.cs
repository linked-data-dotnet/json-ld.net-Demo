using Res = JsonLD.Demo.Resources.Resources;
using System;
using JsonLD.Core;
using Newtonsoft.Json.Linq;

namespace JsonLD.Demo
{
    public class Sample3_Flatten
    {
        private static readonly string _contextJson = Res.ReadString("context.json");
        private static readonly string _docJson = Res.ReadString("doc.json");

        public static void Run()
        {
            var doc = JObject.Parse(_docJson);
            var context = JObject.Parse(_contextJson);
            var opts = new JsonLdOptions();
            var flattened = JsonLdProcessor.Flatten(doc, context, opts);
            Console.WriteLine(flattened);

            /*

            Output:
            {
                "@context": . . .,
                "@graph": [
                    {
                        "@id": "_:b0",
                        "image": "http://manu.sporny.org/images/manu.png",
                        "name": "Manu Sporny",
                        "homepage": "http://manu.sporny.org/"
                    },
                    {
                        "@id": "ld-experts",
                        "member": {
                            "@id": "_:b0"
                        },
                        "name": "LD Experts"
                    }
                ]
            }

            */

        }
    }
}