using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class DescriptionServiceModelMapper
    {
        public static DescriptionServiceModel ToDescriptionServiceModel(this Description description)
        {
            DescriptionServiceModel result = new DescriptionServiceModel()
            {
                Id = description.Id,
                Content = description.Content,
                User = description.User,
                UserId = description.UserId
            };

            return result;
        }

        public static Description ToDescription(this DescriptionServiceModel description)
        {
            Description result = new Description()
            {
                Id = description.Id,
                Content = description.Content,
                User = description.User,
                UserId = description.UserId
            };

            return result;
        }
    }
}
