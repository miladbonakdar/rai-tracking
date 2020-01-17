using System;
using SharedKernel.Interfaces;

namespace SharedKernel
{
    public abstract class Entity : IEquatable<Entity> , IEntity
    {
        public Guid Id { get; protected set; }

        protected Entity(Guid id)
        {
            if (Equals(id, default(Guid)))
                throw new ArgumentException("The ID cannot be the type's default value.", "id");
            Id = id;
        }

        protected Entity()
        {
        }

        public override bool Equals(object otherObject) 
            => otherObject is Entity entity ? Equals(entity) : base.Equals(otherObject);

        public override int GetHashCode() => Id.GetHashCode();

        public bool Equals(Entity other) 
            => other != null && Id.Equals(other.Id);
    }
}
