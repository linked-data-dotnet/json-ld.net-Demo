using Res = JsonLD.Demo.Resources.Resources;
using System;
using JsonLD.Core;
using Newtonsoft.Json.Linq;

namespace JsonLD.Demo
{
    public static class Sample5_Normalize
    {
        private static readonly string _docJson = Res.ReadString("doc.json");

        internal static void Run()
        {
            var doc = JObject.Parse(_docJson);
            var opts = new JsonLdOptions();
            var normalized = (RDFDataset)JsonLdProcessor.Normalize(doc, opts);
            Console.WriteLine(normalized.Dump());

            /*

            Output:
            @default
                subject
                        type      blank node
                        value     _:c14n0
                predicate
                        type      IRI
                        value     http://schema.org/image
                object
                        type      IRI
                        value     http://manu.sporny.org/images/manu.png
                ---
                subject
                        type      blank node
                        value     _:c14n0
                predicate
                        type      IRI
                        value     http://schema.org/name
                object
                        type      literal
                        value     Manu Sporny
                        datatype  http://www.w3.org/2001/XMLSchema#string
                ---
                subject
                        type      blank node
                        value     _:c14n0
                predicate
                        type      IRI
                        value     http://schema.org/url
                object
                        type      IRI
                        value     http://manu.sporny.org/
                ---
                subject
                        type      blank node
                        value     _:c14n0
                predicate
                        type      IRI
                        value     http://www.w3.org/1999/02/22-rdf-syntax-ns#type
                object
                        type      IRI
                        value     http://schema.org/Person
                ---
                subject
                        type      IRI
                        value     http://example.org/ld-experts
                predicate
                        type      IRI
                        value     http://schema.org/member
                object
                        type      blank node
                        value     _:c14n0
                ---
                subject
                        type      IRI
                        value     http://example.org/ld-experts
                predicate
                        type      IRI
                        value     http://schema.org/name
                object
                        type      literal
                        value     LD Experts
                        datatype  http://www.w3.org/2001/XMLSchema#string
                ---

            */
        }
    }
}