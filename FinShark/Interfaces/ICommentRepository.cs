using FinShark.Models;

namespace FinShark.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllComments();
    Task<Comment?> GetById(int id); 
    Task<Comment> CreateAsync(Comment commentModel);
    Task<Comment?> UpdateAsync(int id, Comment commentModel);
    Task<Comment?> DeleteAsync(int id);
}