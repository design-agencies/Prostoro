namespace InteriorHubServer.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IProjectRepository ProjectRepository { get; }
        IAgencyRepository AgencyRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IMessageRepository MessageRepository { get; }
        IDialogRepository DialogRepository { get; }
        ISaveRepository SaveRepository { get; }
        ICityRepository CityRepository { get; }
        Task<bool> SaveAsync();
    }
}
