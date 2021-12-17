using System.Collections.Generic;
using MongoDB.Driver;
using Product.API.Entities;

namespace Product.API.Data
{
    public class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<ProductDTO> itemCollection)
        {
            bool existItem = itemCollection.Find(p => true).Any();
            if (!existItem)
            {
                itemCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<ProductDTO> GetPreconfiguredProducts()
        {
            return new List<ProductDTO>()
            {
                new ProductDTO()
                {
                    Id = "61b3819de878c94250ee4b5b",
                    Name = "IPhone 13 Pro",
                    Description = "Mỗi lần ra mắt phiên bản mới là mỗi lần iPhone chiếm sóng trên khắp các mặt trận và lần này cái tên khiến vô số người “sục sôi” là iPhone 13 Pro, chiếc điện thoại thông minh vẫn giữ nguyên thiết kế cao cấp, cụm 3 camera được nâng cấp, cấu hình mạnh mẽ cùng thời lượng pin lớn ấn tượng.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1639152977/iphone-13-pro-sierra-blue-600x600_hvlnmp.jpg",
                    SalePrice = 9000,
                    Category = "SmartPhone",
                    Brand="Iphone",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61b381a6805299fab3f65a62",
                    Name = "Samsung Galaxy Z Fold3 5G",
                    Description =  "Galaxy Z Fold3 5G, chiếc điện thoại được nâng cấp toàn diện về nhiều mặt, đặc biệt đây là điện thoại màn hình gập đầu tiên trên thế giới có camera ẩn (08/2021). Sản phẩm sẽ là một “cú hit” của Samsung góp phần mang đến những trải nghiệm mới cho người dùng.",
                    ImageFile ="https://res.cloudinary.com/tinnd/image/upload/v1639152685/samsung-galaxy-z-fold-3-silver-1-600x600_gakbq6.jpg",
                    SalePrice = 9000,
                    Category = "SmartPhone",
                    Brand="Samsung",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61b381acebed40d75685eca0",
                    Name = "Samsung Galaxy Z Flip3 5G",
                    Description =  "Nối tiếp thành công của Galaxy Z Flip 5G, trong sự kiện Galaxy Unpacked vừa qua Samsung tiếp tục giới thiệu đến thế giới về Galaxy Z Flip3 5G. Sản phẩm có nhiều cải tiến từ độ bền cho đến hiệu năng và thậm chí nó còn vượt xa hơn mong đợi của mọi người.",
                    ImageFile =  "https://res.cloudinary.com/tinnd/image/upload/v1639152977/samsung-galaxy-z-flip-3-violet-1-600x600_spvzww.jpg",
                    SalePrice = 9000,
                    Category = "SmartPhone",
                    Brand="Samsung",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61b381b6f60a8e418e41bfda",
                    Name = "Samsung Galaxy S21 Ultra 5G",
                    Description = "Sự đẳng cấp được Samsung gửi gắm thông qua chiếc smartphone Galaxy S21 Ultra 5G với hàng loạt sự nâng cấp và cải tiến không chỉ ngoại hình bên ngoài mà còn sức mạnh bên trong, hứa hẹn đáp ứng trọn vẹn nhu cầu ngày càng cao của người dùng.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1639152988/samsung-galaxy-s21-trang-600x600_ic0ohd.jpg",
                    SalePrice = 9000,
                    Category = "SmartPhone",
                    Brand="Samsung",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61b381bfddb1655fc081885d",
                    Name = "Iphone 12 Mini",
                    Description =  "iPhone 12 mini 64 GB tuy là phiên bản thấp nhất trong bộ 4 iPhone 12 series, nhưng vẫn sở hữu những ưu điểm vượt trội về kích thước nhỏ gọn, tiện lợi, hiệu năng đỉnh cao, tính năng sạc nhanh cùng bộ camera chất lượng cao.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1639152976/iphone-12-mini-mau-tim-3-600x600_jdepec.jpg",
                    SalePrice = 9000,
                    Category = "SmartPhone",
                    Brand="Iphone",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61b381c54944257555493659",
                    Name = "Iphone Xr",
                    Description = "Là chiếc điện thoại iPhone có mức giá dễ chịu, phù hợp với nhiều khách hàng hơn, iPhone Xr vẫn được ưu ái trang bị chip Apple A12 mạnh mẽ, màn hình tai thỏ cùng khả năng kháng nước kháng bụi. Màn hình tai thỏ tràn viền công nghệ LCD",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1639153261/iphone-xr-hopmoi-den-600x600-2-600x600_rmth2y.jpg",
                    SalePrice = 9000,
                    Category = "SmartPhone",
                    Brand="Iphone",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61b381cd3c6ea7f7f0a4c4e3",
                    Name = "IphoneSE 2020",
                    Description = "iPhone SE 2020 khi được cho ra mắt đã làm thỏa mãn triệu tín đồ Táo khuyết. Máy sở hữu thiết kế siêu nhỏ gọn như iPhone 8, chip A13 Bionic cho hiệu năng khủng như iPhone 11, nhưng iPhone SE 2020 lại có một mức giá tốt đến bất ngờ.",
                    ImageFile =  "https://res.cloudinary.com/tinnd/image/upload/v1639152977/iphone-se-128gb-2020-do-600x600_tknf8f.jpg",
                    SalePrice = 9000,
                    Category = "SmartPhone",
                    Brand="Iphone",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61b381d659d66f854ec540d8",
                    Name = "Xiaomi 11T 5G",
                    Description = "Xiaomi 11T 5G sở hữu màn hình AMOLED, viên pin siêu khủng cùng camera độ phân giải 108 MP, chiếc smartphone này của Xiaomi sẽ đáp ứng mọi nhu cầu sử dụng của bạn, từ giải trí đến làm việc đều vô cùng mượt mà. ",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1639152977/xiaomi-11t-grey-1-600x600_isdwa6.jpg",
                    SalePrice = 9000,
                    Category = "SmartPhone",
                    Brand="Xiaomi",
                    PurchaseDate=null,
                    NumberOfSale=0
                }
            };
        }
    }
}