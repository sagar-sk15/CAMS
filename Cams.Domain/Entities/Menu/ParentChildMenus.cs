using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities
{
    public class ParentChildMenu:EntityBase<long>
    {
        public ParentChildMenu() 
        {
            //base.Id = Convert.ToInt64(this.ParentMenu.MenuId.ToString() + this.ChildMenu.MenuId.ToString());
        }
        public virtual Menus ParentMenu { get; set; }
        public virtual Menus ChildMenu { get; set; }
        public virtual int MenuOrder { get; set; }

        public override int GetHashCode()
        {
            int hashCode = 0;
            hashCode = hashCode ^ ParentMenu.MenuId.GetHashCode() ^ ChildMenu.MenuId.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            var toCompare = obj as ParentChildMenu;
            if (toCompare == null)
            {
                return false;
            }
            return (this.GetHashCode() != toCompare.GetHashCode());
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
