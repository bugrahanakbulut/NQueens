namespace NQueens.Utils
{
    public static class ArrayExtensions
    {
        public static void Fill<T>(this T[] arr, T val)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = val;
            }
        }
    }
}