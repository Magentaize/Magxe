using AutoMapper;
using Magxe.Dao;
using Magxe.Models.ControllerViewModels;

namespace Magxe.Models.DaoConverters
{
    internal class User2AuthorControllerViewModel : ITypeConverter<User, AuthorControllerViewModel>
    {
        public AuthorControllerViewModel Convert(User source, AuthorControllerViewModel dest, ResolutionContext context)
        {
            return new AuthorControllerViewModel()
            {
                bio = source.Bio,
                location = source.Location,
                name = source.Name,
                profile_image = source.ProfileImage,
                slug = source.Slug,
                cover_image = source.CoverImage,
            };
        }
    }
}