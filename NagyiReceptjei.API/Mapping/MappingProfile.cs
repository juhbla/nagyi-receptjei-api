using AutoMapper;
using NagyiReceptjei.API.Models;
using NagyiReceptjei.API.Resources;

namespace NagyiReceptjei.API.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Model to response resource
        CreateMap<Recipe, GetRecipeResponse>();
        CreateMap<Comment, GetCommentResponse>();
        CreateMap<User, GetUserResponse>();
        CreateMap<Ingredient, GetIngredientResponse>();

        // Request resource to model
        CreateMap<CreateIngredientRequest, Ingredient>();
        CreateMap<CreateRecipeRequest, Recipe>();
        CreateMap<CreateCommentRequest, Comment>();
    }
}
