using AutoMapper;
using NagyiReceptjei.API.Controllers.Resources.Requests;
using NagyiReceptjei.API.Controllers.Resources.Responses;
using NagyiReceptjei.API.Models;

namespace NagyiReceptjei.API.Controllers.Resources.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Model to response resource
        CreateMap<Recipe, GetRecipeResponse>()
            .ForMember(getRecipeResponse => getRecipeResponse.PhotoFileName,
                options =>
                    options.MapFrom(recipe => recipe.Photo.FileName)
            );
        CreateMap<Comment, GetCommentResponse>();
        CreateMap<User, GetUserResponse>();
        CreateMap<Ingredient, GetIngredientResponse>();
        CreateMap<Photo, GetPhotoResponse>();

        // Request resource to model
        CreateMap<CreateIngredientRequest, Ingredient>();
        CreateMap<CreateRecipeRequest, Recipe>();
        CreateMap<CreateCommentRequest, Comment>();
        CreateMap<CreateUserRequest, User>();
    }
}
