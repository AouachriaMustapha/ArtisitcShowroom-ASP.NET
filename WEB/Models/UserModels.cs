using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class UserModels
    {

        public UserModels()
        {
            this.artworks = new List<artwork>();
            this.bookingpurchasings = new List<bookingpurchasing>();
            this.messages = new List<message>();
            this.messages1 = new List<message>();
            this.mettings = new List<metting>();
            this.mettings1 = new List<metting>();
            this.ratingartists = new List<ratingartist>();
            this.ratingartists1 = new List<ratingartist>();
            this.spaces = new List<space>();
            this.subscriptions = new List<subscription>();
            this.artworks1 = new List<artwork>();
            this.bookingpurchasings1 = new List<bookingpurchasing>();
            this.spaces1 = new List<space>();
            this.specialties = new List<specialty>();
        }

        public string type { get; set; }
        public int id { get; set; }
        public int age { get; set; }
        public string city { get; set; }
        public int confirm { get; set; }
        public string fileUrl { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string login { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public int phone { get; set; }
        public byte[] photo { get; set; }
        public string pictureUrl { get; set; }
        public string postalCode { get; set; }
        public string street { get; set; }
        public string description { get; set; }
        public Nullable<int> experience { get; set; }
        public virtual ICollection<artwork> artworks { get; set; }
        public virtual ICollection<bookingpurchasing> bookingpurchasings { get; set; }
        public virtual ICollection<message> messages { get; set; }
        public virtual ICollection<message> messages1 { get; set; }
        public virtual ICollection<metting> mettings { get; set; }
        public virtual ICollection<metting> mettings1 { get; set; }
        public virtual ICollection<ratingartist> ratingartists { get; set; }
        public virtual ICollection<ratingartist> ratingartists1 { get; set; }
        public virtual ICollection<space> spaces { get; set; }
        public virtual ICollection<subscription> subscriptions { get; set; }
        public virtual ICollection<artwork> artworks1 { get; set; }
        public virtual ICollection<bookingpurchasing> bookingpurchasings1 { get; set; }
        public virtual ICollection<space> spaces1 { get; set; }
        public virtual ICollection<specialty> specialties { get; set; }
    }
}
