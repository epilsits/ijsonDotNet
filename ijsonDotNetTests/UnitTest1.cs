using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using ijsonDotNet;

namespace ijsonDotNetTests
{
    [TestClass]
    public class UnitTest1
    {
        public string json1 =
@"{
""key1"": ""value 1"",
""key2"": 100,
""key 3"": null,
""key 4"": true,
""array 1"": [1, 2, 3, 4, 5],
""obj1"": {
""inner 1"": false,
""inner 2"": [[], {}, ""inner STRING""]
}
}";

        [TestMethod]
        public void ParseJsonEvents()
        {
            var ijson = new ijsonParser();
            //using (var f = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(json1))))
            using (var f = new StreamReader(@"C:\Users\epilsits\Documents\src\modoffers\test.json"))
                foreach (var evt in ijson.Parse(f))
                    Console.WriteLine(string.Format("Prefix: {0}, Token: {1}, Value: {2}",
                        evt.Prefix, evt.Type, evt.Value));
        }

        [TestMethod]
        public void PrettyPrintJson()
        {
            var ijson = new ijsonParser();
            //using (var f = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(json1))))
            using (var f = new StreamReader(@"C:\Users\epilsits\Documents\src\modoffers\test.json"))
                Console.Write(ijson.Pretty(f));
        }

        [TestMethod]
        public void MinifyJson()
        {
            var ijson = new ijsonParser();
            //using (var f = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(json1))))
            using (var f = new StreamReader(@"C:\Users\epilsits\Documents\src\modoffers\test.json"))
                Console.Write(ijson.Minify(f));
        }
    }
}
