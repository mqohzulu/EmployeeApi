namespace EmployeeApi.models
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }  = Guid.NewGuid(); 
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public bool active { get; set; }

    }
}
