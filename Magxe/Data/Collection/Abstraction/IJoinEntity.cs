namespace Magxe.Data.Collection.Abstraction
{
    internal interface IJoinEntity<TEntity>
    {
        TEntity Navigation { get; set; }
    }
}