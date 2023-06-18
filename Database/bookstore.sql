-- MySQL dump 10.13  Distrib 8.0.29, for Win64 (x86_64)
--
-- Host: localhost    Database: bookstore
-- ------------------------------------------------------
-- Server version	8.0.29

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `books`
--

DROP TABLE IF EXISTS `books`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `books` (
  `book_id` int NOT NULL AUTO_INCREMENT,
  `category_id` int NOT NULL,
  `book_name` varchar(100) NOT NULL,
  `author_name` varchar(45) NOT NULL,
  `book_price` decimal(10,0) NOT NULL,
  `book_description` varchar(500) NOT NULL,
  `book_quantity` int NOT NULL,
  PRIMARY KEY (`book_id`),
  KEY `category_id` (`category_id`),
  CONSTRAINT `books_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `categorys` (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `books`
--

LOCK TABLES `books` WRITE;
/*!40000 ALTER TABLE `books` DISABLE KEYS */;
INSERT INTO `books` VALUES (1,1,'Nhà Giả Kim','Paulo Coelho',55000,'Tiểu thuyết Nhà giả kim của Paulo Coelho như một câu chuyện cổ tích giản dị, nhân ái, giàu chất thơ, thấm đẫm những minh triết huyền bí của phương Đông.',94),(2,1,'Cây Cam Ngọt Của Tôi','José Mauro de Vasconcelos',75600,'Mở đầu bằng những thanh âm trong sáng và kết thúc lắng lại trong những nốt trầm hoài niệm, Cây cam ngọt của tôi khiến ta nhận ra vẻ đẹp thực sự của cuộc sống đến từ những điều giản dị như bông hoa trắng của cái cây sau nhà, và rằng cuộc đời thật khốn khổ nếu thiếu đi lòng yêu thương và niềm trắc ẩn.',100),(3,1,'Bước Chậm Lại Giữa Thế Gian Vội Vã','Hae Min',59500,'Chen vai thích cánh để có một chỗ bám trên xe buýt giờ đi làm, nhích từng xentimét bánh xe trên đường lúc tan sở, quay cuồng với thi cử và tiến độ công việc, lu bù vướng mắc trong những mối quan hệ cả thân lẫn sơ… bạn có luôn cảm thấy thế gian xung quanh mình đang xoay chuyển quá vội vàng?',100),(4,1,'Những Đêm Không Ngủ Những Ngày Chậm Trôi','A Crazy Mind',81000,'Cuốn sách là tập hợp những câu chuyện có thật của những số phận khác nhau đang gặp phải các vấn đề về tâm lý: trầm cảm, rối loạn lo âu, rối loạn lưỡng cực… và những người đang học tập và làm việc trong ngành tâm lý học. ',99),(5,1,'Cho Tôi Xin Một Vé Đi Tuổi Thơ','Nguyễn Nhật Ánh',76000,'Trong Cho tôi xin một vé đi tuổi thơ, nhà văn Nguyễn Nhật Ánh mời người đọc lên chuyến tàu quay ngược trở lại thăm tuổi thơ và tình bạn dễ thương của 4 bạn nhỏ. Những trò chơi dễ thương thời bé, tính cách thật thà, thẳng thắn một cách thông minh và dại dột, những ước mơ tự do trong lòng… khiến cuốn sách có thể làm các bậc phụ huynh lo lắng rồi thở phào.',96),(6,2,'Tài Chính Cá Nhân Dành Cho Người Việt Nam','Lâm Minh Chánh',190000,'Bắt đầu từ những bài viết trên CafeBiz, CafeF, TheBank, Chuyện thương trường và trang cá nhân về các dự án đầu tư lừa đảo, cách tính lãi suất, những công cụ đầu tư, cách quản lý các quỹ tài chính cá nhân… tôi phát hiện ra nhiều người Việt còn thiếu kiến thức về tài chính cá nhân. Từ đó, tôi đã tự gán cho mình sứ mệnh “Góp phần phổ biến và nâng cao kiến thức tài chính cá nhân của người Việt”.',100),(7,2,'How Money Works - Hiểu Hết Về Tiền','DK',210000,'How money works – Hiểu hết về tiền tìm hiểu cách thức các chính phủ kiểm soát tiền tệ, cách các công ty kiếm ra tiền, cách các thị trường tài chính vận hành, cách các cá nhân tối đa hóa thu nhập thông qua đầu tư…',100),(8,2,'13 Nguyên Tắc Nghĩ Giàu Làm Giàu - Think And Grow Rich','Napoleon Hill',104000,'Think and grow rich – 13 nguyên tắc nghĩ giàu, làm giàu là cuốn sách “chỉ dẫn” duy nhất chỉ ra những nguồn lực bạn phải có để thành công. Mỗi chương trong cuốn sách đều đề cập đến bí quyết kiếm tiền, từ việc có niềm tin, có mong muốn đến những kiến thức chuyên sâu, những ý tưởng, những kế hoạch, những cách đưa ra quyết định.',100),(9,2,'Đầu Tư Tài Chính','Nhiều Tác Giả',626000,'Quyển sách Đầu Tư Tài Chính sẽ cung cấp cho bạn đầy đủ kiến thức, để từ đó bạn có thể bắt đầu chọn cho mình một triết lí riêng về đầu tư, bài viết dưới đây Warren Buffetcho thấy tại sao ông là một nhà đầu tư tài chính vĩ đại, vì ông nắm rất rõ những kiến thức tài chính, rõ đến từng khái niệm đơn giản và từ đó phát triển thành các chiến lược đầu tư bậc thầy.',100),(10,2,'Nhà Đầu Tư Thông Minh','Benjamin Graham',139300,'Là nhà tư vấn đầu tư vĩ đại nhất của thế kỷ 20, Benjamin Graham đã giảng dạy và truyền cảm hứng cho nhiều người trên khắp thế giới. Triết lý “đầu tư theo giá trị“ của Graham, bảo vệ nhà đầu tư khỏi những sai lầm lớn và dạy anh ta phát triển các chiến lược dài hạn, đã khiến Nhà đầu tư thông minh trở thành cẩm nang của thị trường chứng khoán kể từ lần xuất bản đầu tiên vào năm 1949.',90),(11,3,'Thay Đổi Cuộc Sống Với Nhân Số Học','Lê Đỗ Quỳnh Hương',161000,'Nhân số học là một môn nghiên cứu sự tương quan giữa những con số trong ngày sinh, cái tên với cuộc sống, vận mệnh, đường đời và tính cách của mỗi người. Bộ môn này đã được nhà toán học Pythagoras khởi xướng cách đây 2.600 năm và sau này được nhiều thế hệ học trò liên tục kế thừa, phát triển. ',89),(12,3,'Thần Số Học: Thấu Hiểu Nhân Tâm','Tống Khánh Thượng',79000,'Thần số học là một môn khoa học thần bí phương Tây, có lịch sự lâu đời, chuyên nghiên cứu về các con số để đưa ra những nghiên cứu, phân tích, dự đoán. Các con số gắn liền với bạn đều ẩn chứa những thông điệp, thể hiện một điều gì đó trong cuộc sống của bạn.',100),(13,3,'Thiên Tài Bên Trái, Kẻ Điên Bên Phải','Cao Minh',125000,'Thiên tài bên trái, kẻ điên bên phải là cuốn sách dành cho những người điên rồ, những kẻ gây rối, những người chống đối, những mảnh ghép hình tròn trong những ô vuông không vừa vặn… những người nhìn mọi thứ khác biệt, không quan tâm đến quy tắc.',100),(14,3,'Bộ Sách Tâm Lý Học Tội Phạm (Bộ 2 Tập)','Stanton E Samenow',187000,'Tâm lý học tội phạm là bộ sách gồm 2 tập đề cập đến quyền lựa chọn, ý chí tự do, cái thiện và cái ác, phản ứng trước cám dỗ và sự thể hiện lòng dũng cảm hay hèn nhát khi đối mặt với nghịch cảnh của con người.',100),(15,3,'Trí Tuệ Xúc Cảm','Daniel Goleman',139000,'Trí Tuệ Xúc Cảm đã nằm trong danh sách bán chạy nhất của Thời báo New York trong một năm rưỡi, với hơn 5.000.000 bản in trên toàn thế giới bằng 40 ngôn ngữ và đã là sách bán chạy nhất ở nhiều quốc gia. Sách đã được Tạp chí TIME vinh danh là một trong 25 “Cuốn sách quản lý kinh doanh có ảnh hưởng nhất” ',100),(16,4,'Đọc Vị Mọi Vấn Đề Của Trẻ','Tracy Hogg, Melinda Blau',189000,'Trong cuốn sách này, tôi muốn giúp bạn, xoa dịu nỗi sợ của bạn và chỉ cho bạn cách tự tạo cho mình sức mạnh của một người làm cha mẹ. Tôi muốn dạy cho bạn những gì tôi đã học được từ công việc cả đời thì thầm với trẻ cũng như trả lời những câu hỏi mà bạn đặt ra cho tôi.',100),(17,4,'Để Con Được Ốm','Nguyễn Trí Đoàn, Uyên Bùi',114000,'“Để con được ốm cần có sự kiên nhẫn giải thích hay thuyết phục của bác sĩ cùng sự thông hiểu và hợp tác từ phía gia đình bé. Đôi khi, sự hợp tác và hiểu biết của phụ huynh còn quan trọng hơn nỗ lực (hay thời gian) của bác sĩ giải thích nữa.',100),(18,4,'Hiểu Biết Của Mẹ, Sức Khỏe Của Con','Ký Liên Mai',141000,'“Hiểu biết của mẹ sức khỏe của con” được viết bởi Thạc sĩ, bác sĩ tài năng Ký Liên Mai. Cô từng làm việc tại bệnh viện Bắc Kinh, phòng khám Walmart New Jersey của Mỹ và có gần 20 năm kinh nghiệm làm việc lâm sàng. Cô còn là một trong mười người có sức ảnh hưởng lớn tại Trung Quốc về vấn đề sức khỏe.',100),(19,4,'Chào Con! Ba Mẹ Đã Sẵn Sàng','BS Trần Thị Huyên Thảo',90000,'Chắc chắn bạn cũng sẽ cảm nhận được những điểm hay và thực tế trong quyển sách này, từ nền tảng khoa học vững chắc cho đến kiến thức chăm sóc trẻ mới nhất, và nhất là phù hợp với hoàn cảnh của Việt Nam.',100),(20,4,'Nuôi Con Không Phải Là Cuộc Chiến','Bubu Hương, Mẹ Ong Bông, Hachun Lyonnet',94000,'Nuôi con không phải là cuộc chiến: Cuốn sách không là cẩm nang để bé ăn nhiều tăng cân nhanh hay dạy bé nghe lời răm rắp, mà giúp bạn hiểu con mình hơn. Giúp bạn hiểu chu kỳ sinh học của con và cách phối kết hợp cuộc sống gia đình với chu kỳ sinh học đó của bé.',100),(21,5,'Hoàng Tử Bé','Antoine De Saint-Exupéry',52500,'Hoàng tử bé được viết ở New York trong những ngày tác giả sống lưu vong và được xuất bản lần đầu tiên tại New York vào năm 1943, rồi đến năm 1946 mới được xuất bản tại Pháp. Không nghi ngờ gì, đây là tác phẩm nổi tiếng nhất, được đọc nhiều nhất và cũng được yêu mến nhất của Saint-Exupéry.',100),(22,5,'Tôi Vẽ - Phương Pháp Tự Học Vẽ Truyện Tranh','Nhiều tác giả',68000,'“Tôi vẽ với 300 trang sách bao gồm những kỹ năng cơ bản cần có của một họa sĩ truyện tranh, từ tạo hình nhân vật, thiết kế bối cảnh, biểu cảm, các kỹ thuật diễn họa cho đến luật phối cảnh. Đây là một cuốn cẩm nang tuyệt vời dành cho các bạn đang bắt đầu học vẽ truyện tranh.',100),(23,5,'Dế Mèn Phiêu Lưu Ký','Tô Hoài',47000,'\"Trong hơn nửa thế kỉ, kể từ ngày ra mắt bạn đọc lần đầu tiên năm 1941, \"\"Dế Mèn phiêu lưu ký\"\" là tác phẩm văn học thiếu nhi Việt Nam nổi tiếng nhất và được dịch ra hơn 20 thứ tiếng trên thế giới. Tác phẩm được chuyển thể nhiều hình thức khác nhau và luôn được các thế hệ độc giả hào hứng đón nhận.\"',100),(24,5,'Sinh Vật Thần Thoại Khắp Thế Gian','Epic',63000,'Châu Âu cổ kính, châu Phi hoang dã, châu Á kì bí, Trung Đông huyền diệu, “Tân lục địa” chứa đầy bí ẩn bất ngờ… những nền văn minh ở khắp các châu lục tồn tại nhiều nghìn năm, phát triển rực rỡ và để lại di sản thần thoại phong phú, với vô vàn sinh vật huyền bí cùng các tích truyện li kì.',100),(25,5,'300 Miếng Bóc Dán Thông Minh - Rèn Luyện Ngôn Ngữ','Ưu Ưu Thử',28000,'\"3-6 tuổi là giai đoạn bộ não của trẻ phát triển nhanh nhất để có thể nhận thức được màu sắc, hình khối, đồ vật, phát triển mạnh mẽ về cả ngôn ngữ, tư duy logic và khả năng sáng tạo... Cũng bởi thế mà trẻ cần có những \"\"công cụ\"\" phù hợp để có thể nâng cao được toàn diện những kỹ năng của mình.\"',100),(26,6,'Khi Hơi Thở Hóa Thinh Không','Paul Kalanithi',76000,'Khi hơi thở hóa thinh không là tự truyện của một bác sĩ bị mắc bệnh ung thư phổi. Trong cuốn sách này, tác giả đã chia sẻ những trải nghiệm từ khi mới bắt đầu học ngành y, tiếp xúc với bệnh nhân cho tới khi phát hiện ra mình bị ung thư và phải điều trị lâu dài.',100),(27,6,'Thời Khắc Tươi Đẹp','Nina Riggs',122850,'Một cuốn hồi ký tuyệt vời về sự sống và cái chết, từ nhà thơ Nina Riggs, mẹ của hai đứa con trai và hậu duệ trực hệ của tác gia Ralph Waldo Emerson. ',100),(28,6,'Tôi Phải Sống','Dư Phương Liên',142000,'“Dù có chuyện gì đi nữa, thế gian này vẫn mở cho bạn một con đường” - Dư Phương Liên',100),(29,6,'Nhắm Mắt Nhìn Sao','Hà Chương',100640,'Hà Chương là một nhạc sĩ, ca sĩ khiếm thị đầu tiên của Việt Nam phát hành abum riêng. Anh được khán giả yêu nhạc nhớ đến với những ca khúc như Áo Dài Cuối Phố, Nắng Hát, Bạn Tôi, Xin Cảm Ơn Em, Không Ngại Ngần,... Với giai điệu gần gũi, bắt tai và một phong cách âm nhạc trẻ trung hiện đại, Hà Chương chính là hiện thân của một thế hệ nghệ sĩ trẻ đa năng trong làng nhạc Việt.',100),(30,6,'Tay Trắng Đổi Lấy Bình Minh','Minh Lady',237000,'Cuốn sách không chỉ là câu chuyện làm giàu từ tay trắng. Nó còn là hành trình lột xác của cô gái yếu đuối trở thành nữ hoàng đứng trên đỉnh vinh quang. Dù chẳng có hoàng tử mang cho giày pha lê, vẫn có thể dựng xây một đế chế. Những chia sẻ từ tác giả Minh Lady giúp nhiều chị em phụ nữ có thêm tự tin, ý chí và nghị lực sống, vào ước mơ của mình',100),(31,7,'Tổng Ôn Ngữ Pháp Tiếng Anh','Trang Anh',189000,'Đầy đủ nhất với 30 CHUYÊN ĐỀ NGỮ PHÁP Trong Tiếng Anh của cô Trang Anh.',100),(32,7,'500 Bài Tập Vật Lí THCS','Phan Hoàng Văn',99000,'Cuốn sách 500 Bài Tập Vật Lí THCS là tài liệu tham khảo cần thiết cho những học sinh muốn tìm hiểu kĩ về môn khoa học thú vị này. Đây là tài liệu dùng để ôn tập, chuẩn bị cho các kì thi học sinh giỏi, tuyển sinh vào các trường chuyên.',100),(33,7,'Sổ Tay Kiến Thức Ngữ Văn Trung Học Cơ Sở','Nguyễn Thanh Lâm, Nguyễn Tú Phương',46750,'Cuốn Sổ tay kiến thức Ngữ văn Trung học cơ sở được biên soạn nhằm hệ thống lại toàn bộ những kiến thức Ngữ văn trong chương trình Trung học cơ sở – giai đoạn nền tảng của chương trình phổ thông.',100),(34,7,'500 Bài Tập Toán Chọn Lọc 6 Cơ Bản Và Nâng Cao','Nhiều Tác Giả',47000,'Nhằm bổ trợ thêm các bài toán cho các em học sinh lớp 6 luyện tập trong quá trình học Toán theo chương trình giáo dục phổ thông mới ban hành kèm theo Thông tư số 32/2018/TT-BGDĐT của Bộ trưởng Bộ Giáo dục và Đào tạo có hiệu lực và thực hiện ngay từ năm học 20212022 đôi với lớp 6, chúng tôi biên soạn quyển “500 bài tập Toán chọn lọc 6” với mục tiêu đáp ứng yêu cầu theo chủ trương một chương trình với nhiều bộ sách giáo khoa tùy chọn.',100),(35,7,'Rèn Luyện Tư Duy Trong Hóa Học Lớp 8','Nhiều Tác Giả',152000,'Cuốn sách giúp các bạn học sinh cũng cố lại các kiến thức cần nhớ, học được những kỹ thuật giải nhanh, đặc sắc, đồng thời đúc kết được nhiều kinh nghiệm cho kỳ thi sắp tới. Chúc các bạn thành công !',100),(36,8,'Giải Thích Ngữ Pháp Tiếng Anh','Mai Lan Hương, Hà Thanh Uyên',143000,'Ngữ pháp Tiếng Anh tổng hợp các chủ điểm ngữ pháp trọng yếu mà học sinh cần nắm vững. Các chủ điểm ngữ pháp được trình bày rõ ràng, chi tiết. Sau mỗi chủ điểm ngữ pháp là phần bài tập & đáp án nhằm giúp các em củng cố kiến thức đã học, đồng thời tự kiểm tra kết quả.',100),(37,8,'Mind Map English Vocabulary','Hoàng Ngân, Linh Chi',158400,'Toàn bộ kiến thức từ vựng Tiếng Anh được thiết kế dưới dạng Sơ đồ tư duy – Mind map, kết hợp với hình ảnh sinh động, giải thích cách sử dụng qua những từ khóa chính giúp bạn ghi nhớ nhanh và hiệu quả hơn.',100),(38,8,'Mindmap English Grammar','Đỗ Nhung',152000,'Trước đây, khi tiếng Anh chưa là ngôn ngữ quốc tế trong môi trường toàn cầu hóa, xu hướng việc giảng dạy và học tập tiếng Anh tại Việt Nam thiên về hai kỹ năng ĐỌC HIỂU và VIẾT. Hệ quả là trong các thế hệ trước, nhiều người đọc hiểu và viết tiếng Anh thông thạo không kém người bản xứ được học hành tử tế; ngược lại, gặp khó khăn khi giao tiếp nghe-nói bằng tiếng Anh.',100),(39,8,'Giao Tiếp Tiếng Anh Thật Dễ Dàng','Đỗ Nhung',178200,'Ở đây, tôi không nói là bạn sai hay đúng, vì đó là suy nghĩ của bạn. Có bao giờ bạn tự đặt câu hỏi rằng “Khi mình mới sinh ra thì tiếng Việt cũng là một ngoại ngữ, nhưng tại sao bây giờ mình có thể đọc và nói tiếng Việt rất thành thạo?”.',100),(40,8,'Step-By-Step English','ML Thanisa Choombala',213120,'Được biên soạn theo phương pháp này, quyển Step-by-Step English – Từng bước hoàn thiện kỹ năng nói và viết tiếng Anh sẽ giúp bạn hình thành khả năng giao tiếp qua từng bước.',100);
/*!40000 ALTER TABLE `books` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categorys`
--

DROP TABLE IF EXISTS `categorys`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categorys` (
  `category_id` int NOT NULL AUTO_INCREMENT,
  `category_name` varchar(45) NOT NULL,
  PRIMARY KEY (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorys`
--

LOCK TABLES `categorys` WRITE;
/*!40000 ALTER TABLE `categorys` DISABLE KEYS */;
INSERT INTO `categorys` VALUES (1,'Văn Học'),(2,'Kinh Tế'),(3,'Tâm Lý - Kỹ Năng Sống'),(4,'Nuôi Dạy Con'),(5,'Sách Thiếu Nhi'),(6,'Tiểu Sử - Hồi Ký'),(7,'Sách Giáo Khoa'),(8,'Sách Học Ngoại Ngữ');
/*!40000 ALTER TABLE `categorys` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customers` (
  `customer_id` int NOT NULL AUTO_INCREMENT,
  `customer_name` varchar(45) NOT NULL,
  `customer_phone` varchar(10) NOT NULL,
  PRIMARY KEY (`customer_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (1,'lalala','0942878948'),(2,'tatata','0334426854'),(3,'lionel messi','0987654321'),(4,'Nguyen Cao Truong Uy','0983203771'),(5,'Do Trung Quan','0862497801'),(6,'Do Trung Quan','0772248304');
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_details`
--

DROP TABLE IF EXISTS `order_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_details` (
  `order_id` int NOT NULL,
  `book_id` int NOT NULL,
  `quantity` int NOT NULL,
  `unit_price` decimal(10,0) NOT NULL,
  PRIMARY KEY (`order_id`,`book_id`),
  KEY `book_id` (`book_id`),
  CONSTRAINT `order_details_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`),
  CONSTRAINT `order_details_ibfk_2` FOREIGN KEY (`book_id`) REFERENCES `books` (`book_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_details`
--

LOCK TABLES `order_details` WRITE;
/*!40000 ALTER TABLE `order_details` DISABLE KEYS */;
INSERT INTO `order_details` VALUES (1,1,1,55000),(2,10,10,1393000),(2,11,11,1771000),(3,1,1,55000),(3,4,1,81000),(4,1,3,165000),(5,1,1,55000),(8,5,2,152000),(9,5,3,228000),(10,5,2,152000);
/*!40000 ALTER TABLE `order_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `order_id` int NOT NULL AUTO_INCREMENT,
  `staff_id` int NOT NULL,
  `customer_id` int NOT NULL,
  `order_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `order_status` int NOT NULL,
  PRIMARY KEY (`order_id`),
  KEY `staff_id` (`staff_id`),
  KEY `customer_id` (`customer_id`),
  CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`staff_id`) REFERENCES `staffs` (`staff_id`),
  CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,1,1,'2023-04-18 16:05:51',2),(2,1,2,'2023-04-21 23:11:33',2),(3,1,3,'2023-04-22 15:16:11',2),(4,1,4,'2023-05-17 00:29:24',2),(5,1,3,'2023-05-19 10:19:01',1),(8,1,5,'2023-05-30 22:49:58',2),(9,1,5,'2023-05-30 23:03:00',3),(10,1,6,'2023-05-30 23:07:28',2);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staffs`
--

DROP TABLE IF EXISTS `staffs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `staffs` (
  `staff_id` int NOT NULL AUTO_INCREMENT,
  `staff_name` varchar(45) NOT NULL,
  `staff_role` int NOT NULL,
  `staff_username` varchar(45) NOT NULL,
  `staff_password` varchar(45) NOT NULL,
  PRIMARY KEY (`staff_id`),
  UNIQUE KEY `staff_username` (`staff_username`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staffs`
--

LOCK TABLES `staffs` WRITE;
/*!40000 ALTER TABLE `staffs` DISABLE KEYS */;
INSERT INTO `staffs` VALUES (1,'Uy (Seller)',1,'seller123','1e4970ada8c054474cda889490de3421'),(2,'Uy (Accountant)',2,'accountant123','599ebb620b4a5e14c6da3d4a4e0991e5');
/*!40000 ALTER TABLE `staffs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'bookstore'
--
/*!50003 DROP PROCEDURE IF EXISTS `sp_getAllBook` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getAllBook`()
BEGIN
	select books.book_id, books.book_name, books.author_name, books.book_price, books.book_description, books.book_quantity, categorys.category_name 
    from books 
    inner join categorys on books.category_id = categorys.category_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getBookByBookName` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getBookByBookName`(bookName varchar(45))
BEGIN
	select books.book_id, books.book_name, books.author_name, books.book_price, books.book_description, books.book_quantity, categorys.category_name 
    from books 
    inner join categorys on books.category_id = categorys.category_id 
    where books.book_name like concat('%', bookName, '%');
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getBookByCategoryName` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getBookByCategoryName`(categoryName varchar(45))
BEGIN
	select books.book_id, books.book_name, books.author_name, books.book_price, books.book_description, books.book_quantity, categorys.category_name 
    from books 
    inner join categorys on books.category_id = categorys.category_id 
    where categorys.category_name like concat('%', categoryName, '%');
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getBookById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getBookById`(bookId int)
BEGIN
	select * 
    from books 
    inner join categorys on books.category_id = categorys.category_id 
    where books.book_id = bookId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getOrderById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getOrderById`(orderId int)
BEGIN
	select orders.order_id, orders.order_date, orders.order_status, 
    order_details.unit_price, order_details.quantity,
    books.book_name, books.book_price, books.book_id,
    staffs.staff_name, 
    customers.customer_name, customers.customer_phone  
    from orders 
    inner join order_details on orders.order_id = order_details.order_id
    inner join books on order_details.book_id = books.book_id
    inner join staffs on orders.staff_id = staffs.staff_id 
    inner join customers on orders.customer_id = customers.customer_id 
    where orders.order_id = orderId
    order by orders.order_id asc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getPaidOrders` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getPaidOrders`()
BEGIN
	select orders.order_id, orders.order_date, orders.order_status, 
    order_details.unit_price, order_details.quantity,
    books.book_name, books.book_price, books.book_id,
    staffs.staff_name, 
    customers.customer_name, customers.customer_phone
    from orders 
    inner join order_details on orders.order_id = order_details.order_id
    inner join books on order_details.book_id = books.book_id
    inner join staffs on orders.staff_id = staffs.staff_id 
    inner join customers on orders.customer_id = customers.customer_id 
    where orders.order_status = 2
    order by orders.order_id asc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getPaidOrdersInDay` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getPaidOrdersInDay`()
BEGIN
	select orders.order_id, orders.order_date, orders.order_status, 
    order_details.unit_price, order_details.quantity,
    books.book_name, books.book_price, books.book_id,
    staffs.staff_name, 
    customers.customer_name, customers.customer_phone
    from orders 
    inner join order_details on orders.order_id = order_details.order_id
    inner join books on order_details.book_id = books.book_id
    inner join staffs on orders.staff_id = staffs.staff_id 
    inner join customers on orders.customer_id = customers.customer_id 
    where orders.order_status = 2 
    order by orders.order_id asc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getUnpaidOrders` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getUnpaidOrders`()
BEGIN
	select orders.order_id, orders.order_date, orders.order_status, 
    order_details.unit_price, order_details.quantity,
    books.book_name, books.book_price, books.book_id,
    staffs.staff_name, 
    customers.customer_name, customers.customer_phone  
    from orders 
    inner join order_details on orders.order_id = order_details.order_id
    inner join books on order_details.book_id = books.book_id
    inner join staffs on orders.staff_id = staffs.staff_id 
    inner join customers on orders.customer_id = customers.customer_id 
    where orders.order_status = 1 and day(order_date) + month(order_date) + year(order_date) = day(current_date()) + month(current_date()) + year(current_date())
    order by orders.order_id asc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getUnpaidOrdersInDay` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getUnpaidOrdersInDay`()
BEGIN
	select orders.order_id, orders.order_date, orders.order_status, 
    order_details.unit_price, order_details.quantity,
    books.book_name, books.book_price, books.book_id,
    staffs.staff_name, 
    customers.customer_name, customers.customer_phone  
    from orders 
    inner join order_details on orders.order_id = order_details.order_id
    inner join books on order_details.book_id = books.book_id
    inner join staffs on orders.staff_id = staffs.staff_id 
    inner join customers on orders.customer_id = customers.customer_id 
    where orders.order_status = 1 and day(order_date) + month(order_date) + year(order_date) = day(current_date()) + month(current_date()) + year(current_date())
    order by orders.order_id asc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_login` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_login`(username varchar(45), password varchar(45))
BEGIN
	select * from staffs where staff_username = username and staff_password = password;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-16 21:08:28
