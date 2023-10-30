using ProgrammingInternshipPlatform.Domain.AccountManagement.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;
using ProgrammingInternshipPlatform.Domain.Shared.DomainEventHandling;

namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Events;

public class TopicVersionedEvent : DomainEvent
{
    public TopicId VersionedTopicId { get; set; }
    public AccountId VersionedByUser { get; set; }
}