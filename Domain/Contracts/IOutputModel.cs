namespace Domain.Contracts;

public interface IOutputModel<TDto, TEntity>
{
    TDto MapFrom(TEntity entity);
}
