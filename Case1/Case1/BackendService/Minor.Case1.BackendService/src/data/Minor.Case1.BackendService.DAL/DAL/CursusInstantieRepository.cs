using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Minor.Case1.BackendService.DAL.DatabaseContexts;
using Minor.Case1.BackendService.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace Minor.Case1.BackendService.DAL.DAL
{
    public class CursusInstantieRepository
        : BaseRepository<CursusInstantie, int, DatabaseContext>
    {
        public CursusInstantieRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
        public override IEnumerable<CursusInstantie> FindAll()
        {
            return _context.CursusInstanties.Include(instantie => instantie.Cursus).OrderBy(instantie => instantie.StartDatum);
        }

        public override IEnumerable<CursusInstantie> FindBy(Expression<Func<CursusInstantie, bool>> filter)
        {

            return _context.CursusInstanties.Include(instantie => instantie.Cursus)
                .Where(filter)
                .OrderBy(instantie => instantie.StartDatum);
        }
        protected override DbSet<CursusInstantie> GetDbSet()
        {
            return _context.CursusInstanties;
        }

        protected override int GetKeyFrom(CursusInstantie item)
        {
            return item.Id;
        }

        public override int InsertRange(IEnumerable<CursusInstantie> items)
        {
            int NumberOfSavedChanges = 0;
            foreach (var item in items){                
                var cursus = _context.Cursussen.SingleOrDefault(c => c.Code == item.CursusId);
                if (cursus != null)
                {
                    _context.Attach(cursus);
                }
                if (!_context.CursusInstanties.Any(instantie => instantie.CursusId == item.CursusId && instantie.StartDatum == item.StartDatum))
                {
                    base.Insert(item);
                    NumberOfSavedChanges++;
                }                            
            }
            return NumberOfSavedChanges;
        }
    }
}