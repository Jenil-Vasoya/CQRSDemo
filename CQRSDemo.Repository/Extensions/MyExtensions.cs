using CQRSDemo.Repository.DTOs;

namespace CQRSDemo.Extensions
{
    public static class MyExtensions
    {
        public async static Task<float> CustomDivideAsync(this float dividend, float divisor)
        {
            return await Task.Run(() => dividend / divisor);
        }

        public static async Task<IEnumerable<T>> Pagination<T>(this IEnumerable<T> collection, Paging paging)
        {
            return await Task.Run(() => collection.Skip((paging.Page - 1) * paging.PageSize).Take(paging.PageSize));
        }   
    }
}
