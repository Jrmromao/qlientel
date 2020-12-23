using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        [Timestamp]
        public byte[] DateCreated { get; set; }
    }
}