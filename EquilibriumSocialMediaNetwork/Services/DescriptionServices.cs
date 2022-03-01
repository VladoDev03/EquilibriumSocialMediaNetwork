using Data;
using Data.Entities;
using Services.Contracts;
using Services.Mappers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DescriptionServices : IDescriptionServices
    {
        private EquilibriumDbContext db;

        public DescriptionServices(EquilibriumDbContext db)
        {
            this.db = db;
        }

        public DescriptionServiceModel AddDescription(DescriptionServiceModel description)
        {
            db.Descriptions.Add(description.ToDescription());

            db.SaveChanges();

            return description;
        }

        public void DeleteDescription(string id)
        {
            Description description = db.Descriptions.FirstOrDefault(x => x.Id == id);

            db.Remove(description);

            db.SaveChanges();
        }

        public DescriptionServiceModel UpdateDescription(DescriptionServiceModel updatedDescription)
        {
            Description description = db.Descriptions.FirstOrDefault(x => x.Id == updatedDescription.Id);

            if (description.Content != null)
            {
                description.Content = updatedDescription.Content;
                db.SaveChanges();
            }

            return description.ToDescriptionServiceModel();
        }
    }
}
