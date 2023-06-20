using System;
using System.Collections.Generic;
using System.Text;

namespace AkademiPlusMikroServiceProje.Shared.Services
{
    public interface ISharedIdentityService
    {
        public string GetUserID { get; }
    }
}
