using System;
using System.Runtime.Serialization;
using Rehborn.AspNetAutoFacExample.Domain.SeedWork;

namespace Rehborn.AspNetAutoFacExample.Domain
{
    [DataContract]
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

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Text { get; set; }  
    }
}