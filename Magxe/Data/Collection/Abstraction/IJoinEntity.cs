namespace Magxe.Data.Collection.Abstraction
{
    public interface IJoinEntity<TEntity>
    {
        TEntity Navigation { get; set; }
    }
}