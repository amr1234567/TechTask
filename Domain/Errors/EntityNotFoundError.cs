using FluentResults;

namespace Domain.Errors;

public class EntityNotFoundError(string message) : Error(message)
{
    public static EntityNotFoundError Exists<T>(string id)
    {
        return new EntityNotFoundError($"Entity of type {typeof(T).Name} with id {id} does not exist.");
    }
}
