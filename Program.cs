namespace JsonLD.Demo
{
    internal class Program
    {
        private static void Main()
        {
            Sample0_Installation.Run();
            Sample1_Compact.Run();
            Sample2_Expand.Run();
            Sample3_Flatten.Run();
            Sample4_Frame.Run();
            Sample5_Normalize.Run();
            Sample6_ToRDF.Run();
            Sample7_FromRDF.Run();
            Sample8_CustomRDFRender.Run();
            Sample9_CustomRDFParser.Run();
            SampleA_RemoteDocumentLoader.Run();
        }
    }
}
