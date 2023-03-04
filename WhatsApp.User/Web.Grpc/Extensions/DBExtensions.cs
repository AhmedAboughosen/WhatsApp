using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Model;
using Core.Domain.Model.DTO.ResponseDto;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;

namespace Web.Grpc.Extensions
{
    public static class DBExtensions
    {
    
        public static async Task<PaginatedListModel<T>> CreateAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedListModel<T>(items, count, pageIndex, pageSize);
        }
    }
}