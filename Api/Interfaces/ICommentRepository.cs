using Api.Helpers;
using Api.Models;

namespace Api.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllAsync(CommentQueryObject queryObject);
    Task<Comment?> GetByIdAsync(int id);
    Task<Comment> CreateAsync(Comment comment);
    Task<Comment?> DeleteAsync(int id);
    Task<Comment?> UpdateAsync(int id, Comment comment);
}