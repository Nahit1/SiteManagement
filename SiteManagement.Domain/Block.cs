using System;
using System.ComponentModel.DataAnnotations;

namespace SiteManagement.Domain
{
    public class Block:BaseEntity
    {
        public Guid Id { get; set; }

        [MaxLength(30)]
        public string Code { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        public Guid SiteId { get; set; }
        public Site Site { get; set; }
    }
}
