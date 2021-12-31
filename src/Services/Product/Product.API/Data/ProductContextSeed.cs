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
                    SalePrice = 20000000,
                    Category = "Điện thoại",
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
                    SalePrice = 20000000,
                    Category = "Điện thoại",
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
                    SalePrice = 20000000,
                    Category = "Điện thoại",
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
                    SalePrice = 20000000,
                    Category = "Điện thoại",
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
                    SalePrice = 20000000,
                    Category = "Điện thoại",
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
                    SalePrice = 20000000,
                    Category = "Điện thoại",
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
                    SalePrice = 20000000,
                    Category = "Điện thoại",
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
                    SalePrice = 20000000,
                    Category = "Điện thoại",
                    Brand="Xiaomi",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61ce876cb85f4b5c40c61a89",
                    Name = "MacBook Pro M1",
                    Description = "Laptop Apple Macbook Pro M1 2020 với chip M1 dành riêng cho MacBook đưa hiệu năng của MacBook Pro 2020 lên một tầm cao mới. Màn hình Retina siêu nét, thời lượng pin ấn tượng và hàng loạt các tính năng hiện đại giúp bạn có được trải nghiệm làm việc chuyên nghiệp nhất.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1640927296/1_lzow4s.jpg",
                    SalePrice = 20000000,
                    Category = "Laptop",
                    Brand="Macbook",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61ce8772549e7ab1516772c8",
                    Name = "MacBook Air M1",
                    Description = "Apple MacBook Air M1 2020 với vẻ ngoài hiện đại cùng cấu hình mạnh mẽ vượt trội đến từ con chip M1 được sản xuất trên quy trình tân tiến, là người bạn đồng hành lý tưởng cho bất kỳ ai trong cả những công việc văn phòng hay thiết kế đồ họa.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1640927296/apple-macbook-air-m1-2020-8-core-gpu-vang-1-1-600x600_ohjvar.jpg",
                    SalePrice = 20000000,
                    Category = "Laptop",
                    Brand="Macbook",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61ce877780f7ea54da725090",
                    Name = "Dell Inspiron 7501",
                    Description = "Dell Inspiron 7501 sở hữu thiết kế trẻ trung, hiện đại cùng hiệu năng mạnh mẽ, đáp ứng mượt mà các tác vụ văn phòng đến đồ họa chuyên nghiệp là sản phẩm tuyệt vời dành cho bạn.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1640927296/dell-inspiron-7400-i5-1135g7-16gb-512gb-600x600_ey7ps0.jpg",
                    SalePrice = 20000000,
                    Category = "Laptop",
                    Brand="Dell",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61ce878063a9e498047688f2",
                    Name = "Dell Gaming G15",
                    Description = "Laptop Dell Gaming G15 5515 R5 5600H (P105F004CGR) sở hữu thiết kế tinh tế với sắc xám thời thượng cùng cấu hình được thiết lập đầy mạnh mẽ, luôn trong trạng thái sẵn sàng cùng bạn giải quyết mọi việc.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1640927296/dell-g3-15-i7-p89f002bwh-16-600x600_mei50x.jpg",
                    SalePrice = 20000000,
                    Category = "Laptop",
                    Brand="Dell",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61ce8789ce2fe23536b117bf",
                    Name = "Dell Vostro 5410",
                    Description = "Khí thế mạnh mẽ toát lên bên ngoài của chiếc Dell Vostro 5410 i5 11320H (V4I5214W) sẵn sàng lấn át mọi đối thủ, cùng cấu hình vượt trội bên trong, là vũ khí đắc lực cùng bạn chinh chiến trên mọi mặt trận kể cả công việc hay giải trí.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1640927296/dell-vostro-5410-i5-11320h-8gb-512gb-office-h-s-600x600_rafbk6.jpg",
                    SalePrice = 20000000,
                    Category = "Laptop",
                    Brand="Dell",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61ce878fe9dea707c800f0f1",
                    Name = "Dell Latitude 3520",
                    Description = "Laptop Dell Latitude 3520 i7 (70261780) sở hữu thiết hiện đại thường thấy của các sản phẩm nhà Dell, nhưng mang trong mình cấu hình mạnh mẽ vượt trội, là người trợ thủ đắc lực cho bạn từ công việc đến giải trí.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1640927296/dell-latitude-3520-i7-70261780-091221-022033-600x600_fhaq2x.jpg",
                    SalePrice = 20000000,
                    Category = "Laptop",
                    Brand="Dell",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61ce87924e407ca5b413b337",
                    Name = "MSI Modern 14",
                    Description = "MSI Modern 14 B11MOU i7 (847VN) là một chiếc laptop học tập - văn phòng ở mức giá tầm trung nhưng sở hữu sức mạnh hiệu năng vượt trội đến từ con chip Intel thế hệ 11 hiện đại cùng vẻ ngoài sang trọng, cao cấp, hứa hẹn đáp ứng tốt cho công việc cũng như giải trí hoàn hảo.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1640927296/msi-modern-14-b11mou-i7-847vn-051121-032809-600x600_umzpjt.jpg",
                    SalePrice = 20000000,
                    Category = "Laptop",
                    Brand="MSI",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61ce8799bad173f6f9021410",
                    Name = "MSI Prestige 15",
                    Description = "Trải nghiệm sự đẳng cấp đến từ MSI Prestige 15 A11SC i7 (052VN), một phiên bản laptop cao cấp - sang trọng của nhà MSI khi sở hữu lối thiết kế phong cách, thời thượng, mang đậm tính thời trang cùng sức mạnh bộc phá đáng kinh ngạc, sẽ là một cộng sự lý tưởng trên mọi chiến trường.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1640927296/msi-prestige-15-a11sc-i7-052vn-251121-041159-600x600_cdas28.jpg",
                    SalePrice = 20000000,
                    Category = "Laptop",
                    Brand="MSI",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61ce92e0352177f6ead797c5",
                    Name = "IPad Pro M1",
                    Description = "iPad Pro M1 12.9 inch WiFi Cellular 512GB (2021), một chiếc máy tính bảng cao cấp sở hữu loạt công nghệ đột phá như màn hình mini-LED, mạng 5G, vi xử lý Apple M1 cho hiệu năng xử lý vượt trội vượt khỏi giới hạn.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1640928357/ipad-pro-2021-129-inch-gray-thumb-600x600_vwxf0x.jpg",
                    SalePrice = 20000000,
                    Category = "Máy tính bảng",
                    Brand="IPad",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61ce92e506f9717fcf2b558a",
                    Name = "IPad Air 4",
                    Description = "iPad Air 4 khi được cho ra mắt đã gây ra một cơn sốt cho giới công nghệ toàn cầu, khi sử dụng chipset A14 Bionic với hiệu năng cực khủng, bên cạnh một thiết kế cao cấp và những công nghệ hàng đầu.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1640928358/ipad-air-4-wifi-64gb-2020-xanhla-600x600-600x600_mkvx2l.jpg",
                    SalePrice = 20000000,
                    Category = "Máy tính bảng",
                    Brand="IPad",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61ce92e9bb8b171dd097c976",
                    Name = "Huawei MatePad 11",
                    Description = "MatePad 11 - chiếc máy tính bảng đến từ nhà Huawei với lối thiết kế tối giản nhưng vẫn toát lên vẻ sang trọng, sở hữu trong mình cấu hình mạnh mẽ, màn hình lớn cùng một viên pin trâu có thể đáp ứng được hầu hết các tác vụ làm việc, học tập hay giải trí. ",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1640928357/huawei-matepad-11-9-1-600x600_awfnmw.jpg",
                    SalePrice = 20000000,
                    Category = "Máy tính bảng",
                    Brand="Huawei",
                    PurchaseDate=null,
                    NumberOfSale=0
                },
                new ProductDTO()
                {
                    Id = "61ce92ef952f85a9d5364161",
                    Name = "IPad mini 6",
                    Description = "Sau thời gian dài chờ đợi thì tháng 09/2021 iPad mini 6 WiFi 64GB cũng đã được Apple trình làng với thiết kế vừa quen thuộc vừa mới lạ, máy có nhiều cải tiến trong cấu hình lẫn phần mềm nhằm gia tăng lợi ích sử dụng, mang lại sự hài lòng cao hơn cho người dùng khi lựa chọn.",
                    ImageFile = "https://res.cloudinary.com/tinnd/image/upload/v1640928357/ipad-mini-6-wifi-pink-1-600x600_vsf5kl.jpg",
                    SalePrice = 20000000,
                    Category = "Máy tính bảng",
                    Brand="IPad",
                    PurchaseDate=null,
                    NumberOfSale=0
                }
            };
        }
    }
}