namespace LeaveManagementAPI.Interfaces
{
    public interface ILeaveRepo<L,I>
    {
        Task<L> Add(L item);
        Task<L> Remove(I key);
        Task<L> Get(I key);
        Task<List<L>> GetAllByManager(I key);
        Task<List<L>> GetAllByEmp(I key);
        Task<L> Update(L item);
    }
}
