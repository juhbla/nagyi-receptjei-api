using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NagyiReceptjei.API.Controllers.Resources.Responses;
using NagyiReceptjei.API.Models;
using NagyiReceptjei.API.Utilities;
using NagyiReceptjei.API.Utilities.Exceptions;

namespace NagyiReceptjei.API.Controllers;

[ApiController]
[EnableCors("DefaultCorsPolicy")]
[Route("api/[controller]/")]
public class PhotosController : ControllerBase
{
    private readonly IWebHostEnvironment _hostEnvironment;
    private readonly PhotoService<IFormFile, Photo> _photoService;
    private readonly IMapper _mapper;

    public PhotosController(
        IWebHostEnvironment hostEnvironment,
        PhotoService<IFormFile, Photo> photoService,
        IMapper mapper
    )
    {
        _hostEnvironment = hostEnvironment;
        _photoService = photoService;
        _mapper = mapper;
    }

    [HttpGet("{fileName}")]
    public async Task<IActionResult> GetPhoto(string fileName)
    {
        try
        {
            var photo = await _photoService.GetPhoto(fileName);

            var contentType = _photoService.GenerateContentType(fileName);

            return File(photo, contentType);
        }
        catch (RecipePhotoNotFoundException notFoundException)
        {
            return NotFound(notFoundException.Message);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpPost("{recipeId:int}")]
    public async Task<IActionResult> UploadPhoto(int recipeId, IFormFile photoToUpload)
    {
        try
        {
            var uploadedPhoto = await _photoService.UploadPhoto(
                _hostEnvironment.ContentRootPath,
                photoToUpload,
                recipeId
            );

            var response = _mapper.Map<Photo, GetPhotoResponse>(uploadedPhoto);

            return Ok(response);
        }
        catch (RecipePhotoNotFoundException notFoundException)
        {
            return NotFound(notFoundException.Message);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}
