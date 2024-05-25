using Microsoft.EntityFrameworkCore;
using Weblog.Api.Application.Interfaces;
using Weblog.Api.Domain.Entities;
using Weblog.Api.Infrastructure.Data;

namespace Weblog.Api.Infrastructure.Repositories;

public class BlogRepository : IBlogRepository
{
    private readonly BlogDbContext _dbContext;

    public BlogRepository(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Blog>> GetAllAsync()
    {
        return await _dbContext.Blogs.ToListAsync();
    }

    public async Task<Blog?> GetByIdAsync(int id)
    {
        return await _dbContext.Blogs.FindAsync(id);
    }

    public async Task<Blog> CreateAsync(Blog blog)
    {
        _dbContext.Blogs.Add(blog);
        await _dbContext.SaveChangesAsync();
        return blog;
    }

    public async Task<Blog?> UpdateAsync(int id, Blog blog)
    {
        var existingBlog = await _dbContext.Blogs.FindAsync(id);
        if (existingBlog == null)
            return null;

        existingBlog.Title = blog.Title;
        existingBlog.Content = blog.Content;
        existingBlog.TruncatedContent = blog.TruncatedContent;

        await _dbContext.SaveChangesAsync();
        return existingBlog;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var blog = await _dbContext.Blogs.FindAsync(id);
        if (blog == null)
            return false;

        _dbContext.Blogs.Remove(blog);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}