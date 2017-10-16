namespace Magxe.Views.Abstractions
{
    internal interface IPagination
    {
        int prev { get; set; }
        int page { get; set; }
        int pages { get; set; }
        int next { get; set; }
    }
}