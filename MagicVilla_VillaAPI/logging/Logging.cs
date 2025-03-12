namespace MagicVilla_VillaAPI.logging
{
    public class Logging: ILogging
    {
        public void Log(string message, string Type)
        {
            if (Type == "Error")
            {
                Console.WriteLine("Error: " + message);
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
