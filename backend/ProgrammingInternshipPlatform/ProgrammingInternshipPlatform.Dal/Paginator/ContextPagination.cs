namespace ProgrammingInternshipPlatform.Dal.Paginator;

public class Pagination<TEntity>
{
    private readonly List<TEntity> _results = new();
    public int TotalItems { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public IReadOnlyList<TEntity> Results => _results;

    public static Pagination<TEntity> Create(int currentPage, int itemsPerPage, int totalResults, List<TEntity> results)
    {

        var pagination =  new Pagination<TEntity>
        {
            CurrentPage = currentPage,
            TotalPages = Convert.ToInt16(Math.Ceiling((double)totalResults / itemsPerPage)),
            TotalItems = totalResults
        };
        pagination._results.AddRange(results);
        return pagination;
    }
}

public static class ContextPagination
{
    public static Pagination<TEntity> Paginate<TEntity>(IReadOnlyList<TEntity> queryable, int page, int itemsPerPage)
    {
        var rowsToBeSkipped = CountRowsToSkip(page, itemsPerPage);
        var totalItems = CountTotalItems(queryable);
        var results = GenerateResults(queryable, rowsToBeSkipped, itemsPerPage);

        var paginated = Paginator.Pagination<TEntity>
            .Create(currentPage: 1, itemsPerPage: itemsPerPage, totalResults: totalItems, results: results);
        
        return paginated;
    }

    public static IQueryable<TEntity> Pagination<TEntity>(this IQueryable<TEntity> queryable, int page,
        int itemsPerPage)
    {
        var rowsToBeSkipped = itemsPerPage * page - itemsPerPage;

        var results = queryable
            .Skip(rowsToBeSkipped)
            .Take(itemsPerPage);

        return results;
    }

    private static int CountRowsToSkip(int page, int itemsPerPage)
        => itemsPerPage * page - itemsPerPage;

    private static int CountTotalItems<TEntity>(IReadOnlyList<TEntity> queryable)
        => queryable.Count();
    
    private static List<TEntity> GenerateResults<TEntity>(IReadOnlyList<TEntity> queryable, int rowsToBeSkipped, int itemsPerPage)
        => queryable
            .Skip(rowsToBeSkipped)
            .Take(itemsPerPage)
            .ToList();
}