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
    public  class CategoriesRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoriesRepository() 
        {
            _context = new ApplicationDbContext();
        }

        public async Task<CategoriesModel> CreateCategory(CategoriesModel model)
        {
            await _context.Categories.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<CategoriesModel> UpdateCategory(CategoriesModel model)
        {
            var category = _context.Categories.Find(model.Id);
            if (category != null)
            {
                category.Name = model.Name;
                category.UrlHandle = model.UrlHandle;
                await _context.SaveChangesAsync();
            }
            return model;
        }

        public async Task<bool> DeleteCategory(long categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            if (category != null)
            {
                _context.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<CategoriesModel>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<CategoriesModel> GetCategoryById(long categoryId)
        {
              CategoriesModel result = await _context.Categories.FindAsync(categoryId)!;
            return result!;
        }

    }
}
