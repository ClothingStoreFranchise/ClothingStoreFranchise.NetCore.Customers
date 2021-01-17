using ClothingStoreFranchise.NetCore.Common.Constants;
using ClothingStoreFranchise.NetCore.Common.Types;

namespace ClothingStoreFranchise.NetCore.Customers.Dto
{
    public class CartProductDto : CartProductBaseDto, IEntityDto<long>
    {
        public long Id { get; set; }

        public string Name { get; private set; }

        public decimal UnitPrice { get; set; }

        public string PictureUrl { get; set; }

        public long Stock { get; set; }

        public ClothingSizeType ClothingSizeType { get; set; }

        public long Key() => Id;
    }
}
