namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Abstractions;

public interface IDeepCloneable<TEntity>
{
    public Task<TEntity> Clone(CancellationToken cancellationToken);
}