namespace JobSearchingWebApp.Helper
{
    public enum StatusPrijave
    {
        _No_status,
        _Accepted,
        _Rejected,
        _Disqualified,
        _Shortlisted
    }

    public static class StatusPrijaveExtensions
    {
        public static string ToDisplayString(this StatusPrijave range)
        {
            return range switch
            {
                StatusPrijave._No_status => "No status",
                StatusPrijave._Accepted => "Accepted",
                StatusPrijave._Rejected => "Rejected",
                StatusPrijave._Disqualified => "Disqualified",
                StatusPrijave._Shortlisted => "Shortlisted",
                _ => "Unknown",
            };
        }

        public static List<string> GetAllStatusPrijave()
        {
            return Enum.GetValues(typeof(StatusPrijave))
                       .Cast<StatusPrijave>()
                       .Select(e => e.ToDisplayString())
                       .ToList();
        }
    }
}
