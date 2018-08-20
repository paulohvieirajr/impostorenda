using ImpostoRenda.Dominio.Interfaces;
using ImpostoRenda.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoRenda.Dominio.Services
{
    public class ServiceBase<T> : IServiceBase<T>
    {
        IRepositorioBase<T> _repositorio;

        public ServiceBase(IRepositorioBase<T> repositorio)
        {
            _repositorio = repositorio;
        }

        public virtual T Get(int id)
        {
            return _repositorio.Get(id);
        }

        public virtual bool Insert(T entity)
        {
            return _repositorio.Insert(entity);
        }

        public virtual bool Update(T entity)
        {
            return _repositorio.Update(entity);
        }

        public virtual bool Delete(int id)
        {
            return _repositorio.Delete(id);
        }

        public virtual bool Exist(int id)
        {
            return _repositorio.Exist(id);
        }
    }
}
