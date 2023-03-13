namespace EventsAndDelegatesEx3;

public class Helper
{
    public static void ProbabilisticForEach()
    {
        List<Action> actions = new List<Action>();
        for (int i = 0; i < 3; i++)
        {
            actions.Add(() => Console.WriteLine(i)); //lambda functions, each print its number
        }

        //Console.WriteLine(actions.Count());
        Random random = new Random();
        int randInt = random.Next(0, actions.Count);
        Console.WriteLine(randInt);
        actions[randInt](); //randomly choose one of the lambda functions to run
    }
}