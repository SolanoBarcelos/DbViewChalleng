using Dapper;
using DbViewChallenge.Api.Domain;
using DbViewChallenge.Api.Domain.Interfaces;
using DbViewChallenge.Api.Infrastructure.Context;

namespace DbViewChallenge.Api.Infrastructure.Repositories;

public class RelatorioPesoViewRepository : IRelatorioPesoViewRepository
{
    private readonly DBcontext _context;
    public RelatorioPesoViewRepository(DBcontext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RelatorioPesoView>> GetRelatorioPesoViewAsync()
    {
        const string sql = @"
            SELECT 
                chapa_type_name AS ChapaTypeName,
                peso_espessura AS PesoEspessura
            FROM v_descricao_peso";

        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<RelatorioPesoView>(sql);
    }
}