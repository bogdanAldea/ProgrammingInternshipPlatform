namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Abstractions;

public interface IDeepCloneable<TEntity>
{
    public Task<TEntity> Clone(CancellationToken cancellationToken);
}