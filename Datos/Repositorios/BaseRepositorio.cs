using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using Datos.Contratos;

namespace Datos.Repositorios
{
    public class BaseRepositorio<T> : IBaseRepositorio<T> where T : class
    {
        //PRIMERO
        protected readonly DbContext BaseDatosContexto;
        protected readonly DbSet<T> BaseDatosColeccion;

        //Contructor
        public BaseRepositorio(DbContext contexto)
        {
            BaseDatosContexto = contexto;
            BaseDatosColeccion = contexto.Set<T>();
        }

        public void Actualizar(T entidad)
        {
            BaseDatosColeccion.Attach(entidad);
            BaseDatosContexto.Entry(entidad).State = EntityState.Modified;
            BaseDatosContexto.SaveChanges();
        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> predicado)
        {
            return BaseDatosColeccion.Where(predicado);
        }

        public T BuscarPorId(object identificador)
        {
            try
            {
                return BaseDatosColeccion.Find(identificador);
            }
            catch (Exception ex)
            {

            }
            return BaseDatosColeccion.Find(identificador);
        }

        public IQueryable<T> Consulta()
        {
            return BaseDatosColeccion;
        }

        public void Insertar(T entidad)
        {
            BaseDatosColeccion.Add(entidad);
            BaseDatosContexto.SaveChanges();
        }

        public IList<T> ListarTodos()
        {
            return BaseDatosColeccion.ToList();
        }

        public void Eliminar(object identificador)
        {
            T entidad = this.BuscarPorId(identificador);
            if (entidad != null)
            {
                BaseDatosColeccion.Remove(entidad);
                BaseDatosContexto.SaveChanges();
            }
        }
    }
}
