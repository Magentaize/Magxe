using System;
using AutoMapper;
using Magxe.Data;

namespace Magxe.Models.DaoConverters
{
    internal class User2PostAuthorViewModelConverter : ITypeConverter<User, PostAuthorViewModel>
    {
        public PostAuthorViewModel Convert(User source, PostAuthorViewModel destination, ResolutionContext context)
        {
            if (source == null)
                return new PostAuthorViewModel()
                {
                    bio = string.Empty,
                    location = string.Empty,
                    name = string.Empty,
                    profile_image = null,
                    slug = string.Empty,
                };

            return new PostAuthorViewModel()
            {
                bio = source.Bio,
                location = source.Location,
                name = source.Name,
                profile_image = source.ProfileImage,
                slug = $"/author/{source.Slug}",              
            };
        }
    }
}