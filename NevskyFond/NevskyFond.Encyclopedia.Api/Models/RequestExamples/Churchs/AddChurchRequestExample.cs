﻿using NevskyFond.Encyclopedia.Api.Models.Requests.Churchs;
using Swashbuckle.AspNetCore.Filters;

namespace NevskyFond.Encyclopedia.Api.Models.RequestExamples.Churchs
{
    public class AddChurchRequestExample : IExamplesProvider<AddChurchRequest>
    {
        public AddChurchRequest GetExamples()
        {
            return new AddChurchRequest()
            {
                Name = "Храм Василия Блаженного",
                DateCreation = new DateTime(1561, 12, 1)
            };
        }
    }
}
