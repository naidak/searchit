using Azure.Core;
using JobSearchingWebApp.Data;
using JobSearchingWebApp.Helper;

using JobSearchingWebApp.Database;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;

namespace JobSearchingWebApp.Endpoints.GeneratorPodataka
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GenerisiPodatkeEndpoint : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Database.Korisnik> userManager;

        public GenerisiPodatkeEndpoint(ApplicationDbContext dbContext, UserManager<Database.Korisnik> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager; 
        }

        [HttpPost]
        public async Task<ActionResult> Generisi()
        {
            var oglasi = new List<Database.Oglas>();
            var iskustvo = new List<Database.Iskustvo>();
            var lokacija = new List<Database.Lokacija>();
            var oglasIskustvo = new List<Database.OglasIskustvo>();
            var oglasLokacija = new List<Database.OglasLokacija>();
            var opisOglas = new List<Database.OpisOglas>();


            //lokacije
            lokacija.Add(new Database.Lokacija { Naziv = "Sarajevo" });
            lokacija.Add(new Database.Lokacija { Naziv = "Mostar" });
            lokacija.Add(new Database.Lokacija { Naziv = "Jablanica" });
            lokacija.Add(new Database.Lokacija { Naziv = "Remote" });

            dbContext.Add(lokacija);
            //lokacije


            //iskustvo
            iskustvo.Add(new Database.Iskustvo { Naziv = "Junior" });
            iskustvo.Add(new Database.Iskustvo { Naziv = "Medior" });
            iskustvo.Add(new Database.Iskustvo { Naziv = "Senior" });
            
            dbContext.Add(iskustvo);
            //iskustvo

            //oglasi
            //oglasi.Add(new Models.Oglas { NazivPozicije = "Software Engineer", DatumObjave = DateTime.Now, Plata = 2000, TipPosla = "Full Time", RokPrijave = DateTime.MaxValue, KompanijaId = 1 });
            //oglasi.Add(new Models.Oglas { NazivPozicije = "DevOps Engineer", DatumObjave = DateTime.Now, Plata = 3400, TipPosla = "Full Time", RokPrijave = DateTime.MaxValue, KompanijaId =  1});
            //oglasi.Add(new Models.Oglas { NazivPozicije = "QA Engineer", DatumObjave = DateTime.Now, Plata = 2500, TipPosla = "Full Time", RokPrijave = DateTime.MaxValue, KompanijaId = 1});
            //oglasi.Add(new Models.Oglas { NazivPozicije = "Software Engineer", DatumObjave = DateTime.Now, Plata = 2300, TipPosla = "Full Time", RokPrijave = DateTime.MaxValue, KompanijaId =1  });
            //oglasi.Add(new Models.Oglas { NazivPozicije = "ML Engineer", DatumObjave = DateTime.Now, Plata = 4000, TipPosla = "Full Time", RokPrijave = DateTime.MaxValue, KompanijaId = 1 });
            //oglasi.Add(new Models.Oglas { NazivPozicije = "UI/UX Designer", DatumObjave = DateTime.Now, Plata = 1000, TipPosla = "Part Time", RokPrijave = DateTime.MaxValue, KompanijaId = 1 });
            //oglasi.Add(new Models.Oglas { NazivPozicije = "Backend Developer", DatumObjave = DateTime.Now, Plata = 2600, TipPosla = "Full Time", RokPrijave = DateTime.MaxValue, KompanijaId = 1 });
            //oglasi.Add(new Models.Oglas { NazivPozicije = "Frontend Developer", DatumObjave = DateTime.Now, Plata = 2300, TipPosla = "Full Time", RokPrijave = DateTime.MaxValue, KompanijaId = 1 });
            //oglasi.Add(new Models.Oglas { NazivPozicije = "Graphical Designer", DatumObjave = DateTime.Now, Plata = 1800, TipPosla = "Part Time", RokPrijave = DateTime.MaxValue, KompanijaId = 1 });

            //oglasi

            //opisOglas.Add(
            //    new Models.OpisOglas 
            //    { OpisPozicije = "We are seeking a highly skilled and motivated Software Engineer to join our talented team. " +
            //    "The ideal candidate is passionate about technology, possesses strong problem-solving skills, and thrives in a fast-paced, collaborative environment. " +
            //    "As a Software Engineer at ByteMatrix Solutions, you will have the opportunity to work on exciting projects, contribute to groundbreaking solutions, " +
            //    "and make a significant impact on the future of ByteMatrix Solutions.", 
            //     MinimumGodinaIskustva = 1, 
            //     PrefiraneGodineIskstva = 3, 
            //     Kvalifikacija = "Bachelor's degree in Computer Science, Engineering, or a related field (Master's degree preferred)\r\nProven experience in " +
            //     "software development, including proficiency in one or more programming languages (e.g., Java, Python, C++)\r\nStrong understanding of data " +
            //     "structures, algorithms, and object-oriented design principles\r\nExperience with web development frameworks (e.g., React, Angular, Vue.js) " +
            //     "and/or backend technologies (e.g., Node.js, Django, Spring Boot)\r\nFamiliarity with database systems (e.g., SQL, NoSQL) and cloud platforms " +
            //     "(e.g., AWS, Azure, Google Cloud Platform)\r\nExcellent communication skills and the ability to work effectively in a collaborative team " +
            //     "environment", 
            //     Vjestine = "Proficiency in Programming Languages: Strong coding skills in one or more programming languages such as Java, Python, C++, or " +
            //     "others depending on the technology stack used by the company.\r\n\r\nProblem-Solving: Ability to analyze complex problems, break them down " +
            //     "into manageable components, and develop effective solutions.\r\n\r\nSoftware Development: Experience in all phases of the software development " +
            //     "lifecycle (SDLC), including requirements analysis, design, development, testing, deployment, and maintenance.\r\n\r\nData Structures and " +
            //     "Algorithms: Solid understanding of fundamental data structures (e.g., arrays, linked lists, trees) and algorithms (e.g., sorting, searching," +
            //     " graph algorithms) to develop efficient and scalable software solutions.\r\n\r\nObject-Oriented Design Principles: " +
            //     "Familiarity with object-oriented programming (OOP) concepts such as inheritance, encapsulation, and polymorphism to create modular and " +
            //     "reusable code.", 
            //     Benefiti = "Competitive salary and comprehensive benefits package\r\nFlexible work schedule and remote work options\r\nOpportunities for " +
            //     "career growth and professional development\r\nDynamic and inclusive work culture with a focus on innovation and collaboration\r\nExciting " +
            //     "projects and the chance to work with cutting-edge technologies", 
            //     OglasId = 5});

            //opisOglas.Add(
            //new Models.OpisOglas
            //{
            //    OpisPozicije = "We are seeking an experienced and highly skilled Senior DevOps Engineer to join our dynamic team. As a Senior DevOps Engineer " +
            //    "at TechVista Dynamics, you will play a crucial role in designing, implementing, and managing our infrastructure and deployment pipelines to support " +
            //    "our growing portfolio of products and services. The ideal candidate is a strategic thinker, a problem-solver, and a hands-on technologist with a " +
            //    "passion for automation, scalability, and reliability.",
            //    MinimumGodinaIskustva = 3,
            //    PrefiraneGodineIskstva = 6,
            //    Kvalifikacija = "Bachelor's degree in Computer Science, Engineering, or a related field (Master's degree preferred).\r\n5+ years of experience " +
            //    "in DevOps or infrastructure engineering roles, with a proven track record of designing and implementing scalable, reliable, and secure " +
            //    "infrastructure solutions.\r\nStrong expertise in cloud computing platforms such as AWS, Azure, or GCP, including services like EC2, S3, IAM, VPC, " +
            //    "Azure DevOps, AKS, GKE, etc.\r\nProficiency in Infrastructure as Code (IaC) tools like Terraform, CloudFormation, or Ansible, and configuration " +
            //    "management tools like Puppet, Chef, or SaltStack.\r\nExperience building and managing CI/CD pipelines using tools like Jenkins, GitLab CI/CD, or " +
            //    "CircleCI, and version control systems like Git.\r\nHands-on experience with containerization technologies like Docker and container orchestration " +
            //    "platforms such as Kubernetes.\r\nStrong scripting skills (e.g., Bash, Python, PowerShell) for automation and infrastructure management tasks" +
            //    ".\r\nExcellent communication and collaboration skills, with the ability to work effectively in a cross-functional team environment.\r\nProven " +
            //    "ability to lead and mentor junior team members, share knowledge, and drive continuous improvement.",
            //    Vjestine = "Infrastructure as Code (IaC): Proficiency in IaC tools such as Terraform, CloudFormation, or Ansible to automate the provisioning, " +
            //    "configuration, and management of infrastructure resources.\r\n\r\nContinuous Integration/Continuous Deployment (CI/CD): Experience implementing " +
            //    "and managing CI/CD pipelines using tools like Jenkins, GitLab CI/CD, or CircleCI to automate software delivery processes and accelerate release " +
            //    "cycles.\r\n\r\nContainerization and Orchestration: Strong understanding of containerization technologies like Docker and container orchestration " +
            //    "platforms such as Kubernetes for deploying and managing containerized applications at scale.\r\n\r\nCloud Platforms: Expertise in cloud computing " +
            //    "platforms such as AWS, Azure, or Google Cloud Platform (GCP), including services like EC2, S3, IAM, VPC, Azure DevOps, Azure Kubernetes Service " +
            //    "(AKS), Google Kubernetes Engine (GKE), etc.",
            //    Benefiti = "Competitive salary and comprehensive benefits package\r\nFlexible work schedule and remote work options\r\nOpportunities for " +
            // "career growth and professional development\r\nDynamic and inclusive work culture with a focus on innovation and collaboration\r\nExciting " +
            // "projects and the chance to work with cutting-edge technologies",
            //    OglasId = 6
            //});


            /* zadnje
            opisOglas.Add(
                new Models.OpisOglas
                {
                    OpisPozicije = "We are seeking a meticulous and detail-oriented QA Engineer to join our dynamic team. The QA Engineer will be responsible for ensuring the quality and reliability of our software products through rigorous testing and quality assurance practices. This role involves collaborating with developers, product managers, and other stakeholders to identify issues, document defects, and ensure the delivery of high-quality software solutions.",
                    MinimumGodinaIskustva = 2,
                    PrefiraneGodineIskstva = 3,
                    Kvalifikacija = "Bachelor’s degree in Computer Science, Information Technology, or related field." +
                                    "\r\nProven experience as a QA Engineer or in a similar role." +
                                    "\r\nStrong understanding of software development and QA methodologies." +
                                    "\r\nExperience with test automation tools(e.g., Selenium, JUnit, TestNG)." +
                                    "\r\nFamiliarity with version control systems(e.g., Git).",
                    Vjestine = "Excellent analytical and problem-solving skills.\r\nStrong attention to detail and organizational abilities.\r\nProficiency in scripting and programming languages (e.g., Python, Java, C#).\r\nFamiliarity with Agile and Scrum development processes.\r\nStrong communication skills to effectively collaborate with team members and stakeholders.\r\nAbility to work independently and manage multiple tasks simultaneously.",
                    Benefiti = "Competitive salary and performance bonuses.\r\nComprehensive health, dental, and vision insurance.\r\nGenerous paid time off and holiday leave.\r\nOpportunities for professional development and career growth.\r\nFlexible working hours and remote work options.\r\nFriendly and collaborative work environment.",
                    OglasId = 7
                });


            opisOglas.Add(
            new Models.OpisOglas
            {
                OpisPozicije = "We are looking for a talented and motivated Software Engineer to join our innovative team. As a Software Engineer, you will be responsible for designing, developing, and maintaining high-quality software solutions. You will collaborate with cross-functional teams to deliver scalable and efficient software products that meet customer needs and industry standards.",
                MinimumGodinaIskustva = 3,
                PrefiraneGodineIskstva = 6,
                Kvalifikacija = "Bachelor’s degree in Computer Science, Software Engineering, or related field.\r\nProven experience as a Software Engineer or in a similar role.\r\nStrong proficiency in one or more programming languages (e.g., Java, Python, JavaScript).\r\nExperience with software development methodologies (e.g., Agile, Scrum).\r\nKnowledge of database management and SQL.",
                Vjestine = "Excellent problem-solving and analytical skills.\r\nAbility to work both independently and collaboratively in a team environment.\r\nStrong communication skills to effectively convey technical concepts to non-technical stakeholders.\r\nExperience with version control systems (e.g., Git) and CI/CD pipelines.\r\nFamiliarity with cloud platforms (e.g., AWS, Azure) and containerization technologies (e.g., Docker). ",
                Benefiti = "Competitive salary and performance-based bonuses.\r\nComprehensive health, dental, and vision insurance plans.\r\nFlexible work hours and remote work options.\r\nPaid time off, including vacation and sick leave.\r\nProfessional development opportunities, including training and conferences.\r\nCollaborative and inclusive work culture fostering innovation and creativity.\r\nAccess to cutting-edge technology and tools to support your work.",
                OglasId = 8
            });

            opisOglas.Add(
            new Models.OpisOglas
            {
                OpisPozicije = "We are seeking a talented Machine Learning Engineer to join our dynamic team. As a Machine Learning Engineer, you will collaborate with data scientists, software engineers, and domain experts to design, develop, and deploy machine learning models and solutions. Your expertise will drive innovation and enhance our products and services using advanced analytics and artificial intelligence.",
                MinimumGodinaIskustva = 3,
                PrefiraneGodineIskstva = 6,
                Kvalifikacija = "Bachelor’s degree in Computer Science, Engineering, Mathematics, or a related field; advanced degree preferred.\r\nProven experience as a Machine Learning Engineer or similar role.\r\nStrong proficiency in programming languages such as Python, R, or Scala.\r\nExperience with machine learning frameworks (e.g., TensorFlow, PyTorch) and libraries (e.g., scikit-learn).\r\nSolid understanding of statistics, data structures, and algorithms.",
                Vjestine = "Deep knowledge of machine learning techniques (supervised and unsupervised learning, deep learning, reinforcement learning).\r\nExperience with big data technologies (e.g., Hadoop, Spark) and distributed computing.\r\nProficiency in data preprocessing, feature engineering, and model evaluation.\r\nStrong problem-solving skills and the ability to translate business requirements into technical solutions.\r\nExcellent communication skills to collaborate effectively with team members and stakeholders.",
                Benefiti = "Competitive salary and performance-based bonuses.\r\nComprehensive health, dental, and vision insurance plans.\r\nFlexible work hours and remote work options.\r\nGenerous paid time off and parental leave policies.\r\nProfessional development opportunities, including training and conference attendance.\r\nAccess to cutting-edge tools and resources for machine learning and AI research.",
                OglasId = 9
            });

            opisOglas.Add(
            new Models.OpisOglas
            {
                OpisPozicije = "We are looking for a creative and skilled UI/UX Designer to join our innovative team. As a UI/UX Designer, you will be responsible for designing intuitive and engaging user interfaces for our digital products. You will collaborate closely with product managers, engineers, and stakeholders to create visually appealing and user-friendly designs that enhance user experience.",
                MinimumGodinaIskustva = 5,
                PrefiraneGodineIskstva = 6,
                Kvalifikacija = "Bachelor’s degree in Graphic Design, Interaction Design, Human-Computer Interaction, or a related field; relevant experience may substitute for a degree.\r\nProven experience as a UI/UX Designer or similar role, with a strong portfolio showcasing design projects.\r\nProficiency in design tools such as Sketch, Adobe XD, Figma, or similar.\r\nSolid understanding of user-centered design principles and best practices.\r\nExperience with responsive design and mobile-first principles.",
                Vjestine = "Strong visual design skills with a keen eye for typography, color, and layout.\r\nAbility to create intuitive and functional user interfaces based on user research and feedback.\r\nKnowledge of front-end development languages (HTML, CSS, JavaScript) is a plus.\r\nExcellent communication and collaboration skills to work effectively with multidisciplinary teams.\r\nProblem-solving skills and attention to detail in UI/UX design and usability issues.",
                Benefiti = "Competitive salary and performance-based bonuses.\r\nComprehensive health, dental, and vision insurance plans.\r\nFlexible work hours and remote work options.\r\nGenerous paid time off and parental leave policies.\r\nOpportunities for professional growth and career development.\r\nAccess to the latest design tools and resources to support your creativity.\r\nA collaborative and inclusive work environment that values creativity and innovation.",
                OglasId = 10
            });

            opisOglas.Add(
            new Models.OpisOglas
            {
                OpisPozicije = "We are seeking a talented Backend Developer to join our dynamic team. As a Backend Developer, you will be responsible for designing, developing, and maintaining scalable backend solutions that support our web and mobile applications. You will collaborate with cross-functional teams to define and implement robust APIs, integrate external services, and optimize server-side performance to deliver a seamless user experience.",
                MinimumGodinaIskustva = 1,
                PrefiraneGodineIskstva = 2,
                Kvalifikacija = "Bachelor’s degree in Computer Science, Engineering, or a related field; relevant experience may substitute for a degree.\r\nProven experience as a Backend Developer or similar role, with a strong portfolio of projects.\r\nProficiency in backend programming languages and frameworks such as Django, Flask, Express.js, or Spring Boot.\r\nExperience with relational and NoSQL databases (e.g., MySQL, PostgreSQL, MongoDB).\r\nUnderstanding of server-side architecture and cloud platforms (AWS, Azure, GCP).",
                Vjestine = "Strong understanding of RESTful APIs and web services.\r\nKnowledge of version control systems (e.g., Git) and CI/CD pipelines.\r\nFamiliarity with containerization and orchestration tools (e.g., Docker, Kubernetes).\r\nProblem-solving skills and ability to debug complex issues.\r\nExcellent communication and collaboration skills to work effectively in a team environment.",
                Benefiti = "Competitive salary and performance-based bonuses.\r\nComprehensive health, dental, and vision insurance plans.\r\nFlexible work hours and remote work options.\r\nGenerous paid time off and parental leave policies.\r\nOpportunities for professional growth and career development.\r\nAccess to cutting-edge technologies and tools to support your development projects.\r\nA collaborative and inclusive work environment that fosters creativity and innovation.",
                OglasId = 11
            });

            opisOglas.Add(
            new Models.OpisOglas
            {
                OpisPozicije = "We are looking for a talented Frontend Developer to join our growing team. As a Frontend Developer, you will collaborate with UX/UI designers and backend developers to translate designs into responsive web applications. You will be responsible for implementing visual elements and user interactions, ensuring cross-browser compatibility, and optimizing application performance. Your creativity and technical skills will play a crucial role in delivering intuitive and engaging user experiences.",
                MinimumGodinaIskustva = 1,
                PrefiraneGodineIskstva = 3,
                Kvalifikacija = "Bachelor’s degree in Computer Science, Engineering, or a related field; relevant experience may substitute for a degree.\r\nProven experience as a Frontend Developer or similar role, with a strong portfolio of projects showcasing frontend development skills.\r\nProficiency in frontend technologies such as HTML5, CSS3 (Sass/Less), JavaScript, and modern JavaScript frameworks/libraries (e.g., React.js, Angular, Vue.js).\r\nExperience with responsive design principles and cross-browser compatibility.\r\nFamiliarity with RESTful APIs and integration patterns.\r\nUnderstanding of version control systems (e.g., Git) and agile development methodologies.",
                Vjestine = "Strong problem-solving skills and attention to detail.\r\nAbility to work effectively in a collaborative team environment.\r\nExcellent communication skills and ability to articulate technical concepts to non-technical stakeholders.\r\nPassion for frontend development and eagerness to learn new technologies and frameworks.",
                Benefiti = "Competitive salary and performance-based bonuses.\r\nComprehensive health, dental, and vision insurance plans.\r\nFlexible work hours and remote work options.\r\nGenerous paid time off and parental leave policies.\r\nOpportunities for professional growth and career advancement.\r\nAccess to training resources and certifications to enhance your skills.\r\nA supportive and inclusive work environment that encourages creativity and innovation.",
                OglasId = 12
            });

            opisOglas.Add(
            new Models.OpisOglas
            {
                OpisPozicije = "We are seeking a creative Graphic Designer to join our dynamic team. As a Graphic Designer, you will collaborate with marketing and creative teams to create visually appealing designs that convey our brand message effectively. You will be responsible for designing graphics for various platforms, including digital and print media, ensuring consistency in style, and maintaining brand identity. Your innovative ideas and attention to detail will play a crucial role in producing high-quality visual content.",
                MinimumGodinaIskustva = 3,
                PrefiraneGodineIskstva = 6,
                Kvalifikacija = "Bachelor’s degree in Graphic Design, Visual Arts, or a related field; relevant experience may substitute for a degree.\r\nProven experience as a Graphic Designer or in a similar role, with a strong portfolio showcasing creative and professional designs.\r\nProficiency in graphic design software and tools, such as Adobe Creative Suite (Illustrator, Photoshop, InDesign).\r\nStrong understanding of design principles, typography, color theory, and layout techniques.\r\nAbility to work effectively in a collaborative team environment and communicate design concepts to stakeholders.",
                Vjestine = "Creativity and artistic ability to conceptualize and execute original designs.\r\nAttention to detail and ability to adhere to project deadlines.\r\nStrong problem-solving skills and ability to adapt to feedback and changing requirements.\r\nExcellent communication skills and ability to present design concepts clearly.",
                Benefiti = "Competitive salary and performance-based bonuses.\r\nComprehensive health, dental, and vision insurance plans.\r\nFlexible work hours and remote work options.\r\nGenerous paid time off and holidays.\r\nOpportunities for professional development and training.\r\nSupportive and inclusive work environment that values creativity and innovation.\r\nAccess to cutting-edge design tools and resources.",
                OglasId = 13
            });
            */




            //kompanije

            //var kompanijaByteMatrix = new Database.Kompanija()
            //{
            //    Naziv = "ByteMatrix Solutions",
            //    GodinaOsnivanja = 2012,
            //    Lokacija = "Sarajevo",
            //    Email = "ByteMatrix.Solutions@gmail.com",
            //    UserName = "bytematrix",
            //};
            //kompanijaByteMatrix.PasswordSalt = HelperMethods.GenerateSalt();
            //kompanijaByteMatrix.UlogaId = 3;

            //var result = await userManager.CreateAsync(kompanijaByteMatrix, "");

            //await userManager.AddToRoleAsync(kompanijaByteMatrix, "Kompanija");



            //kompanije

            //kompanije.Add(new Models.Kompanija { Naziv = "ByteMatrix Solutions", GodinaOsnivanja = 2012, Lokacija = "Sarajevo", Slika = "slika...", Email = "ByteMatrix.Solutions@gmail.com", Username = "bytematrix", Password = "bytematrix", TemaId = 1, JezikId = 1 });
            //kompanije.Add(new Models.Kompanija { Naziv = "TechVista Dynamics", GodinaOsnivanja = 2016, Lokacija = "Mostar", Slika = "slika...", Email = "TechVista Dynamics@gmail.com", Username = "techvista", Password = "techvista", TemaId = 1, JezikId = 1 });
            //kompanije.Add(new Models.Kompanija { Naziv = "CloudMesh", GodinaOsnivanja = 2010, Lokacija = "Jablanica", Slika = "slika...", Email = "CloudMesh@gmail.com", Username = "cloudmesh", Password = "cloudmesh", TemaId = 1, JezikId = 1 });
            //kompanije.Add(new Models.Kompanija { Naziv = "Insightify", GodinaOsnivanja = 2021, Lokacija = "Tuzla", Slika = "slika...", Email = "Insightify@gmail.com", Username = "insightify", Password = "insightify", TemaId = 1, JezikId = 1 });


            /*
      

            var kompanije = new List<Models.Kompanija>
            {
                new Models.Kompanija { Naziv = "ByteMatrix Solutions", GodinaOsnivanja = 2012, Lokacija="Sarajevo", Slika = "slika...", Email = "ByteMatrix.Solutions@gmail.com", Username = "bytematrix", Password = "bytematrix", TemaId = tema1.Id, JezikId = bosanskiJezik.Id},
                new Models.Kompanija { Naziv = "TechVista Dynamics", GodinaOsnivanja = 2016, Lokacija = "Mostar", Slika = "slika...", Email = "TechVista Dynamics@gmail.com", Username = "techvista", Password = "techvista", TemaId = tema1.Id, JezikId = engleskiJezik.Id },
                new Models.Kompanija { Naziv = "CloudMesh", GodinaOsnivanja = 2010, Lokacija = "Jablanica", Slika = "slika...", Email = "CloudMesh@gmail.com", Username = "cloudmesh", Password = "cloudmesh", TemaId = tema1.Id, JezikId = arapskiJezik.Id },
                new Models.Kompanija { Naziv = "Insightify", GodinaOsnivanja = 2021, Lokacija = "Tuzla", Slika = "slika...", Email = "Insightify@gmail.com", Username = "insightify", Password = "insightify", TemaId = tema2.Id, JezikId = bosanskiJezik.Id }
            };*/



            //var ByteMatrix = dbContext.Kompanije.Where(x => x.Naziv == "ByteMatrix Solutions").FirstOrDefault();

            //ByteMatrix.Website = "www.bytematrixsolutions.com";
            //ByteMatrix.BrojZaposlenih = BrojZaposlenih._11_50.ToDisplayString();
            //ByteMatrix.LinkedIn = " https://linkedin.com/company/byteMatrix-solutions";
            //ByteMatrix.Twitter = "https://twitter.com/byteMatrixSol";
            //ByteMatrix.KratkiOpis = "We specializes in innovative data solutions and custom software development to drive business growth and efficiency.";
            //ByteMatrix.Opis = "ByteMatrix Solutions is a forward-thinking technology company that specializes in providing cutting-edge data solutions and software development services. Founded in 2015, the company has quickly risen to become a key player in the tech industry, offering a range of services from custom software development to big data analytics.\r\n\r\nOur mission is to help businesses harness the power of technology to drive growth and innovation. With a dedicated team of over 200 professionals, we pride ourselves on delivering exceptional results that exceed our clients' expectations.\r\n\r\nOur Services\r\nCustom Software Development:\r\n\r\nTailored software solutions that meet the unique needs of our clients.\r\nExpertise in various programming languages and frameworks.\r\nAgile development methodology ensuring flexibility and rapid delivery.\r\nBig Data Analytics:\r\n\r\nAdvanced data analytics services to help businesses make informed decisions.\r\nData mining, data warehousing, and predictive analytics.\r\nImplementation of data-driven strategies to enhance business performance.\r\nCloud Solutions:\r\n\r\nScalable and secure cloud computing services.\r\nMigration to cloud platforms such as AWS, Azure, and Google Cloud.\r\nCloud infrastructure management and optimization.\r\nMobile App Development:\r\n\r\nDevelopment of innovative mobile applications for iOS and Android platforms.\r\nUser-friendly interfaces and seamless performance.\r\nEnd-to-end mobile app lifecycle management.\r\nConsulting Services:\r\n\r\nStrategic IT consulting to help businesses navigate digital transformation.\r\nIT infrastructure assessment and optimization.\r\nImplementation of best practices and industry standards.\r\nOur Culture\r\nAt ByteMatrix Solutions, we believe in fostering a culture of innovation and collaboration. Our team is composed of highly skilled professionals who are passionate about technology and committed to excellence. We encourage continuous learning and professional development to stay ahead of industry trends.\r\n\r\nOur Clients\r\nWe have had the privilege of working with a diverse range of clients across various industries, including finance, healthcare, retail, and manufacturing. Our client-centric approach ensures that we understand their specific challenges and deliver solutions that drive tangible results.\r\n\r\nAchievements and Recognition\r\nRecognized as one of the fastest-growing tech companies in San Francisco.\r\nAwarded for excellence in software development and data analytics.\r\nFeatured in leading industry publications for our innovative solutions.\r\nCommunity Involvement\r\nByteMatrix Solutions is dedicated to giving back to the community. We actively participate in tech education initiatives, support local charities, and promote sustainability through green practices in our operations.";

            //var TechVista = dbContext.Kompanije.Where(x => x.Naziv == "TechVista Dynamics").FirstOrDefault();

            //TechVista.Website = "www.techvistadynamics.com";
            //TechVista.BrojZaposlenih = BrojZaposlenih._501_1000.ToDisplayString();
            //TechVista.LinkedIn = "https://linkedin.com/company/techvista-dynamics";
            //TechVista.Twitter = "https://twitter.com/techvista_dyn";
            //TechVista.KratkiOpis = "TechVista Dynamics delivers cutting-edge cloud computing and IT consulting services.";
            //TechVista.Opis = "At TechVista Dynamics, we are a leading technology company dedicated to providing innovative cloud computing and IT consulting services. Since our inception in 2010, we have established ourselves as a trusted partner for businesses looking to modernize their IT infrastructure and leverage the benefits of cloud technology. Headquartered in San Francisco, CA, we employ a diverse team of over 300 skilled professionals who are committed to delivering excellence and customer satisfaction.\r\n\r\nWe specialize in a broad spectrum of services, including cloud migration, application development, IT strategy consulting, and managed services. Our pride lies in our ability to tailor solutions to meet the unique needs of each client, ensuring that businesses can optimize their operations, enhance productivity, and drive innovation. By staying at the forefront of technological advancements, we help organizations navigate the complexities of the digital landscape and achieve their strategic goals.\r\n\r\nOur commitment to continuous improvement and staying ahead of industry trends is unwavering. We invest heavily in research and development, enabling us to offer cutting-edge solutions that provide a competitive edge to our clients. Our culture is built on a foundation of integrity, collaboration, and a passion for technology, fostering an environment where our employees are encouraged to innovate and excel.\r\n\r\nWe serve a diverse range of industries, including finance, healthcare, retail, and manufacturing. Our comprehensive approach, combined with deep industry expertise, allows us to deliver high-impact solutions that drive measurable results. As a testament to our success, we have forged long-term relationships with numerous clients, helping them achieve digital transformation and secure their position in an ever-evolving market.\r\n\r\nWhether it's migrating to the cloud, developing custom applications, or devising an IT strategy, we at TechVista Dynamics are dedicated to empowering businesses with the tools and expertise they need to thrive in the digital age.";

            //var CloudMesh = dbContext.Kompanije.Where(x => x.Naziv == "CloudMesh").FirstOrDefault();

            //CloudMesh.Website = "www.cloudmesh.com";
            //CloudMesh.BrojZaposlenih = BrojZaposlenih._1_10.ToDisplayString();
            //CloudMesh.LinkedIn = "https://linkedin.com/company/cloudmesh";
            //CloudMesh.Twitter = "https://twitter.com/cloudmesh";
            //CloudMesh.KratkiOpis = "We specialize in providing robust cloud management solutions to streamline your IT operations.";
            //CloudMesh.Opis = "At CloudMesh, we are dedicated to revolutionizing the way businesses manage their IT infrastructure through innovative cloud management solutions. Since our establishment in 2015, we have been committed to helping organizations of all sizes streamline their IT operations, reduce costs, and enhance their overall efficiency. Based in the vibrant tech hub of Seattle, WA, we employ a talented team of over 150 professionals who are passionate about cloud technology and its transformative potential.\r\n\r\nOur core expertise lies in delivering comprehensive cloud management services, including cloud migration, optimization, security, and monitoring. We pride ourselves on our ability to offer tailored solutions that meet the specific needs of each client, ensuring they can fully leverage the power of the cloud to achieve their business objectives. Our solutions are designed to simplify the complexity of cloud management, providing businesses with the tools they need to stay agile and competitive in today’s fast-paced market.\r\n\r\nInnovation is at the heart of what we do at CloudMesh. We invest heavily in research and development to stay ahead of industry trends and continuously enhance our offerings. Our customer-centric approach ensures that we build lasting relationships with our clients, understanding their unique challenges and working closely with them to deliver solutions that drive real value. We serve a diverse range of industries, including finance, healthcare, retail, and technology, helping them navigate the complexities of cloud adoption and management.\r\n\r\nAt CloudMesh, our mission is to empower businesses to harness the full potential of the cloud. We believe that with the right tools and expertise, any organization can achieve greater agility, scalability, and efficiency. Our team is dedicated to providing exceptional service and support, ensuring that our clients can confidently move forward on their cloud journey.";

            //var Insightify = dbContext.Kompanije.Where(x => x.Naziv == "Insightify").FirstOrDefault();

            //Insightify.Website = "www.insightify.com";
            //Insightify.BrojZaposlenih = BrojZaposlenih._101_500.ToDisplayString();
            //Insightify.LinkedIn = "https://linkedin.com/company/insightify";
            //Insightify.Twitter = "https://twitter.com/insightify";
            //Insightify.KratkiOpis = "We specialize in delivering advanced data analytics and business intelligence solutions to drive your success.";
            //Insightify.Opis = "At Insightify, we are passionate about unlocking the potential of data to drive business success. Since our inception in 2010, we have been at the forefront of delivering advanced data analytics and business intelligence solutions that empower organizations to make informed, data-driven decisions. Located in the thriving tech ecosystem of Austin, TX, we are a dedicated team of over 300 professionals who are committed to helping our clients harness the power of their data.\r\n\r\nOur expertise spans a wide range of data analytics services, including data integration, predictive analytics, machine learning, and custom dashboard development. We work closely with our clients to understand their unique needs and challenges, providing tailored solutions that deliver actionable insights and drive measurable results. Our goal is to make complex data accessible and valuable, enabling businesses to uncover hidden opportunities and optimize their operations.\r\n\r\nInnovation and excellence are at the core of Insightify. We continuously invest in cutting-edge technologies and methodologies to stay ahead of industry trends and deliver the best possible solutions to our clients. Our customer-centric approach ensures that we build strong, lasting relationships, providing exceptional service and support at every step of the way. We serve a diverse array of industries, including finance, healthcare, manufacturing, and retail, helping them leverage their data to gain a competitive edge.\r\n\r\nAt Insightify, our mission is to transform the way businesses use data. We believe that with the right tools and expertise, any organization can achieve greater efficiency, profitability, and growth. Our team is dedicated to delivering high-quality solutions and unparalleled support, ensuring that our clients can confidently navigate the data-driven landscape and achieve their strategic objectives.";




            //var QuantumBytes = new Models.Kompanija(korisnik)
            //{
            //    Naziv = "QuantumBytes Solutions",
            //    GodinaOsnivanja = 2018,
            //    Lokacija = "Jablanica",
            //    BrojZaposlenih = BrojZaposlenih._11_50.ToDisplayString(),
            //    KratkiOpis = "We specialize in innovative software solutions and cutting-edge technology services to drive business growth.",
            //    Opis = "At QuantumBytes Solutions, we are dedicated to pioneering innovative software solutions and cutting-edge technology services that drive business growth and efficiency. Established in 2018 in the tech hub of San Francisco, CA, our team of passionate and skilled professionals is committed to delivering exceptional value to our clients.\r\n\r\nWe offer a comprehensive range of services including custom software development, cloud computing, artificial intelligence, and cybersecurity solutions. Our expertise lies in understanding the unique challenges faced by businesses and providing tailored solutions that meet their specific needs. We work closely with our clients to ensure that our technology solutions align with their strategic goals and drive measurable results.\r\n\r\nInnovation is at the heart of everything we do at QuantumBytes Solutions. We continuously explore new technologies and methodologies to stay ahead of industry trends and provide our clients with the best possible solutions. Our customer-centric approach ensures that we build strong, long-lasting relationships, delivering exceptional service and support throughout the entire project lifecycle. Our clients span various industries including finance, healthcare, retail, and more, all benefiting from our expertise in leveraging technology to achieve their business objectives.\r\n\r\nOur mission at QuantumBytes Solutions is to empower businesses with the technology they need to thrive in a rapidly evolving digital landscape. We believe that with the right tools and guidance, any organization can achieve significant improvements in efficiency, profitability, and growth. Our team is dedicated to providing high-quality solutions and unparalleled support, helping our clients navigate the complexities of the digital age with confidence.",
            //    Website = "https://quantumbytes.com",
            //    LinkedIn = "https://linkedin.com/company/quantumbytes",
            //    Twitter = "https://twitter.com/quantumbytes"
            //};

            //dbContext.Kompanije.Add(QuantumBytes);
            //dbContext.SaveChangesAsync();



            //oglasIskustvo.Add(new Models.OglasIskustvo { OglasId = 5, IskustvoId = 4 });
            //oglasIskustvo.Add(new Models.OglasIskustvo { OglasId = 5, IskustvoId = 5 });
            //oglasIskustvo.Add(new Models.OglasIskustvo { OglasId = 6, IskustvoId = 6 });
            //oglasIskustvo.Add(new Models.OglasIskustvo { OglasId = 7, IskustvoId = 4 });
            //oglasIskustvo.Add(new Models.OglasIskustvo { OglasId = 8, IskustvoId = 5 });
            //oglasIskustvo.Add(new Models.OglasIskustvo { OglasId = 9, IskustvoId = 6 });
            //oglasIskustvo.Add(new Models.OglasIskustvo { OglasId = 10, IskustvoId = 4 });
            //oglasIskustvo.Add(new Models.OglasIskustvo { OglasId = 11, IskustvoId = 5 });
            //oglasIskustvo.Add(new Models.OglasIskustvo { OglasId = 12, IskustvoId = 6 });
            //oglasIskustvo.Add(new Models.OglasIskustvo { OglasId = 13, IskustvoId = 4 });
            //oglasIskustvo.Add(new Models.OglasIskustvo { OglasId = 7, IskustvoId = 5 });

            //oglasLokacija.Add(new Models.OglasLokacija { OglasId = 5, LokacijaId = 6 });
            //oglasLokacija.Add(new Models.OglasLokacija { OglasId = 5, LokacijaId = 7 });
            //oglasLokacija.Add(new Models.OglasLokacija { OglasId = 6, LokacijaId = 8 });
            //oglasLokacija.Add(new Models.OglasLokacija { OglasId = 7, LokacijaId = 9 });
            //oglasLokacija.Add(new Models.OglasLokacija { OglasId = 8, LokacijaId = 10 });
            //oglasLokacija.Add(new Models.OglasLokacija { OglasId = 9, LokacijaId = 6 });
            //oglasLokacija.Add(new Models.OglasLokacija { OglasId = 10, LokacijaId = 7 });
            //oglasLokacija.Add(new Models.OglasLokacija { OglasId = 11, LokacijaId = 8 });
            //oglasLokacija.Add(new Models.OglasLokacija { OglasId = 12, LokacijaId = 9 });
            //oglasLokacija.Add(new Models.OglasLokacija { OglasId = 13, LokacijaId = 10 });
            //oglasLokacija.Add(new Models.OglasLokacija { OglasId = 7, LokacijaId = 7 });
            /*
            dbContext.AddRange(kompanije);
            dbContext.SaveChanges();*/

            //dbContext.AddRange(oglasi);
            //dbContext.AddRange(kompanije);
            //dbContext.AddRange(jezici);
            //dbContext.AddRange(teme);
            //dbContext.AddRange(iskustvo);
            //dbContext.AddRange(lokacija);
            //dbContext.AddRange(oglasIskustvo);
            //dbContext.AddRange(oglasLokacija);
            //dbContext.AddRange(opisOglas); 

            // dbContext.SaveChanges();    
            //var oglasi = new List<Models.Oglas>
            //{
            //    new Models.Oglas { NazivPozicije = "Software Engineer", Lokacija = "Remote", DatumObjave = DateTime.Now, Plata = 2000, TipPosla = "Full Time", RokPrijave = DateTime.MaxValue, Iskustvo = "Junior", OpisPosla = "opis.....", KompanijaId = kompanije[0].Id },
            //    new Models.Oglas { NazivPozicije = "DevOps Engineer", Lokacija = "Jablanica", DatumObjave = DateTime.Now, Plata = 3400, TipPosla = "Full Time", RokPrijave = DateTime.MaxValue, Iskustvo = "Senior", OpisPosla = "opis.....", KompanijaId = kompanije[1].Id },
            //    new Models.Oglas { NazivPozicije = "QA Engineer", Lokacija = "Remote", DatumObjave = DateTime.Now, Plata = 2500, TipPosla = "Full Time", RokPrijave = DateTime.MaxValue, Iskustvo = "Medior", OpisPosla = "opis.....", KompanijaId = kompanije[2].Id },
            //    new Models.Oglas { NazivPozicije = "Software Engineer", Lokacija = "Remote", DatumObjave = DateTime.Now, Plata = 2300, TipPosla = "Full Time", RokPrijave = DateTime.MaxValue, Iskustvo = "Junior", OpisPosla = "opis.....", KompanijaId = kompanije[3].Id },
            //    new Models.Oglas { NazivPozicije = "ML Engineer", Lokacija = "Remote", DatumObjave = DateTime.Now, Plata = 4000, TipPosla = "Full Time", RokPrijave = DateTime.MaxValue, Iskustvo = "Senior", OpisPosla = "opis.....", KompanijaId = kompanije[0].Id },
            //    new Models.Oglas { NazivPozicije = "UI/UX Designer", Lokacija = "Mostar", DatumObjave = DateTime.Now, Plata = 1000, TipPosla = "Part Time", RokPrijave = DateTime.MaxValue, Iskustvo = "Junior", OpisPosla = "opis.....", KompanijaId = kompanije[1].Id },
            //    new Models.Oglas { NazivPozicije = "Backend Developer", Lokacija = "Remote", DatumObjave = DateTime.Now, Plata = 2600, TipPosla = "Full Time", RokPrijave = DateTime.MaxValue, Iskustvo = "Junior", OpisPosla = "opis.....", KompanijaId = kompanije[2].Id },
            //    new Models.Oglas { NazivPozicije = "Frontend Developer", Lokacija = "Tuzla", DatumObjave = DateTime.Now, Plata = 2300, TipPosla = "Full Time", RokPrijave = DateTime.MaxValue, Iskustvo = "Junior", OpisPosla = "opis.....", KompanijaId = kompanije[3].Id },
            //    new Models.Oglas { NazivPozicije = "Graphical Designer", Lokacija = "Remote", DatumObjave = DateTime.Now, Plata = 1800, TipPosla = "Part Time", RokPrijave = DateTime.MaxValue, Iskustvo = "Medior", OpisPosla = "opis.....", KompanijaId = kompanije[0].Id }
            //};
            /*
             dbContext.AddRange(oglasi);
             dbContext.SaveChanges();*/

            return Ok();
        }
    }
}
