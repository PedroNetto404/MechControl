namespace MechControl.Domain.Core.Primitives;

/// <summary>
/// Represents an auditable entity in the domain.
/// </summary>
/// <typeparam name="TId"> Strong type for the entity's identifier.</typeparam>
public abstract class AuditableEntity<TId> :
    Entity<TId>
    where TId : notnull
{
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }
    public DateTime? DeletedAt { get; protected set; }

    protected AuditableEntity(TId id) : base(id) =>
        CreatedAt = DateTime.UtcNow;

    protected AuditableEntity()
    {
    }

    /// <summary>
    /// Sets the value of a property and updates the <see cref="UpdatedAt"/> property. This method is used in source code generation.
    /// </summary>
    /// <typeparam name="T">Property type.</typeparam>
    /// <param name="field">Property reference.</param>
    /// <param name="value">New property value.</param>
    protected void SetProperty<T>(ref T field, T value)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return;
        field = value;

        OnPropertyChanged();
    }

    /// <summary>
    /// Updates the <see cref="UpdatedAt"/> property.
    /// </summary>
    /// <remarks>This method is used in source code generation.</remarks>
    private void OnPropertyChanged() =>
        UpdatedAt = DateTime.UtcNow;
}

