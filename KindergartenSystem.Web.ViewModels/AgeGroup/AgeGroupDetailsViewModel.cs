﻿using KindergartenSystem.Web.ViewModels.ClassGroup;
using KindergartenSystem.Web.ViewModels.ClassGroup.Interfaces;

namespace KindergartenSystem.Web.ViewModels.AgeGroup
{
    public class AgeGroupDetailsViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public ICollection<ClassGroupSelectModel> ClassGroups { get; set; }
        public int ClassGroupsCount { get; set; }

        
    }
}
