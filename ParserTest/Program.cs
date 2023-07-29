using DLCF_Parser;

string filePath = "C:\\Users\\janpi\\Desktop\\test.dlfc";
Parser parser = new Parser();

try
{
    Console.WriteLine("Starting DLFC parsing...");
    IDictionary<string, string> dlfcData = parser.ParseFile(filePath);
    

    // Access the parsed data
    foreach (KeyValuePair<string, string> kvp in dlfcData)
    {
        Console.WriteLine("{0} : {1}", kvp.Key, kvp.Value);
    }

    // Continue accessing other key-value pairs as needed
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"File not found: {ex.Message}");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Invalid DLFC file: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
