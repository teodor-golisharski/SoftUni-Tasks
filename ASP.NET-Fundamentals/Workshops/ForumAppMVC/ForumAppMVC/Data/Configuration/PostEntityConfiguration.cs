using ForumApp.Data.Models;
using ForumApp.Data.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForumApp.Data.Configuration
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        private readonly PostSeeder postSeeder;
        
        public PostEntityConfiguration()
        {
            this.postSeeder = new PostSeeder();        
        }

        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .HasData(this.postSeeder.GeneratePosts()); 
        }
    }
}
