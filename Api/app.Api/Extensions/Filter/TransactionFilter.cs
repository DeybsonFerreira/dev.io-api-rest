using app.Data.Context;
using Microsoft.AspNetCore.Mvc.Filters;

namespace app.Api.Extensions.Filter
{
    public class TransactionFilter : IActionFilter
    {
        public ApiDbContext _apiDbContext;
        public TransactionFilter(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _apiDbContext.SaveChanges();
            _apiDbContext.Database.CommitTransaction();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _apiDbContext.Database.BeginTransactionAsync();
        }
    }
}
