using KindergartenSystem.Data;
using KindergartenSystem.Data.Models;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Services.Data.Models.Child;
using KindergartenSystem.Web.ViewModels.Child;
using Microsoft.EntityFrameworkCore;
using static KindergartenSystem.Common.EntityValidationConstants.ChildConst;


namespace KindergartenSystem.Services.Data
{
    public class ChildService : IChildService
    {
        private readonly KindergartenDbContext _dbContext;
        public ChildService(KindergartenDbContext dbContext)
        {
            _dbContext = dbContext;   
        }

        public async Task<IEnumerable<AllChildrenByGroupViewModel>> AllByParentsAsync(string parentId)
        {
            IEnumerable<AllChildrenByGroupViewModel> allChildrenByParent = await _dbContext.Children
                            .Where(x => x.ParentId.ToString() == parentId)
                            .Select(x => new AllChildrenByGroupViewModel
                            {
                                Id = x.Id.ToString(),
                                FirstName = x.FirstName,
                                MiddleName = x.MiddleName,
                                LastName = x.LastName,
                                ClassGroupName = x.ClassGroup.Title,
                                Teacher = x.ClassGroup.Teachers.FirstOrDefault().Name,
                                ParentName = x.Parent.Name,
                                ImageUrl = x.ImageUrl


                            }).ToArrayAsync();
            return allChildrenByParent;
        }

        public async Task<IEnumerable<AllChildrenByGroupViewModel>> AllByTeachersAsync(string teacherId)
        {
            IEnumerable<AllChildrenByGroupViewModel> allChildrenByTeacher = await _dbContext.Children
                            .Where(x => x.ClassGroup.Teachers.FirstOrDefault().Id.ToString() == teacherId)
                            .Select(x => new AllChildrenByGroupViewModel
                            {
                                Id = x.Id.ToString(),
                                FirstName = x.FirstName,
                                MiddleName = x.MiddleName,
                                LastName = x.LastName,
                                ClassGroupName = x.ClassGroup.Title,
                                Teacher = x.ClassGroup.Teachers.FirstOrDefault().Name,
                                ParentName = x.Parent.Name,
                                ImageUrl = x.ImageUrl


                            }).ToArrayAsync();
            return allChildrenByTeacher;
        }

        public async Task<AllChildrenServiceModel> AllChildrenAsync(AllChildrenByGroupQueryModel model)
        {
            IQueryable<Child> childrenQuery = _dbContext.Children.AsQueryable();
            //if (model.AgeGroups != null)
            //{
            //    childrenQuery = childrenQuery.Where(x => x.ClassGroup.Title == model.ClassGroup);


            //}
            if (!string.IsNullOrWhiteSpace(model.ClassGroup))
            {
                childrenQuery = childrenQuery.Where(x => x.ClassGroup.Title == model.ClassGroup);
            }

            if (!string.IsNullOrWhiteSpace(model.SearchText))
            {
                var wildCard = $"%{model.SearchText.ToLower()}%";
                childrenQuery = childrenQuery.Where
                    (x => EF.Functions.Like(x.FirstName, wildCard) ||
                EF.Functions.Like(x.MiddleName, wildCard) ||
                EF.Functions.Like(x.LastName, wildCard) ||
                EF.Functions.Like(x.ClassGroup.Title, wildCard) ||
                EF.Functions.Like(x.ClassGroup.Teachers.First().Name, wildCard) ||
                EF.Functions.Like(x.Parent.Name, wildCard));
            }
            IEnumerable<AllChildrenByGroupViewModel> allChildren = await childrenQuery
                .Skip((model.CurrentPage - 1) * model.ChildrenPerPage)
                .Take(model.ChildrenPerPage)
                .Select(x => new AllChildrenByGroupViewModel()
                {
                    Id = x.Id.ToString(),
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    ParentName = x.Parent.Name,
                    ClassGroupName = x.ClassGroup.Title,
                    Teacher = x.ClassGroup.Teachers.FirstOrDefault().Name,
                    ImageUrl = x.ImageUrl
                }).OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToArrayAsync();
            int childrenTotal = childrenQuery.Count();

            return new AllChildrenServiceModel()
            {
                AllChilderenCount = childrenTotal,
                Children = allChildren
            };
        }


