namespace KindergartenSystem.Web.ViewModels.AgeGroup
{
    public class AgeGroupViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public ICollection<string> ClassGroupNames { get; set; } = new HashSet<string>();
    }
}
