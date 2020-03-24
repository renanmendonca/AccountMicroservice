using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;

namespace Account.Domain.Entities
{
    public abstract class BaseEntity : Notifiable
    {
        public abstract void ValidateProperties();
        public virtual bool Validate()
        {
            ValidateProperties();
            return Valid;
        }
    }
}