        public async Task<string> CreateChildAsync(ChildFormModel model, string parentId)
        {
            Child child = new Child()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                DateOfBirth = DateTime.UtcNow,
                ImageUrl = model.ImageUrl,
                ParentId = Guid.Parse(parentId),
                ClassGroupId = model.ClassGroupId
            };

            await _dbContext.Children.AddAsync(child);
            await _dbContext.SaveChangesAsync();

            return child.Id.ToString();
        }

        public async Task EditChildInfoAsync(string childId, ChildFormModel model)
        {
            var child = await _dbContext.Children.Include(x => x.Parent).FirstAsync(x => x.Id.ToString() == childId);
            child.FirstName = model.FirstName;
            child.MiddleName = model.MiddleName;
            child.LastName = model.LastName;
            child.DateOfBirth = model.DateOfBirth;
            child.ImageUrl = model.ImageUrl;
            child.Parent.PhoneNumber = model.ParentPhone;
            child.ClassGroupId = model.ClassGroupId;

            await _dbContext.SaveChangesAsync();


        }

        public async Task<bool> ExistsById(string id)
        {
            bool result = await _dbContext.Children.AnyAsync(x => x.Id.ToString() == id);
            return result;
        }

        public async Task<ChildDetailsViewModel> GetChildDetailsAsync(string childId)
        {
            Child child = await _dbContext.Children
                .Include(x => x.Parent)
.Include(x => x.ClassGroup).ThenInclude(x => x.Teachers).
Where(x => x.Id.ToString() == childId).FirstAsync();

            
            ChildDetailsViewModel model = new ChildDetailsViewModel
            {
                Id = child.Id.ToString(),
                FirstName = child.FirstName,
                MiddleName = child.MiddleName,
                LastName = child.LastName,
                DateOfBirth = child.DateOfBirth.ToString(DateOfBirthFormat),
                ImageUrl = child.ImageUrl,
                ParentName = child.Parent.Name,
                ParentPhone = child.Parent.PhoneNumber,
                ParentEmail = child.Parent.EmailAddress,
                ClassGroupName = child.ClassGroup.Title
            };
            if (child.ClassGroup.Teachers.Any())
            {
                model.Teacher = child.ClassGroup.Teachers.FirstOrDefault().Name;
                model.TeachersPhone = child.ClassGroup.Teachers.FirstOrDefault()?.PhoneNumber;
                model.TeachersEmail = child.ClassGroup.Teachers?.FirstOrDefault()?.EmailAddress;

            }
            return model;

            
        }

        public async Task<ChildFormModel> GetChildForEditAsync(string id)
        {
            Child child = await _dbContext.Children
                .Include(x => x.Parent)
           .Include(x => x.ClassGroup).ThenInclude(x => x.Teachers)
           .Where(x => x.Id.ToString() == id)
           .FirstAsync();

            return new ChildFormModel
            {
                FirstName = child.FirstName,
                MiddleName = child.MiddleName,
                LastName = child.LastName,
                DateOfBirth = child.DateOfBirth,
                ImageUrl = child.ImageUrl,
                ParentPhone = child.Parent.PhoneNumber,
                ClassGroupId = child.ClassGroupId
                
            };
          
        }

        public async Task<bool> IsTeacherOfTheGroup(string teacherId, string childId)
        {
            Child child = await _dbContext.Children.Where(x => x.Id.ToString() == childId).FirstAsync();
            var classs = await _dbContext.ClassGroups.Where(x => x.Teachers.Any(x => x.Id.ToString() == teacherId)).FirstOrDefaultAsync();
            var result = child.ClassGroup == classs;
            return result;
            
        }
    }

       
        
    
}
