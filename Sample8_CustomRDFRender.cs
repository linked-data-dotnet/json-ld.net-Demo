using Res = JsonLD.Demo.Resources.Resources;
using System;
using JsonLD.Core;
using Newtonsoft.Json.Linq;

namespace JsonLD.Demo
{
    public static class Sample8_CustomRDFRender
    {
        private static readonly string _docJson = Res.ReadString("doc.json");

        private class JSONLDTripleCallback : IJSONLDTripleCallback
        {
            public object Call(RDFDataset dataset) =>
                RDFDatasetUtils.ToNQuads(dataset); // serialize the RDF dataset as NQuads
        }

        internal static void Run()
        {
            var doc = JObject.Parse(_docJson);
            var callback = new JSONLDTripleCallback();
            var serialized = JsonLdProcessor.ToRDF(doc, callback);
            Console.WriteLine(serialized);

            /*

            Output:
            <http://example.org/ld-experts> <http://schema.org/member> _:b0 .
            <http://example.org/ld-experts> <http://schema.org/name> "LD Experts" .
            _:b0 <http://schema.org/image> <http://manu.sporny.org/images/manu.png> .
            _:b0 <http://schema.org/name> "Manu Sporny" .
            _:b0 <http://schema.org/url> <http://manu.sporny.org/> .
            _:b0 <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://schema.org/Person> .

            */
        }
    }
}