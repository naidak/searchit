namespace JobSearchingWebApp.Helper
{

    public enum TehničkeVještine
    {
        _CPlusPlus,
        _CSharp,
        _Python,
        _Java,
        _JavaScript,
        _HTML,
        _CSS,
        _SQL,
        _TypeScript,
        _PHP,
        _Ruby,
        _Swift,
        _Go,
        _R,
        _Scala,
        _Kotlin,
        _Rust,
        _Dart,
        _Bash,
        _Perl,
        _Assembly,
        _PowerShell,
        _Objective_C,
        _GraphQL,
        _NoSQL,
        _Linux,
        _Docker,
        _Kubernetes,
        _AWS,
        _Azure,
        _Google_Cloud,
        _Terraform,
        _Ansible,
        _Chef,
        _Puppet,
        _Jenkins,
        _Git,
        _GitHub,
        _GitLab,
        _MongoDB,
        _PostgreSQL,
        _MySQL,
        _SQLite,
        _Redis,
        _Elasticsearch,
        _Flutter,
        _React,
        _Angular,
        _NodeJS,
        _Django,
        _Spring_Boot
    }

    public static class TehničkeVještineExtensions
    {
        public static string ToDisplayString(this TehničkeVještine range)
        {
            return range switch
            {
                TehničkeVještine._CPlusPlus => "C++",
                TehničkeVještine._CSharp => "C#",
                TehničkeVještine._Python => "Python",
                TehničkeVještine._Java => "Java",
                TehničkeVještine._JavaScript => "JavaScript",
                TehničkeVještine._HTML => "HTML",
                TehničkeVještine._CSS => "CSS",
                TehničkeVještine._SQL => "SQL",
                TehničkeVještine._TypeScript => "TypeScript",
                TehničkeVještine._PHP => "PHP",
                TehničkeVještine._Ruby => "Ruby",
                TehničkeVještine._Swift => "Swift",
                TehničkeVještine._Go => "Go",
                TehničkeVještine._R => "R",
                TehničkeVještine._Scala => "Scala",
                TehničkeVještine._Kotlin => "Kotlin",
                TehničkeVještine._Rust => "Rust",
                TehničkeVještine._Dart => "Dart",
                TehničkeVještine._Bash => "Bash",
                TehničkeVještine._Perl => "Perl",
                TehničkeVještine._Assembly => "Assembly",
                TehničkeVještine._PowerShell => "PowerShell",
                TehničkeVještine._Objective_C => "Objective-C",
                TehničkeVještine._GraphQL => "GraphQL",
                TehničkeVještine._NoSQL => "NoSQL",
                TehničkeVještine._Linux => "Linux",
                TehničkeVještine._Docker => "Docker",
                TehničkeVještine._Kubernetes => "Kubernetes",
                TehničkeVještine._AWS => "AWS",
                TehničkeVještine._Azure => "Azure",
                TehničkeVještine._Google_Cloud => "Google Cloud",
                TehničkeVještine._Terraform => "Terraform",
                TehničkeVještine._Ansible => "Ansible",
                TehničkeVještine._Chef => "Chef",
                TehničkeVještine._Puppet => "Puppet",
                TehničkeVještine._Jenkins => "Jenkins",
                TehničkeVještine._Git => "Git",
                TehničkeVještine._GitHub => "GitHub",
                TehničkeVještine._GitLab => "GitLab",
                TehničkeVještine._MongoDB => "MongoDB",
                TehničkeVještine._PostgreSQL => "PostgreSQL",
                TehničkeVještine._MySQL => "MySQL",
                TehničkeVještine._SQLite => "SQLite",
                TehničkeVještine._Redis => "Redis",
                TehničkeVještine._Elasticsearch => "Elasticsearch",
                TehničkeVještine._Flutter => "Flutter",
                TehničkeVještine._React => "React",
                TehničkeVještine._Angular => "Angular",
                TehničkeVještine._NodeJS => "Node.js",
                TehničkeVještine._Django => "Django",
                TehničkeVještine._Spring_Boot => "Spring Boot",
                _ => "Unknown",
            };
        }

        public static List<string> GetAllTehničkeVještine()
        {
            return Enum.GetValues(typeof(TehničkeVještine))
                       .Cast<TehničkeVještine>()
                       .Select(e => e.ToDisplayString())
                       .ToList();
        }
    }
}
