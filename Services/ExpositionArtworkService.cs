using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;

using ServicePattern;
using Domain.Entity;

namespace Services
{
    public class ExpositionArtworkService :  Service<ExpositionArtwork>
    {

        public static DatabaseFactory dbf = new DatabaseFactory();
        public static UnitOfWork utw = new UnitOfWork(dbf);


        public ExpositionArtworkService() : base(utw)
        {
            
        }

        public List<ExpositionArtwork> ExpositionArtworksByIdExposition(int idE)
        {
            return utw.getRepository<ExpositionArtwork>().GetMany().Where(a => a.exposureId == idE).ToList();

        }

        public ExpositionArtwork GetOneExpoByIdExpo(int id)
        {
            var x = utw.getRepository<ExpositionArtwork>().GetMany().Where(a => a.exposureId == id).ToList();
            return x.First();
        }

        public int GetByIdArtworkAndIdExposure(int IdExpo, int IdArt)
        {
            var z = utw.getRepository<ExpositionArtwork>().GetMany().Where(a => a.exposureId == IdExpo).ToList();
            foreach (var f in z)
            {
                if (f.artworkId == IdArt) { 
                    
                    return f.Priority;
                    
                }
                

            }
            return 0;
        }
        public List<ExpositionArtwork> GetArtworksExposition(int id)
        {
            return utw.getRepository<ExpositionArtwork>().GetMany().Where(x => x.exposureId == id).ToList();
        }
    }
}
