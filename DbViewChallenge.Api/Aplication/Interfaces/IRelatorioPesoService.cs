using DbViewChallenge.Api.Domain;

namespace DbViewChallenge.Api.Aplication.Interfaces;

public interface IRelatorioPesoService
{
    Task<IEnumerable<RelatorioPesoView>> GetRelatorioPesoViewAsync();
}