using CodePulse.DataAccess.Context;
using CodePulse.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePulse.DataAccess.Repositories
{
    public class BlogPostsRepository
    {
        private readonly ApplicationDbContext _context;
        public BlogPostsRepository()
        {
            _context = new ApplicationDbContext();
        }
        
        public long CreateBlog(BlogPostsModel model)
        {
            _context.BlogPosts.Add(model);
            _context.SaveChanges();
            return model.Id;
        }

        public long UpdateBlog(BlogPostsModel model)
        {
            var blog = _context.BlogPosts.Find(model.Id);
            if(blog != null)
            {
                blog.Title = model.Title;
                blog.ShortDescription = model.ShortDescription;
                blog.Content = model.Content;
                blog.FeatureImageUrl = model.FeatureImageUrl;
                blog.UrlHandle = model.UrlHandle;
                blog.PublishedDate = model.PublishedDate;
                blog.Author = model.Author;
                blog.IsVisible = model.IsVisible;

                _context.SaveChanges();
            }
            return model.Id;
        }

        public void DeleteBlog(long id)
        {
            var blog = _context.BlogPosts.Find(id);
            if(blog != null)
            {
                _context.Remove(blog);
                _context.SaveChanges();
            }
        }

        public List<BlogPostsModel> GetAllBlogs()
        {
            return _context.BlogPosts.ToList();
        }

        public BlogPostsModel GetBlog(long id)
        {
            return _context.BlogPosts.Find(id)!;
        }
    }
}
