using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GG.Agro.Core.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ValidationResult ValidationResult { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
