using KindergartenSystem.Services.Mapping;
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
            IEnumerable<AllChildrenByGroupViewModel> allChildrenByParent = await _dbContext.Children.Include(x => x.ClassGroup)
                            .Where(x => x.IsKindergartener && x.ParentId.ToString() == parentId)
                                                        .Select(x => new AllChildrenByGroupViewModel
                                                        {
                                                            Id = x.Id.ToString(),
                                                            FirstName = x.FirstName,
                                                            MiddleName = x.MiddleName,
                                                            LastName = x.LastName,
                                                            ClassGroupName = x.ClassGroup.Title,
                                                            Teacher = x.ClassGroup.Teachers.First().Name,
                                                            ParentName = x.Parent.Name,
                                                            ImageUrl = x.ImageUrl,
                                                            IsAttending = x.IsAttending


                                                        }).ToArrayAsync();

            return allChildrenByParent;
        }

        public async Task<IEnumerable<AllChildrenByGroupViewModel>> AllByTeachersAsync(string teacherId)
        {
            var children = await _dbContext.Children.Include(x => x.Parent).Include(x => x.ClassGroup).ThenInclude(x=> x.Teachers)
                .Where(x => x.ClassGroup.Teachers.Any(x => x.Id == Guid.Parse(teacherId))).ToArrayAsync();
            IEnumerable<AllChildrenByGroupViewModel> allChildrenByTeacher = children
                            .Select(x => new AllChildrenByGroupViewModel
                            {
                                Id = x.Id.ToString(),
                                FirstName = x.FirstName,
                                MiddleName = x.MiddleName,
                                LastName = x.LastName,
                                ClassGroupName = x.ClassGroup.Title,
                                Teacher = x.ClassGroup.Teachers.First(x => x.Id.ToString() == teacherId).Name,
                                ParentName = x.Parent.Name,
                                ImageUrl = x.ImageUrl,
                                IsAttending = x.IsAttending


                            });
            return allChildrenByTeacher;
        }

        public async Task<AllChildrenServiceModel> AllChildrenAsync(AllChildrenByGroupQueryModel model)
        {
            IQueryable<Child> childrenQuery = _dbContext.Children.AsQueryable();
           
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
                .Where(x => x.IsKindergartener)
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
                    Teacher = x.ClassGroup.Teachers.First().Name,
                    ImageUrl = x.ImageUrl,
                    IsAttending = x.IsAttending
                }) //.OrderByDescending(x => x.IsAttending)
                .OrderBy(x => x.FirstName)
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
            Child child = AutoMapperConfig.MapperInstance.Map<Child>(model);
            child.ParentId = Guid.Parse(parentId); 

            await _dbContext.Children.AddAsync(child);
            await _dbContext.SaveChangesAsync();

            return child.Id.ToString();
        }

        public async Task DeleteChildAsync(string childId)
        {
            var child = await _dbContext.Children.Where(x => x.IsKindergartener)
                .FirstAsync(x => x.Id.ToString() == childId);
            
            child.IsAttending = false;
            child.IsKindergartener = false;

            await _dbContext.SaveChangesAsync();
        }

        public async Task EditChildInfoAsync(string childId, ChildFormModel model)
        {
            var child = await _dbContext.Children.Include(x => x.Parent)
                .Where(x => x.IsKindergartener).FirstAsync(x => x.Id.ToString() == childId);
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
            bool result = await _dbContext.Children.Where(x => x.IsKindergartener).AnyAsync(x => x.Id.ToString() == id);
            return result;
        }

        public async Task<ChildDetailsViewModel> GetChildDetailsAsync(string childId)
        {
            var child = await _dbContext.Children
                .Include(x => x.Parent)
                .Include(x => x.ClassGroup).ThenInclude(x => x.Teachers)
                .Where(x => x.IsKindergartener && x.Id.ToString() == childId).FirstAsync();


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
                ClassGroupName = child.ClassGroup.Title,
                IsAttending = child.IsAttending
            };
            if (child.ClassGroup.Teachers.Any())
            {
                model.Teacher = child.ClassGroup.Teachers.First().Name;
                model.TeachersPhone = child.ClassGroup.Teachers.FirstOrDefault()?.PhoneNumber;
                model.TeachersEmail = child.ClassGroup.Teachers?.FirstOrDefault()?.EmailAddress;

            }
            return model;

            
        }

        public async Task<ChildFormModel> GetChildForEditAsync(string id)
        {
            var child = await _dbContext.Children
                .Include(x => x.Parent)
           .Include(x => x.ClassGroup).ThenInclude(x => x.Teachers)
           .Where(x => x.IsKindergartener && x.Id.ToString() == id).To<ChildFormModel>()
           .FirstAsync();
            var parent = await _dbContext.Parents.Where(x => x.Children.Any(x => x.Id == Guid.Parse(id))).FirstAsync(); 
            child.ParentPhone = parent.PhoneNumber;
            return child;

            
          
        }

        public async Task<ChildDeleteInfoViewModel> GetDeleteChildInfoAsync(string childId)
        {
            var child = await _dbContext.Children.Where(x => x.IsKindergartener).FirstAsync(x => x.Id.ToString() == childId);

            return new ChildDeleteInfoViewModel
            {
                Name = $"{child.FirstName} {child.LastName}",
                ClassGroup = child.ClassGroup.Title,
                ImageUrl = child.ImageUrl,
            };
        }

        public async Task<bool> IsAttendingAsync(string childId)
        {
            var child = await _dbContext.Children.Where(x => x.IsKindergartener).FirstAsync(x => x.Id.ToString() == childId);
            return child.IsAttending;
            

            
        }
        public async Task<bool> IsTeacherOfTheGroup(string teacherId, string childId)
        {
            Child child = await _dbContext.Children.Where(x =>x.IsKindergartener && x.Id.ToString() == childId).FirstAsync();
            var classs = await _dbContext.ClassGroups.Where(x => x.Teachers.Any(x => x.Id.ToString() == teacherId)).FirstOrDefaultAsync();
            var result = child.ClassGroup == classs;
            return result;
            
        }

        public async Task SetChildAsAttendingToClassAsync(string childId)
        {
            var child = await _dbContext.Children.FirstAsync(x => x.Id.ToString() == childId);
            child.IsAttending = true;
            await _dbContext.SaveChangesAsync();
        }

        public async Task SetChildAsMissingFromClassAsync(string childId)
        {
            var child = await _dbContext.Children.FirstAsync(x => x.Id.ToString() == childId);
            child.IsAttending = false;
            await _dbContext.SaveChangesAsync();
        }
    }

       
        
    
}
