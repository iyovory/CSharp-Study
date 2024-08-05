namespace Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = 10;
            double b = 20;

            Util.Swap(ref a, ref b);

            Console.WriteLine($"a={a} b={b}");
        }
    }

    public static class Util
    {
        public static void Swap<T>(ref T left, ref T right)
        {
            T temp = left;
            left = right;
            right = temp;
        }
    }
}
