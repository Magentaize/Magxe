using AutoMapper;
using Magxe.Data;

namespace Magxe.Models.DaoConverters
{
    internal class User2AuthorViewModelConverter : ITypeConverter<User, PostAuthorViewModel>
    {
        public PostAuthorViewModel Convert(User source, PostAuthorViewModel dest, ResolutionContext context)
        {
            return new PostAuthorViewModel()
            {
                bio = source.Bio,
                location = source.Location,
                name = source.Name,
                profile_image = source.ProfileImage,
                slug = source.Slug,
            };
        }
    }
}