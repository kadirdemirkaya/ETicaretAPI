﻿using ETicaretAPI.domain.Entites.Base;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.domain.Entites.Identity
{
    public class AppUserRole : IdentityUserRole<Guid> , IEntityBase
    {
    }
}
