namespace JobSearchingWebApp.Helper
{
    public enum Vještine
    {
        _Time_Management,
        _Communication_Skills,
        _Problem_Solving,
        _Adaptability,
        _Collaboration,
        _Leadership,
        _Critical_Thinking,
        _Creativity,
        _Teamwork,
        _Decision_Making,
        _Attention_to_Detail,
        _Project_Management,
        _Emotional_Intelligence,
        _Stress_Management,
        _Empathy,
        _Active_Listening,
        _Negotiation,
        _Networking,
        _Mentoring,
        _Analytical_Skills,
        _Organizational_Skills,
        _Delegation,
        _Persuasion,
        _Integrity,
        _Open_Mindedness,
        _Relationship_Building,
        _Resilience,
        _Interpersonal_Skills,
        _Reliability,
        _Public_Speaking,
        _Diplomacy,
        _Coaching,
        _Conflict_Management,
        _Self_Discipline,
        _Patience,
        _Cultural_Awareness,
        _Positive_Attitude,
        _Persuasive_Writing,
        _Decision_Making_Under_Pressure,
        _Work_Ethic
    }

    public static class VještineExtensions
    {
        public static string ToDisplayString(this Vještine range)
        {
            return range switch
            {
                Vještine._Time_Management => "Time Management",
                Vještine._Communication_Skills => "Communication Skills",
                Vještine._Problem_Solving => "Problem Solving",
                Vještine._Adaptability => "Adaptability",
                Vještine._Collaboration => "Collaboration",
                Vještine._Leadership => "Leadership",
                Vještine._Critical_Thinking => "Critical Thinking",
                Vještine._Creativity => "Creativity",
                Vještine._Teamwork => "Teamwork",
                Vještine._Decision_Making => "Decision Making",
                Vještine._Attention_to_Detail => "Attention to Detail",
                Vještine._Project_Management => "Project Management",
                Vještine._Emotional_Intelligence => "Emotional Intelligence",
                Vještine._Stress_Management => "Stress Management",
                Vještine._Empathy => "Empathy",
                Vještine._Active_Listening => "Active Listening",
                Vještine._Negotiation => "Negotiation",
                Vještine._Networking => "Networking",
                Vještine._Mentoring => "Mentoring",
                Vještine._Analytical_Skills => "Analytical Skills",
                Vještine._Organizational_Skills => "Organizational Skills",
                Vještine._Delegation => "Delegation",
                Vještine._Persuasion => "Persuasion",
                Vještine._Integrity => "Integrity",
                Vještine._Open_Mindedness => "Open-Mindedness",
                Vještine._Relationship_Building => "Relationship Building",
                Vještine._Resilience => "Resilience",
                Vještine._Interpersonal_Skills => "Interpersonal Skills",
                Vještine._Reliability => "Reliability",
                Vještine._Public_Speaking => "Public Speaking",
                Vještine._Diplomacy => "Diplomacy",
                Vještine._Coaching => "Coaching",
                Vještine._Conflict_Management => "Conflict Management",
                Vještine._Self_Discipline => "Self Discipline",
                Vještine._Patience => "Patience",
                Vještine._Cultural_Awareness => "Cultural Awareness",
                Vještine._Positive_Attitude => "Positive Attitude",
                Vještine._Persuasive_Writing => "Persuasive Writing",
                Vještine._Decision_Making_Under_Pressure => "Decision Making Under Pressure",
                Vještine._Work_Ethic => "Work Ethic",
                _ => "Unknown",
            };
        }

        public static List<string> GetAllVještine()
        {
            return Enum.GetValues(typeof(Vještine))
                       .Cast<Vještine>()
                       .Select(e => e.ToDisplayString())
                       .ToList();
        }
    }
}
