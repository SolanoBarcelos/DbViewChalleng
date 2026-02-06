using DbViewChallenge.Api.Aplication.Interfaces;
using DbViewChallenge.Api.Domain;
using DbViewChallenge.Api.Domain.Interfaces;

namespace DbViewChallenge.Api.Aplication.Services;

public class RelatorioPesoService : IRelatorioPesoService
{
    private readonly IRelatorioPesoViewRepository _repository;
    public RelatorioPesoService(IRelatorioPesoViewRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<RelatorioPesoView>> GetRelatorioPesoViewAsync()
    {
        return await _repository.GetRelatorioPesoViewAsync();
    }
}