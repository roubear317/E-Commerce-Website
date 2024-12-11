using E_commerce.EF.Context;
using E_commerce.EF.SpecificationEvaluator;
using E_Commerce.Core.Services;
using E_Commerce.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.EF.Repos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public Task<T> GetByExpression(Expression<Func<T,bool>> x)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityBySpec(ISpecificExpression<T> spec)
        {
            return await AllowSpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetListOfEntityBySpec(ISpecificExpression<T> spec)
        {
            return await AllowSpecification(spec).ToListAsync();
        }


        private IQueryable<T> AllowSpecification(ISpecificExpression<T> spec)
        {


            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);

        }

    }
}
