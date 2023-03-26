namespace ProbalisticForEach
{
    internal class Program
    {
        private delegate float NumFunc(float num);
        private static void Main(string[] args)
        {
            float[] numlist = { 1, 2, 3, 4, 5 };
            NumFunc[] funcs = new NumFunc[]
            {
                Func1,
                Func2,
                Func3,
                Func4,
                Func5
            };
            List<float> problist = GenerateProbalisticList(numlist, funcs);
            Console.WriteLine("probalistic list: ");
            PrintList(problist);
        }
        private static void PrintList(List<float> problist)
        {
            foreach (var item in problist)
            {
                Console.WriteLine(item);
            }
        }
        private static List<float> GenerateProbalisticList(float[] numlist, NumFunc[] funcs)
        {
            Random rand = new Random();
            int numindex, funcindex;
            List<float> newList = new List<float>();
            foreach (float num in numlist)
            {
                numindex = rand.Next(numlist.Length);
                funcindex = rand.Next(funcs.Length);
                newList.Add(funcs[funcindex](num));
            }
            return newList;
        }
        static float Func1(float x) { return x + 1; }
        static float Func2(float x) { return x * 2; }
        static float Func3(float x) { return x + 10; }
        static float Func4(float x) { return x / 10; }
        static float Func5(float x) { return x - 10; }
    }
}