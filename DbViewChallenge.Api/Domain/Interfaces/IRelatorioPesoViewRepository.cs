namespace DbViewChallenge.Api.Domain.Interfaces
{
    public interface IRelatorioPesoViewRepository
    {
        Task<IEnumerable<RelatorioPesoView>> GetRelatorioPesoViewAsync();
    }
}
