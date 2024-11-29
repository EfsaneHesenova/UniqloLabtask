using EmployeeMVC.Models.Base;

namespace EmployeeMVC.Models
{
    public class Order: BaseAuditableEntity
    {
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string ClientEmail { get; set; }
        public int ServiceId { get; set; }
        public int EmployeeId { get; set; }
        public string Problem { get; set; }
        public bool IsActive { get; set; }
    }
}
