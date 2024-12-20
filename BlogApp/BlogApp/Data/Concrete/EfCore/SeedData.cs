using BlogApp.Data.Conrete.EfCore;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null)
            {
                if(context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if(!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "web programlama", Url = "web-programlama", Color= TagColors.warning},
                        new Tag { Text = "backend", Url="backend" ,Color = TagColors.success,},
                        new Tag { Text = "frontend", Url="frontend",Color = TagColors.primary, },
                        new Tag { Text = "fullstack", Url="fullstack",Color = TagColors.secondary, },
                        new Tag { Text = "php", Url="php",Color = TagColors.info, }
                    );
                    context.SaveChanges();
                }

                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "muhammetAli",Name="Ali Kayanc",Email="kayancalii54@gmail.com",Password="123456", Image= "p1.jpg"},
                        new User { UserName = "TheBuck",Name="THE BUCK",Email="kayanca4@gmail.com",Password="123", Image= "p2.jpg"}
                    );
                    context.SaveChanges();
                }

                if(!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post {
                            
                            Title = "Asp.net core",
                            Content = "Asp.net core dersleri",
                            Description = "Asp.net core dersleri",
                            Url = "aspnet-core",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "1.jpg",
                            UserId = 1,
                            Comments = new List<Comment>{ 
                                new Comment { Text = "iyi bir kurs ",PublishedOn= new DateTime(),UserId = 1},
                                new Comment { Text = "ÇOOĞ İYİYDİR ",PublishedOn= new DateTime(),UserId = 2}}
                        },
                        new Post {
                            Title = "Php",
                            Content = "Php core dersleri",
                            Description = "Php core dersleri",
                            Url = "php",
                            IsActive = true,
                            Image = "2.jpg",
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(2).ToList(),
                            UserId = 1
                        },
                        new Post {
                            Title = "Django",
                            Content = "Django dersleri",
                            Description = "Django dersleri",
                            Url = "django",
                            IsActive = true,
                            Image = "3.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2
                        }
                        ,
                        new Post {
                            Title = "React Dersleri",
                            Content = "React dersleri",
                            Description = "React dersleri",
                            Url = "react-dersleri",
                            IsActive = true,
                            Image = "3.jpg",
                            PublishedOn = DateTime.Now.AddDays(-40),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2
                        }
                        ,
                        new Post {
                            Title = "Angular",
                            Content = "Angular dersleri",
                            Description = "Angular dersleri",
                            Url = "angular",
                            IsActive = true,
                            Image = "3.jpg",
                            PublishedOn = DateTime.Now.AddDays(-50),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2
                        }
                        ,
                        new Post {
                            Title = "Web Tasarım",
                            Content = "Web tasarım dersleri",
                            Description = "Web tasarım dersleri",
                            Url = "web-tasarim",
                            IsActive = true,
                            Image = "3.jpg",
                            PublishedOn = DateTime.Now.AddDays(-60),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}