using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Security;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic; 

class Journal
{
    private List<Entry> entries = new List<Entry>();
    private List<string> prompts = new List<string>();
    private bool activeState;

    public Journal(List<string> prompts)
    {
        activeState = true;
        foreach(var prompt in prompts)
        {
            this.prompts.Add(prompt);
        }
    }
    public Journal(string prompt)
    {
        activeState = true;
        prompts.Add(prompt);
    }

    public string GetPrompt()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        return prompt;
    }

    public string GetResponse()
    {
        string response = Console.ReadLine();
        return response;
    }
    public string GetDate()
    {
        DateTime currentDate = DateTime.Now;
        string date = currentDate.ToShortDateString();
        return date;
    }
    public void SaveEntryToList(string date, string prompt, string response)
    {
        Entry newEntry = new Entry(date, prompt, response);
        entries.Add(newEntry); 
    }
    public void WriteEntry()
    {
        string prompt = GetPrompt();
        string date = GetDate();
        Console.WriteLine($"{date}: {prompt}");
        string response = GetResponse();
        SaveEntryToList(date, prompt, response);
    }
    public void DisplayEntries()
    {
        Console.WriteLine("Displaying Entries:");
        foreach(Entry entry in entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void AddPrompt(string prompt)
    {
        prompts.Add(prompt);
    }
    public void AddPrompt(List<string> prompts)
    {
        foreach(string prompt in prompts)
        {
            this.prompts.Add(prompt);
        }
    }
    public List<string> GetPrompts()
    {
        return prompts;
    }
    public void DisplayPrompts()
    {
        foreach(string prompt in prompts)
        {
            Console.Write($"{prompt} ");
        }
        Console.WriteLine("");
    }
    public void SetActiveState(bool state)
    {
        activeState = state;
    }
    public bool GetActiveState()
    {
        return activeState;
    }

    public string GetFileName()
    {
        string fileName = Console.ReadLine();
        return fileName;
    }
    public void SaveFile()
    {
        Console.Write("Please input a file name: ");
        string filename = GetFileName();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach(Entry entry in entries)
            {
                outputFile.WriteLine($"Entry|{entry.GetEntryForFile()}");
            }
            foreach(string prompt in prompts)
            {
                outputFile.WriteLine($"Prompt|{prompt}");
            }
        }
    }

    public void SavePrompts()
    {
        Console.Write("Please input a file name: ");
        string filename = GetFileName();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach(string prompt in prompts)
            {
                outputFile.WriteLine(prompt);
            }
        }
    }


    public void ReadFile()
    {
        Console.Write("Please input a file name: ");
        string filename = GetFileName();
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach(string line in lines)
        {
            string[] lineParts = line.Split("|");
            string header = lineParts[0];
            if(header == "Prompt")
            {
                string prompt = lineParts[1];
                if(!prompts.Contains(prompt))
                {   
                prompts.Add(prompt);
                }
            }
            else if(header == "Entry")
            {
                string date = lineParts[1];
                string prompt = lineParts[2];
                string response = lineParts[3];
                SaveEntryToList(date,prompt,response);
            }
        }
    }

    public void ReadPrompts()
    {
        Console.Write("Please input a file name: ");
        string filename = GetFileName();
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach(string line in lines)
        {
            string prompt = line;
            if(!prompts.Contains(prompt))
            {
                prompts.Add(prompt);
            }
        }
    }


    public void DisplayMenu()
    {
        Console.WriteLine($"1. Write \n2. Add Prompt\n3. Display Prompts\n4. Display Entries\n5. Save to file\n6. Load from file\n7. Save prompts to file\n8. Load prompts from file\n9. Quit");
    }
    public void ProcessMenu()
    {
        string input = Console.ReadLine();
        int response = 0;
        List<string> inputList = new List<string> {"write", "add prompt", "display prompts", "display entries", "save to file", "load from file", "save prompts to file", "load prompts from file", "quit"};

        if(input.All(char.IsDigit))
        {
            response = int.Parse(input);
        }
        else if(inputList.Contains(input.ToLower()))
        {
            response = inputList.IndexOf(input.ToLower()) + 1;
        }

        switch(response)
        {
            case 0:
                Console.WriteLine("Invalid response, try again");
                break;
            case 1:
                WriteEntry();
                break;
            case 2:
                Console.Write("Please input the new prompt: ");
                string promptToAdd = Console.ReadLine();
                AddPrompt(promptToAdd);
                break;
            case 3:
                DisplayPrompts();
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                break;
            case 4:
                DisplayEntries();
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                break;
            case 5:
                SaveFile();
                break;
            case 6:
                ReadFile();
                break;
            case 7:
                SavePrompts();
                break;
            case 8:
                ReadPrompts();
                break;
            case 9:
                SetActiveState(false);
                Console.WriteLine("Quitting.");
                break;

        }

        // if(input.ToLower() == "write" || int.Parse(input)==1)
        // {
        //     WriteEntry();
        // }
        // if(input.ToLower() == "add prompt" || int.Parse(input)==2)
        // {
        //     Console.Write("Please input the new prompt: ");
        //     string promptToAdd = Console.ReadLine();
        //     AddPrompt(promptToAdd);
        // }
        // if(input.ToLower() == "display prompts" || int.Parse(input)==3)
        // {
        //     DisplayPrompts();
        // }
        // if(input.ToLower() == "display entries" || int.Parse(input)==4)
        // {
        //     DisplayEntries();
            
        // }
        // if(input.ToLower() == "save to file" || int.Parse(input)==5)
        // {
        //     SaveFile();
        // }
        // if(input.ToLower() == "load from file" || int.Parse(input)==6)
        // {
        //     ReadFile();
        // }
        // if(input.ToLower() == "save prompts to file" || int.Parse(input)==7)
        // {
        //     SavePrompts();
        // }
        // if(input.ToLower() == "load prompts from file" || int.Parse(input)==8)
        // {
        //     ReadPrompts();
        // }
        // if(input.ToLower() == "quit" || int.Parse(input)==9)
        // {
        //     SetActiveState(false);
        //     Console.WriteLine("Quitting.");
        // }
        // else
        // {
        //     Console.WriteLine("Press enter to continue");
        //     Console.ReadLine();
        // }

        
    }
}