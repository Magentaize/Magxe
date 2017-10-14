using AutoMapper;
using Magxe.Data;

namespace Magxe.Models.DaoConverters
{
    public class User2AuthorViewModelConverter : ITypeConverter<User, AuthorViewModel>
    {
        public AuthorViewModel Convert(User source, AuthorViewModel dest, ResolutionContext context)
        {
            return new AuthorViewModel()
            {
                bio = source.Bio,
                location = source.Location,
                name = source.Name,
                profile_image = source.ProfileImage,
                url = source.Slug,
            };
        }
    }
}