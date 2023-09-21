namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Abstracts;

public interface IDeepCloneable<out TEntity>
{
    public TEntity Clone();
}