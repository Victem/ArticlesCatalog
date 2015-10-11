using ArticlesCatalog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesCatalog.DataAccess
{
    public class DBInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

           

            for (int i = 0; i < 5; i++)
            {
                Topic topic = new Topic();
                topic.TopicName = $"Topic-{i}";
                context.Topics.Add(topic);
            }

            context.SaveChanges();


            foreach (Topic topic in context.Topics)
            {
                for (int i = 0; i < 3; i++)
                {
                    Topic subTopic = new Topic();
                    subTopic.TopicName = topic.TopicName + $"-{i}";
                    topic.Childs.Add(subTopic);
                }
            }

            context.SaveChanges();

            foreach (Topic topic in context.Topics.Where(t => t.ParentID != null))
            {
                for (int i = 0; i < 3; i++)
                {
                    Topic subTopic = new Topic();
                    subTopic.TopicName = topic.TopicName + $"-{i}";
                    topic.Childs.Add(subTopic);
                }
            }

            context.SaveChanges();


            foreach(Topic topic in context.Topics)
            {
                for (int i = 0; i < 3; i++)
                {
                    Article article = new Article() { ArticleHeader = topic.TopicName + $"Header-{i}", ArticleText = topic.TopicName+$" Article body {topic.TopicID}-{i}", };
                    topic.Articles.Add(article);
                }

            }

            context.SaveChanges();
            //ApplicationUser user = new ApplicationUser()
            //{
            //    UserName = "Admin",
            //    Id = "Admin"
            //};
            //IdentityRole role = new IdentityRole("admin");


            //userManager.Create(user, "password");
            //roleManager.Create(role);
            //userManager.AddToRole(user.Id, role.Name);


        }


    }   
}
