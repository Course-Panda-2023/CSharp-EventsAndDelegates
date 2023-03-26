using System.Threading.Tasks;

namespace ParallelForEach
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<float> numlist = new List<float>() { 1, 2, 3, 4, 5};
            List<float> parallelList = GenerateParallelList(numlist);
            PrintList(parallelList);
        }

        public static List<float> GenerateParallelList(List<float> collection)
        {
            List<float> NewList = new List<float>();
            Parallel.ForEach(collection, item =>
            {
                // Do some operation on the item
                NewList.Add(item*2);
            });
            return NewList;
        }

        private static void PrintList(List<float> problist)
        {
            foreach (var item in problist)
            {
                Console.WriteLine(item);
            }
        }
    }
}