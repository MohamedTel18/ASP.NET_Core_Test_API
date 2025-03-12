namespace MagicVilla_VillaAPI.logging
{
    public class LogginV2 : ILogging
    {
        
        public void Log(string message, string Type)
        {
            if (Type == "Error")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + message);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (Type == "Info")
            {
                Console.WriteLine("Info: " + message);
            }
            else if (Type == "Warning")
            {
                Console.WriteLine("Warning: " + message);
            }
            else
            {
                Console.WriteLine("Unknown Type: " + message);
            }
        }
        
    }
}