using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SciQuery.Service.Pagination.PaginatedList;

namespace SciQuery.Service.Mappings.Extensions;

public static class QueryableExtensions
{
    public async static Task<PaginatedList<T>> ToPaginatedList<T, K>(
        this IQueryable<K> query,
        IConfigurationProvider configurationProvider,
        int pageNumber = 1,
        int pageSize = 15)
    {
        var count = await query.CountAsync();
        var data = await query
            .Skip((pageNumber-1) * pageSize)
            .Take(pageSize)
            .ProjectTo<T>(configurationProvider)
            .ToListAsync();

        return new PaginatedList<T>(data,pageNumber,pageSize,count);
    }
}
