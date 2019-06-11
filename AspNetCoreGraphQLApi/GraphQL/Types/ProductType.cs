using AspNetCoreGraphQLApi.Data.Entities;
using AspNetCoreGraphQLApi.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreGraphQLApi.GraphQL.Types
{

    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(ProductReviewRepository reviewRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.Description);
            Field(t => t.IntroducedAt).Description("When the product was first introduced in the catalog");
            Field(t => t.PhotoFileName).Description("The file name of the photo so the client can render it");
            Field(t => t.Price);
            Field(t => t.Rating).Description("The (max 5) star customer rating");
            Field(t => t.Stock);
            Field<ProductTypeEnumType>("Type", "The type of product");

            Field<ListGraphType<ProductReviewType>>(
                 "reviews",
                 resolve: context =>
                 {
                     var loader =
                         dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, ProductReview>(
                             "GetReviewsByProductId", reviewRepository.GetForProducts);
                     return loader.LoadAsync(context.Source.Id);
                 });

            //Field<ListGraphType<ProductReviewType>>(
            //   "reviews",
            //   resolve: context => reviewRepository.GetForProduct(context.Source.Id));
        }
    }
}
