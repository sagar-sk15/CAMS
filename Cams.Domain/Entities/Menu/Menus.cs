using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities
{
    public class Menus : EntityBase<long>
    {

        public Menus()
        {
            ParentMenus = new List<ParentChildMenu>();
            ParentMenus = new List<ParentChildMenu>();
        }
        public virtual long MenuId { get; set; }
        public virtual IList<ParentChildMenu> ParentMenus { get; set; }
        public virtual IList<ParentChildMenu> ChildMenus { get; set; }
        public virtual string MenuName { get; set; }
        public virtual string MenuDescription { get; set; }
        public virtual bool IsMenuActive { get; set; }
        public virtual bool IsackUser { get; set; }


        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
