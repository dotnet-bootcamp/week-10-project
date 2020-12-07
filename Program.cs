using System;
using System.Linq;

namespace week_10_project
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                // Create
                Console.WriteLine("Inserting a new blog");
                db.Add(new Blog { Url = "http://blogs.blog.com/blog1" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs
                    .OrderBy(b => b.BlogId)
                    .First();

                // Update
                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "http://blogs.blog.com/firstblog";
                blog.Posts.Add(
                    new Post
                    {
                        Title = "Hello World",
                        Content = "First Blog Post!"
                    });
                db.SaveChanges();

                // Delete
                Console.WriteLine("Delete the blog");
                db.Remove(blog);
                db.SaveChanges();

                // Create with rating
                Console.WriteLine("Inserting a blog with a rating");
                Blog newBlogWithRating = new Blog();
                newBlogWithRating.Url = "http://blogs.blog.com/secondblog";
                newBlogWithRating.Rating = 4;
                newBlogWithRating.Posts.Add(
                    new Post
                    {
                        Title = "Blog with Rating",
                        Content = "Another blog with a rating!"
                    });
                db.Add(newBlogWithRating);
                db.SaveChanges();
            }
        }
    }
}
