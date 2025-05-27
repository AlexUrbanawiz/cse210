class Program
{
    static List<Tuple<string, string>> ConeCombinations(List<string> topFlavors, List<string> bottomFlavors)
    {
        //End result: a list of tuples that contains all the combinations of flavors.
        //Start at 0,0; then go through the bottom flavors, adding them to the tuple list, then increment topflavor index then repeat until end of list reached
        //Cant change the attributes, so must manipulate the list passed into recursion to make it work.
        List<Tuple<string, string>> flavorCombos = new List<Tuple<string, string>>();
        if(topFlavors.Count == 0)
        {
            return flavorCombos;
        }
        if(bottomFlavors.Count == 0)
        {
            return flavorCombos;
        }
        else
        {
            flavorCombos.Add(new Tuple<string, string>(topFlavors[0], bottomFlavors[bottomFlavors.Count-1]));
            List<string> newBottoms = bottomFlavors;
            flavorCombos.AddRange(ConeCombinations(topFlavors, bottomFlavors));
        }
        
    }

    static void Main(string[] args)
    {
        List<string> topFlavors = new List<string>(){"vanilla", "chocolate", "cherry_ripple"};
        List<string> bottomFlavors = new List<string>(){"lemon", "butterscotch", "licorice_riple"};

        List<Tuple<string, string>> short_combinations = new List<Tuple<string, string>>()
        {
            new Tuple<string, string>("vanilla","lemon"),
			new Tuple<string, string>("vanilla","butterscotch"),
			new Tuple<string, string>("vanilla","licorice_riple"),
			new Tuple<string, string>("chocolate","lemon"),
			new Tuple<string, string>("chocolate","butterscotch"),
			new Tuple<string, string>("chocolate","licorice_riple"),
			new Tuple<string, string>("cherry_ripple","lemon"),
			new Tuple<string, string>("cherry_ripple","butterscotch"),
			new Tuple<string, string>("cherry_ripple","licorice_riple")
        };

        List<Tuple<string, string>> combinations = new List<Tuple<string, string>>();
        for(int i = 0; i < topFlavors.Count; i++)
        {

            for(int j = 0; j < bottomFlavors.Count; j++)
            {
                combinations.Add(new Tuple<string, string>(topFlavors[i], bottomFlavors[j]));
                Console.WriteLine($"Combination {i+j}: {topFlavors[i]}, {bottomFlavors[j]}");
            }
        }

        if(short_combinations.Equals(combinations))
        {
            Console.WriteLine("Match made.");
        }
    }
}