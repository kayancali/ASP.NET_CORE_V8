namespace basics.Models
{

    public class Repository
    {
        private static readonly List<Course> _courses = new();

        static Repository(){
            _courses = new List<Course>()
            {
            new Course () { 
              Id = 1, 
              Title ="GAME OF THRONES1",
              Description = " Series", 
              Image ="got.jpeg",
              Tags = new string[] {"aspnet","web"},
              isActive=true,
              isHome=true
            },

            new Course () { 
                Id = 2, 
                Title ="GAME OF THRONES2", 
                Description = " Series", 
                Image ="got1.jpeg",
                Tags = new string[] {"php","web"},
                isActive=false,
                isHome=true
            },

           

            new Course () { Id = 3,
                    Title ="GAME OF THRONES3", 
                    Description = " Series",
                    Image ="got2.jpg",
                    isActive=true,
                    isHome=false
               
            },

            new Course () { Id = 4, 
                Title ="GAME OF THRONES4", 
                Description = " Series",
                Image ="got2.jpg",
                isActive=true,
                isHome=true
                },
                
            };
        }

        public static List<Course> Courses
        {
            get 
            {
                return _courses;
            }
        }
        public static Course? GetById(int? id)
        {
            return _courses.FirstOrDefault( c=> c.Id == id);
        }


    }
}