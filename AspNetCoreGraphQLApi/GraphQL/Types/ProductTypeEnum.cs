using GraphQL.Types;

namespace AspNetCoreGraphQLApi.GraphQL.Types
{
    public class ProductTypeEnumType: EnumerationGraphType<Data.ProductTypeEnum>
    {
        public ProductTypeEnumType()
        {
            Name = "Type";
            Description = "The type of product";
        }
    }
}
