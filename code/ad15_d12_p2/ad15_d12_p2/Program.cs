// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

string json = File.ReadAllText(@"..\..\..\..\..\..\txt\day12.txt");

dynamic obj = JsonConvert.DeserializeObject(json);



