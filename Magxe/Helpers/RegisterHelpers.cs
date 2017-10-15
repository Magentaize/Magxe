using HandlebarsDotNet.ViewEngine.Abstractions;
using HandlebarsDotNet.ViewEngine.Extensions;

namespace Magxe.Helpers
{
    internal static class Helpers
    {
        public static void RegisterHelpers(IHelperList helpers)
        {
            helpers.Append<AssetHelper>()
                .Append<DateHelper>()
                .Append<ExcerptHelper>()
                .Append<TagsHelper>()
                .Append<BlockHelper>()
                .Append<ContentForHelper>()
                .Append<ForeachHelper>()
                .Append<BodyClassHelper>()
                .Append<NavigationHelper>()
                .Append<UrlHelper>()
                .Append<PostClassHelper>()
                .Append<AuthorHelper>()
                .Append<AuthorBlockHelper>()
                .Append<PostHelper>()
                .Append<EncodeHelper>()
                .Append<ContentHelper>()
                .Append<PluralHelper>()
                .Append<GhostHeadHelper>()
                .Append<GhostFootHelper>()
                .Append<PaginationHelper>()
                .Append<PageUrlHelper>()
                ;
        }
    }
}