using System;

namespace ProjectHermes.Db.Contracts
{
    public interface IAuditable
    {
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
