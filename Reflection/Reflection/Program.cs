using Reflection.Configuration;

var configuration = new MyConfiguration();

// Load settings
configuration.LoadSettings();

// Use the settings
Console.WriteLine($"MyIntSetting: {configuration.MyIntSetting}");
Console.WriteLine($"MyFloatSetting: {configuration.MyFloatSetting}");
Console.WriteLine($"MyStringSetting: {configuration.MyStringSetting}");
Console.WriteLine($"MyTimeSpanSetting: {configuration.MyTimeSpanSetting}");

// Modify the settings
configuration.MyIntSetting = 42;
configuration.MyFloatSetting = 3.14f;
configuration.MyStringSetting = "Hello, world!";
configuration.MyTimeSpanSetting = TimeSpan.FromHours(2);

// Save the modified settings
configuration.SaveSettings();

Console.WriteLine("Settings saved.");

// Wait for user input to exit
Console.ReadLine();