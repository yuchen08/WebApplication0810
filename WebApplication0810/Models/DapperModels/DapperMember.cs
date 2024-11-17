namespace WebApplication0810.Models.DapperModels
{
    public class DapperMember
    {
        public int MemberID { get; set; } // Unchecked, required
        public string MemberName { get; set; } // nvarchar(100), Unchecked, required
        public string Email { get; set; } // nvarchar(100), Unchecked, required
        public string? Phone { get; set; } // nvarchar(15), Checked, optional
        public string? Address { get; set; } // nvarchar(255), Checked, optional
        public DateTime? JoinDate { get; set; } // datetime, Checked, optional
        public string MemberLevel { get; set; } // nvarchar(50), Unchecked, required

        public DapperMember()
        {   
        }
    }
}
