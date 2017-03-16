<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
</Query>

void Main()
{
   	JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
	{
		MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
		ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
		ContractResolver = new CamelCasePropertyNamesContractResolver()
	};
	TestClass testObject = new TestClass();
	string json = JsonConvert.SerializeObject(testObject, jsonSerializerSettings);
	json.Dump();
}

// Define other methods and classes here
public class TestClass
{
	public string[] InternalKeywords = new string[] { "seo", "Test"};
}