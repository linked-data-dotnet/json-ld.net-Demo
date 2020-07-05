using Res = JsonLD.Demo.Resources.Resources;
using System;
using JsonLD.Core;
using Newtonsoft.Json.Linq;

namespace JsonLD.Demo
{
    public class Sample4_Frame
    {
        private static readonly string _docJson = Res.ReadString("doc.json");
        private static readonly string _frameJson = Res.ReadString("frame.json");

        public static void Run()
        {
            var doc = JObject.Parse(_docJson);
            var frame = JObject.Parse(_frameJson);
            var opts = new JsonLdOptions();
            var flattened = JsonLdProcessor.Frame(doc, frame, opts);
            Console.WriteLine(flattened);

            /*

            Output:
            {
                "@context": . . .,
                "@graph": [
                    {
                        "@id": "_:b0",
                        "@type": "Person",
                        "image": "http://manu.sporny.org/images/manu.png",
                        "name": "Manu Sporny",
                        "homepage": "http://manu.sporny.org/"
                    }
                ]
            }

            */

        }
    }
}