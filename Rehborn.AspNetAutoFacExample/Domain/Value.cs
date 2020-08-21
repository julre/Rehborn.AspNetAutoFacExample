using System;
using System.Runtime.Serialization;
using Rehborn.AspNetAutoFacExample.Domain.SeedWork;

namespace Rehborn.AspNetAutoFacExample.Domain
{
    public class Value : IAggregateRoot
    {
        public static Value Create(string text)
        {
            return new Value(Guid.NewGuid(), text);
        }

        private Value(Guid id, string text)
        {
            Id = id;
            Text = text;
        }

        public Guid Id { get; }

        public string Text { get; }  
    }
}