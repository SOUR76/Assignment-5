using System;
using System.IO;
class Program
{
    static void Main()
    {
        WriteToJournal();
    }
    static void WriteToJournal()
    {
        Console.WriteLine("Enter lines for Captain's journal. Type 'start' to begin and 'stop' to end.");
        string userInput;
        bool writingEnabled = false;
        var journalContent = new System.Text.StringBuilder();

        while ((userInput = Console.ReadLine()) != null)
        {
            if (userInput.ToLower() == "start")
            {
                writingEnabled = true;
                journalContent.Clear();
                continue;
            }
            if (userInput.ToLower() == "stop")
            {
                break;
            }
            if (writingEnabled)
            {
                journalContent.AppendLine(userInput);
            }
        }
        string currentDate = DateTime.Now.ToString("dd-MM-yyyy");
        string filename = $"{currentDate}.txt";
            using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("Captain's log");
            writer.WriteLine($"Stardate {currentDate}");
            writer.WriteLine(journalContent.ToString());
            writer.WriteLine("Jean-Luc Picard");
        }
            Console.WriteLine($"Journal saved to {filename}");
    }
}