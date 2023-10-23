using FluentValidation;

namespace ProgrammingInternshipPlatform.Domain.Shared.Validators;

public static class DomainCustomRules
{
    public static IRuleBuilderOptions<T, IReadOnlyList<TItem>> HasAtLeastOneItem<T, TItem>(
        this IRuleBuilder<T, IReadOnlyList<TItem>> ruleBuilder)
    {
        return ruleBuilder.Must(collection => collection.Any());
    }
}