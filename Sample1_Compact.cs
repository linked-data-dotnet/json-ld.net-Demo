using Res = JsonLD.Demo.Resources.Resources;
using System;
using JsonLD.Core;
using Newtonsoft.Json.Linq;

namespace JsonLD.Demo
{
    public class Sample1_Compact
    {
        private static readonly string _contextJson = Res.ReadString("context.json");
        private static readonly string _docJson = Res.ReadString("doc.json");

        public static JObject Run()
        {
            var doc = JObject.Parse(_docJson);
            var context = JObject.Parse(_contextJson);
            var opts = new JsonLdOptions();
            var compacted = JsonLdProcessor.Compact(doc, context, opts);
            Console.WriteLine(compacted);

            /*

            Output:
            {
                "@id": "ld-experts",
                "member": {
                    "image": "http://manu.sporny.org/images/manu.png",
                    "name": "Manu Sporny",
                    "homepage": "http://manu.sporny.org/",
                },
                "name": "LD Experts",
                "@context": . . .
            }

            */

            return compacted;
        }
    }
}