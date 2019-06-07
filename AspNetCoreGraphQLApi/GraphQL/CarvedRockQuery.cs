using AspNetCoreGraphQLApi.GraphQL.Types;
using CarvedRock.Api.Repositories;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreGraphQLApi.GraphQL
{
    public class CarvedRockQuery : ObjectGraphType
    {
        public CarvedRockQuery(ProductRepository productRepository)
        {
            Field<ListGraphType<ProductType>>("products", resolve: context => productRepository.GetAll());
        }
    }
}
