using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Comunikime.Application.Contratos;
using Comunikime.Application.Util;
using Comunikime.Domain;
using Comunikime.Persistence.Contratos;

namespace Comunikime.Application
{
    public class ProdutoService : IProdutoService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IProdutoPersistence _produtoPersistence;
        public ProdutoService(IGeralPersistence geralPersistence, IProdutoPersistence produtoPersistence)
        {
            this._produtoPersistence = produtoPersistence;
            this._geralPersistence = geralPersistence;
        }

        public async Task<Produto> AddProduto(Produto model)
        {
            try
            {
                model.DataCriacao = DateTime.Now;
                model.DataAlteracao = DateTime.Now;

                _geralPersistence.Add<Produto>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _produtoPersistence.GetProdutoByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Produto> UpdateProduto(int produtoId, Produto model)
        {
            try
            {
                var produto = await _produtoPersistence.GetProdutoByIdAsync(produtoId);
                if (produto is null) return null;

                model.Id = produto.Id;
                model.DataCriacao = produto.DataCriacao;
                model.DataAlteracao = DateTime.Now;

                _geralPersistence.Update(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _produtoPersistence.GetProdutoByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteProduto(int produtoId)
        {
            try
            {
                var produto = await _produtoPersistence.GetProdutoByIdAsync(produtoId);
                if (produto is null) throw new Exception("Produto não existe para ser deletado.");

                _geralPersistence.Delete(produto);
                return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Produto[]> GetAllProdutosAsync()
        {
            try
            {
                var produtos = await _produtoPersistence.GetAllProdutosAsync();
                if (produtos is null) return null;
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Produto[]> GetAllProdutosByDescricaoAsync(string descricao)
        {
            try
            {
                var produtos = await _produtoPersistence.GetAllProdutosByDescricaoAsync(descricao);
                if (produtos is null) return null;
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Produto> GetProdutoByIdAsync(int produtoId)
        {
            try
            {
                var produto = await _produtoPersistence.GetProdutoByIdAsync(produtoId);
                if (produto is null) return null;
                return produto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}