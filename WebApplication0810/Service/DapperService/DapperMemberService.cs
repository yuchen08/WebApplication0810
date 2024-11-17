using System.Data;
using Dapper;
using WebApplication0810.Models.DapperModels;

namespace WebApplication0810.Service.DapperService
{
  
    public class DapperMemberService
    {
        private readonly IDbConnection _dbConnection;

        // Constructor
        public DapperMemberService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // Create a new member
        public void AddMember(DapperMember member)
        {
            string sql = @"INSERT INTO Members (MemberName, Email, Phone, Address, JoinDate, MemberLevel) 
                       VALUES (@MemberName, @Email, @Phone, @Address, @JoinDate, @MemberLevel)";

            _dbConnection.Execute(sql, member);
        }

        // Get a member by ID
        public DapperMember GetMemberById(int memberId)
        {
            string sql = "SELECT * FROM Members WHERE MemberID = @MemberID";
            return _dbConnection.QuerySingleOrDefault<DapperMember>(sql, new { MemberID = memberId });
        }

        // Update a member
        public void UpdateMember(DapperMember member)
        {
            string sql = @"UPDATE Members SET 
                       MemberName = @MemberName, 
                       Email = @Email, 
                       Phone = @Phone, 
                       Address = @Address, 
                       JoinDate = @JoinDate, 
                       MemberLevel = @MemberLevel 
                       WHERE MemberID = @MemberID";

            _dbConnection.Execute(sql, member);
        }

        // Delete a member by ID
        public void DeleteMember(int memberId)
        {
            string sql = "DELETE FROM Members WHERE MemberID = @MemberID";
            _dbConnection.Execute(sql, new { MemberID = memberId });
        }

        // Get all members
        public IEnumerable<DapperMember> GetAllMembers()
        {
            string sql = "SELECT * FROM Members";
            return _dbConnection.Query<DapperMember>(sql);
        }
    }
}
