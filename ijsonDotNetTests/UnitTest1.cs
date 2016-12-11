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
        [TestMethod]
        public void ParseJsonEvents()
        {
            var ijson = new ijsonParser();
            using (var f = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(json2))))
            //using (var f = new StreamReader(@"C:\Users\epilsits\Documents\src\modoffers\test.json"))
                foreach (var evt in ijson.Parse(f))
                    Console.WriteLine(string.Format("Prefix: {0}, Token: {1}, Value: {2}",
                        evt.Prefix, evt.Type, evt.Value));
        }

        [TestMethod]
        public void PrettyPrintJson()
        {
            var ijson = new ijsonParser();
            using (var f = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(json2))))
            //using (var f = new StreamReader(@"C:\Users\epilsits\Documents\src\modoffers\test.json"))
                Console.Write(ijson.Pretty(f));
        }

        [TestMethod]
        public void MinifyJson()
        {
            var ijson = new ijsonParser();
            using (var f = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(json2))))
            //using (var f = new StreamReader(@"C:\Users\epilsits\Documents\src\modoffers\test.json"))
                Console.Write(ijson.Minify(f));
        }

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

        public string json2 =
@"[
""JSON Test Pattern pass1"",
{""object with 1 member"":[""array with 1 element""]},
{},
[],
-42,
true,
false,
null,
{
""integer"": 1234567890,
""real"": -9876.543210,
""e"": 0.123456789e-12,
""E"": 1.234567890E+34,
"""":  23456789012E66,
""zero"": 0,
""one"": 1,
""space"": "" "",
""quote"": ""\"""",
""backslash"": ""\\"",
""controls"": ""\b\f\n\r\t"",
""slash"": ""/ & \/"",
""alpha"": ""abcdefghijklmnopqrstuvwyz"",
""ALPHA"": ""ABCDEFGHIJKLMNOPQRSTUVWYZ"",
""digit"": ""0123456789"",
""0123456789"": ""digit"",
""special"": ""`1~!@#$%^&*()_+-={':[,]}|;.</>?"",
""hex"": ""\u0123\u4567\u89AB\uCDEF\uabcd\uef4A"",
""true"": true,
""false"": false,
""null"": null,
""array"":[  ],
""object"":{  },
""address"": ""50 St. James Street"",
""url"": ""http://www.JSON.org/"",
""comment"": ""// /* <!-- --"",
""# -- --> */"": "" "",
"" s p a c e d "" :[1,2 , 3

,

4 , 5        ,          6           ,7        ],""compact"":[1,2,3,4,5,6,7],
""jsontext"": ""{\""object with 1 member\"":[\""array with 1 element\""]}"",
""quotes"": ""&#34; \u0022 %22 0x22 034 &#x22;"",
""\/\\\""\uCAFE\uBABE\uAB98\uFCDE\ubcda\uef4A\b\f\n\r\t`1~!@#$%^&*()_+-=[]{}|;:',./<>?""
: ""A key can be any string""
},
0.5 ,98.6
,
99.44
,

1066,
1e1,
0.1e1,
1e-1,
1e00,2e+00,2e-00
,""rosebud""]";
    }
}
