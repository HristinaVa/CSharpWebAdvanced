﻿using KindergartenSystem.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindergartenSystem.Services.Data.Interfaces
{
    public interface IKindergartenService
    {
        Task <IEnumerable<ImageViewModel>> AboutInfoAsync();
    }
}
