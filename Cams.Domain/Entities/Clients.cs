using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities
{
   public class Clients :EntityBase<long>
    {
       public Clients()
       {
       }
       public virtual int CAId { get; set; }

       protected override void Validate()
       {
           throw new NotImplementedException();
       }
    }
}
