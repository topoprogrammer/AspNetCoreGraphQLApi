﻿using AspNetCoreGraphQLApi.Data.Entities;
using GraphQL.Types;

namespace AspNetCoreGraphQLApi.GraphQL.Types
{
    public class ProductReviewType: ObjectGraphType<ProductReview>
    {
        public ProductReviewType()
        {
            Field(t => t.Id);
            Field(t => t.Title);
            Field(t => t.Review);
        }
    }
}
