namespace Domain.Contracts;

public interface IInputModel<TEntity>
{
    TEntity MapToModel();
}
