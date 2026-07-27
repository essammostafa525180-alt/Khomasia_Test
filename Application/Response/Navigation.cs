using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Response
{
    public class Navigation<T>
    {
        public int? PreviousId { get; set; }
        public int? NextId { get; set; }
        public T Data { get; set; } = default!;

        public static async Task<Navigation<T>> CreateAsync<TId>(
            IQueryable<T> source,
            TId currentId,
            Expression<Func<T, TId>> idSelector,
            CancellationToken cancellationToken = default)
            where TId : IComparable<TId>
        {
            // Previous
            var previousId = await source
                .Where(x => EF.Property<TId>(x, ((MemberExpression)idSelector.Body).Member.Name).CompareTo(currentId) < 0)
                .OrderByDescending(idSelector)
                .Select(idSelector)
                .FirstOrDefaultAsync(cancellationToken);

            // Next
            var nextId = await source
                .Where(x => EF.Property<TId>(x, ((MemberExpression)idSelector.Body).Member.Name).CompareTo(currentId) > 0)
                .OrderBy(idSelector)
                .Select(idSelector)
                .FirstOrDefaultAsync(cancellationToken);

            // Current
            var currentData = await source
                .FirstOrDefaultAsync(x => EF.Property<TId>(x, ((MemberExpression)idSelector.Body).Member.Name).CompareTo(currentId) == 0,
                    cancellationToken);

            if (currentData == null)
                throw new Exception("Item not found");

            return new Navigation<T>
            {
                PreviousId = previousId == null || previousId.Equals(default(TId)) ? null : Convert.ToInt32(previousId),
                NextId = nextId == null || nextId.Equals(default(TId)) ? null : Convert.ToInt32(nextId),
                Data = currentData
            };
        }
    }
}