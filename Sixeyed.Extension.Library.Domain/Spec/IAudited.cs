namespace Sixeyed.Extension.Library.Domain.Model
{
    public interface IAudited
    {
        Audit Audit { get; set; }
    }
}
