using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Block.Command.CreateBlock
{
    public class CreateBlockDto
    {
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
