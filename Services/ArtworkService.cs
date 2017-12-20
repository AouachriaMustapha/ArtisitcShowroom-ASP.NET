
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Data.Models;
using Domain;
using ServicePattern;
using Domain.Entity;

namespace Services
{
    public class ArtworkService : Service<artwork>

    {
       
        public static DatabaseFactory dbf = new DatabaseFactory();
        public static UnitOfWork utw = new UnitOfWork(dbf);

        private ExpositionArtworkService service = null;
        public ArtworkService() : base(utw)
        {
            service = new ExpositionArtworkService();
        }

        public List<artwork> GetArtworkByIdArtist(int id)
        {
            var x = GetMany();
            List<artwork> ArtworksById = new List<artwork>();



            //foreach (var Ar in x)
            //{
            //    if (Ar.artist_id==id)
            //    {
            //        ArtworksById.Add(Ar);
            //    }
            //}
            return utw.getRepository<artwork>().GetMany().Where(a => a.artist_id == id).ToList();

        }

        public List<artwork> ArtworkByIdArtwork(int id)
        {
            
            var ExpositionsAxpositionArtworksByIdExposition = service.ExpositionArtworksByIdExposition(id);


            List<artwork> artworkByIdArtwork = new List<artwork>();
            foreach (var Expo in ExpositionsAxpositionArtworksByIdExposition)
            {
                artwork ar = new artwork();
                ar = utw.getRepository<artwork>().GetById(Expo.artworkId);
                artworkByIdArtwork.Add(ar);

            }
            return artworkByIdArtwork;
        } 

    }
}
