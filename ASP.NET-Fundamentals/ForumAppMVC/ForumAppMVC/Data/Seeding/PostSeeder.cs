using ForumApp.Data.Models;

namespace ForumApp.Data.Seeding
{
    class PostSeeder
    {
        internal Post[] GeneratePosts()
        {
            ICollection<Post> posts = new HashSet<Post>();
            Post currentPost;

            currentPost = new Post()
            {
                Id = 1,
                Title = "My first post",
                Content = "My firs post will be about performing " +
                "CRUD operations in MVC. It's so much fun!"
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Id = 2,
                Title = "My second post",
                Content = "This is my second post. " +
                "CRUD operations in MVC are getting more and more interesting!"
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Id = 3,
                Title = "My third post",
                Content = "Hello there! I'm getting better and better with the" +
                "CRUD operations in MVC. Stay tuned!"
            };
            posts.Add(currentPost);

            return posts.ToArray();
        }
    }
}
