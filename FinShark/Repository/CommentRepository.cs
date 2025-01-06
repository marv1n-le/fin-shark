using FinShark.Data;
using FinShark.Interfaces;
using FinShark.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Repository;

public class CommentRepository : ICommentRepository
{
    public readonly AppDbContext _context;

    public CommentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Comment>> GetAllComments()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetById(int id)
    {
        return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Comment> CreateAsync(Comment commentModel)
    {
        await _context.Comments.AddAsync(commentModel);
        await _context.SaveChangesAsync();
        return commentModel;
    }

    public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
    {
        var exist = await _context.Comments.FindAsync(id);
        if (exist == null)
            return null;
        exist.Content = commentModel.Content;
        exist.Title = commentModel.Title;

        await _context.SaveChangesAsync();
        return exist;
    }
}