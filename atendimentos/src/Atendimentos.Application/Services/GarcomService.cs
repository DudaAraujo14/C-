using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atendimentos.Application.DTOs;
using Atendimentos.Domain.Entities;
using Atendimentos.Domain.Repositories;

namespace Atendimentos.Application.Services
{
    public class GarcomService : IGarcomService
    {
        private readonly IGarcomRepository _garcomRepository;

        public GarcomService(IGarcomRepository garcomRepository)
        {
            _garcomRepository = garcomRepository;
        }

        public async Task<IEnumerable<GarcomDto>> ObterTodosAsync()
        {
            var garcons = await _garcomRepository.ObterTodosAsync();
            return garcons.Select(g => new GarcomDto
            {
                Id = g.Id,
                Nome = g.Nome,
                Matricula = g.Matricula,
                Telefone = g.Telefone,
                DataContratacao = g.DataContratacao,
                Ativo = g.Ativo
            });
        }

        public async Task<GarcomDto?> ObterPorIdAsync(Guid id)
        {
            var garcom = await _garcomRepository.ObterPorIdAsync(id);
            if (garcom == null) return null;

            return new GarcomDto
            {
                Id = garcom.Id,
                Nome = garcom.Nome,
                Matricula = garcom.Matricula,
                Telefone = garcom.Telefone,
                DataContratacao = garcom.DataContratacao,
                Ativo = garcom.Ativo
            };
        }

        public async Task<GarcomDto> CriarAsync(GarcomCreateUpdateDto dto)
        {
            var garcom = new Garcom(dto.Nome, dto.Matricula, dto.Telefone);
            await _garcomRepository.CriarAsync(garcom);

            return new GarcomDto
            {
                Id = garcom.Id,
                Nome = garcom.Nome,
                Matricula = garcom.Matricula,
                Telefone = garcom.Telefone,
                DataContratacao = garcom.DataContratacao,
                Ativo = garcom.Ativo
            };
        }

        public async Task<GarcomDto?> AtualizarAsync(Guid id, GarcomCreateUpdateDto dto)
        {
            var garcom = await _garcomRepository.ObterPorIdAsync(id);
            if (garcom == null) return null;

            garcom.Atualizar(dto.Nome, dto.Telefone);
            await _garcomRepository.AtualizarAsync(garcom);

            return new GarcomDto
            {
                Id = garcom.Id,
                Nome = garcom.Nome,
                Matricula = garcom.Matricula,
                Telefone = garcom.Telefone,
                DataContratacao = garcom.DataContratacao,
                Ativo = garcom.Ativo
            };
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            var garcom = await _garcomRepository.ObterPorIdAsync(id);
            if (garcom == null) return false;

            await _garcomRepository.DeletarAsync(id);
            return true;
        }
    }
}
