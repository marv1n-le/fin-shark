using FinShark.Data;
using FinShark.DTOs.RequestDTO;
using FinShark.Interfaces;
using FinShark.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace FinShark.Controllers;
[Route("api/[controller]")]
[ApiController]

public class CommentController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ICommentRepository _commentRepository;
    private readonly IStockRepository _stockRepository;
    
    public CommentController(AppDbContext context, ICommentRepository commentRepository, IStockRepository stockRepository)
    {
        _context = context;
        _commentRepository = commentRepository;
        _stockRepository = stockRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _commentRepository.GetAllComments();
        var commentDtos = comments.Select(x => x.ToCommentDto());
        return Ok(commentDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var comment = await _commentRepository.GetById(id);
        if (comment == null)
            return NotFound();
        return Ok(comment.ToCommentDto());
    }
    
    [HttpPost("{stockId}")]
    public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentRequestDto commentDto)
    {
        var exist = await _stockRepository.ExistAsync(stockId);
        if (!exist)
            return NotFound();
        
        var commentModel = commentDto.CreateCommentDto(stockId);
        await _commentRepository.CreateAsync(commentModel);
        return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateDto)
    {
        var commentModel = await _commentRepository.UpdateAsync(id, updateDto.UpdateCommentDto());
        
        if (commentModel == null)
            return NotFound();
        
        
        return Ok(commentModel);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromBody] int id)
    {
        var comment = await _commentRepository.DeleteAsync(id);
        if (comment == null)
            return NotFound();
        return Ok(comment);
    }
}