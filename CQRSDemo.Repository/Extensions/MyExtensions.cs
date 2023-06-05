namespace CQRSDemo.Extensions
{
    public static class MyExtensions
    {
        public async static Task<float> CustomDivideAsync(this float dividend, float divisor)
        {
            return await Task.Run(() => dividend / divisor);
        }

        public static async Task<IEnumerable<T>> Pagination<T>(this IEnumerable<T> collection, int page, int pageSize)
        {
            return await Task.Run(() => collection.Skip((page - 1) * pageSize).Take(pageSize));
        }
    }
}
