using FinShark.DTOs.RequestDTO;
using FinShark.Models;
using FinShark.DTOs.ResponseDTO;

namespace FinShark.Mappers;

public static class CommentMapper
{
    public static CommentResponseDto ToCommentDto(this Comment commentModel)
    {
        return new CommentResponseDto
        {
            Id = commentModel.Id,
            Title = commentModel.Title,
            Content = commentModel.Content,
            CreatedOn = commentModel.CreatedOn,
            StockId = commentModel.StockId
        };
    }
    
    public static Comment CreateCommentDto(this CreateCommentRequestDto createCommentRequestDto, int stockId)
    {
        return new Comment
        {
            Title = createCommentRequestDto.Title,
            Content = createCommentRequestDto.Content,
            StockId = stockId
        };
    }
    
    public static Comment UpdateCommentDto(this UpdateCommentRequestDto updateCommentRequestDto)
    {
        return new Comment
        {
            Title = updateCommentRequestDto.Title,
            Content = updateCommentRequestDto.Content
        };
    }
}