using CodePulse.DataAccess.Context;
using CodePulse.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
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
        
        public async Task<BlogPostsModel> CreateBlog(BlogPostsModel model)
        {
            await _context.BlogPosts.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<BlogPostsModel> UpdateBlog(BlogPostsModel model)
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

                await _context.SaveChangesAsync();
            }
            return model;
        }

        public async Task DeleteBlog(long id)
        {
            var blog = _context.BlogPosts.Find(id);
            if(blog != null)
            {
                _context.Remove(blog);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<BlogPostsModel>> GetAllBlogs()
        {
            return await _context.BlogPosts.ToListAsync();
        }

        public async Task<BlogPostsModel> GetBlog(long id)
        {
            return await _context.BlogPosts.FindAsync(id)!;
        }
    }
}
