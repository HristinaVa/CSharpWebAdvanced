﻿using KindergartenSystem.Web.ViewModels.AgeGroup;
using static KindergartenSystem.Common.GeneralApplicationConstants;

namespace KindergartenSystem.Web.ViewModels.Child
{
    public class AllChildrenByGroupQueryModel
    {
        
        public int? AgeGroup { get; set; }
        public string? ClassGroup { get; set; }
        public string? SearchText { get; set; }
        public int CurrentPage { get; set; } = DefaultPage;
        public int ChildrenPerPage { get; set; } = DefaultChildrenPerPage;
        public int AllChildren { get; set; }
        public IEnumerable<AgeGroupViewModel> AgeGroups { get; set; } = new HashSet<AgeGroupViewModel>();
        public IEnumerable<string> ClassGroups { get; set; } = new HashSet<string>();
        public IEnumerable<AllChildrenByGroupViewModel> Children { get; set; } = new HashSet<AllChildrenByGroupViewModel>();
    }
}
