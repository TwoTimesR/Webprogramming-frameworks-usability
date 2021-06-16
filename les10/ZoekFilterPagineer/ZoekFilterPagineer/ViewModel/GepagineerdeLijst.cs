using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZoekFilterPagineer.Models;

namespace ZoekFilterPagineer.ViewModel
{
    public class GepagineerdeLijst<T> : List<T>
    {

        public int Pagina { get; private set; }
        public int PaginaAantal { get; private set; }
        public GepagineerdeLijst(List<T> lijstDeel, int totaalAantal, int pagina, int perPagina)
        {
            Pagina = pagina;
            PaginaAantal = (int)Math.Ceiling(totaalAantal / (double)perPagina);
            this.AddRange(lijstDeel);
        }
        public bool HeeftVorige() { return Pagina > 0; }
        public bool HeeftVolgende() { return Pagina < PaginaAantal - 1; }

        public static async Task<GepagineerdeLijst<T>> CreateAsync(
        IQueryable<T> lijst, int pagina, int perPagina)
            {
                return new GepagineerdeLijst<T>(
                    await lijst.Skip(pagina * perPagina).Take(perPagina).ToListAsync(),
                    await lijst.CountAsync(),
                    pagina,
                    perPagina);
            }

        internal static IQueryable<Student> CreateAsync(IQueryable<Student> queryables)
        {
            throw new NotImplementedException();
        }
    }
}
