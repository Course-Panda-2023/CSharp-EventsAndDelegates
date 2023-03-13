using System.Threading;
using System.Threading.Tasks;

static void Mul(int num)
{
    Console.WriteLine($"Multiply output: {num} * {num} = {num * num}");
}

static void Add(int num)
{
    Console.WriteLine($"Addition output: {num} + {num} = {num + num}");
}

static void Sub(int num)
{
    Console.WriteLine($"Subtraction output: {num} - {num} = 0");
}

static void Div(int num)
{
    Console.WriteLine($"Division output: {num} / {num} = 1");
}


static void ProbFunctionRunner(List<int> nums, params probFunction[] funcs)
{
    Random rnd = new Random();

    Parallel.For(0, nums.Count(), i =>
    {
        int num = rnd.Next(funcs.Length);
        funcs[num](nums[i]);
    });
}

List<int> nums = new List<int>() { 1, 2, 3, 4, 5 };
ProbFunctionRunner(nums, Mul, Sub, Add, Div);

public delegate void probFunction(int num);