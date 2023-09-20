using ProgrammingInternshipPlatform.Application.InternshipHub.Responses;

namespace ProgrammingInternshipPlatform.Api.InternshipHub.Contracts.Responses;

public class MentorshipPair
{
    private MentorshipPair(Guid mentorshipPairId, Member trainer, Member intern)
    {
        MentorshipPairId = mentorshipPairId;
        Trainer = trainer;
        Intern = intern;
    }
    public Guid MentorshipPairId { get; }
    public Member Trainer { get; }
    public Member Intern { get; }

    public static MentorshipPair CreateFromResult(MentorshipResponse mentorshipPairResponse)
    {
        var trainer = Member.MapFrom(mentorshipPairResponse.Trainer);
        var intern = Member.MapFrom(mentorshipPairResponse.Intern);
        var mentorshipPairId = mentorshipPairResponse.MentorshipId;

        return new MentorshipPair(mentorshipPairId, trainer, intern);
    }
}