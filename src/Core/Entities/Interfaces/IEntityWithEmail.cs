namespace Core.Entities.Interfaces;

public interface IEntityWithEmail : IEntity
{
    string Email { get; set; }
}
