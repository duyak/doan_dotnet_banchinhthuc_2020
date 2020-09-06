/*
 Navicat Premium Data Transfer

 Source Server         : Mysql
 Source Server Type    : MySQL
 Source Server Version : 100411
 Source Host           : localhost:3306
 Source Schema         : dotnetstorephone2

 Target Server Type    : MySQL
 Target Server Version : 100411
 File Encoding         : 65001

 Date: 03/09/2020 23:47:19
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for auth
-- ----------------------------
DROP TABLE IF EXISTS `auth`;
CREATE TABLE `auth`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `roleId` int NOT NULL,
  `menuId` int NOT NULL,
  `Permission` int NOT NULL DEFAULT 1,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `authId_MenuId_fk`(`menuId`) USING BTREE,
  INDEX `authId_RoleId_fk`(`roleId`) USING BTREE,
  CONSTRAINT `authId_MenuId_fk` FOREIGN KEY (`menuId`) REFERENCES `menu` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `authId_RoleId_fk` FOREIGN KEY (`roleId`) REFERENCES `role` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of auth
-- ----------------------------

-- ----------------------------
-- Table structure for brand
-- ----------------------------
DROP TABLE IF EXISTS `brand`;
CREATE TABLE `brand`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `logo` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `code` int NULL DEFAULT NULL,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 19 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of brand
-- ----------------------------
INSERT INTO `brand` VALUES (4, 'SamSung', 'Image/logo134.jpg', NULL, 1, '2020-09-03 21:57:30', '2020-09-03 21:57:30');
INSERT INTO `brand` VALUES (7, 'Opplo', 'Image/logo146.jpg', NULL, 1, '2020-09-03 22:17:17', '2020-09-03 22:17:17');
INSERT INTO `brand` VALUES (8, 'Huawei', 'Image/logo135.jpg', NULL, 1, '2020-09-03 22:17:24', '2020-09-03 22:17:24');
INSERT INTO `brand` VALUES (9, 'Apple', 'Image/logo133.jpg', NULL, 1, '2020-09-03 22:17:45', '2020-09-03 22:17:45');
INSERT INTO `brand` VALUES (10, 'Xiaomi', 'Image/logo136.jpg', NULL, 1, '2020-09-03 22:18:00', '2020-09-03 22:18:00');
INSERT INTO `brand` VALUES (11, 'OnePlus', 'Image/logo137.jpg', NULL, 1, '2020-09-03 22:18:56', '2020-09-03 22:18:56');
INSERT INTO `brand` VALUES (12, 'Vinmart', 'Image/logo138.jpg', NULL, 1, '2020-09-03 22:19:11', '2020-09-03 22:19:11');
INSERT INTO `brand` VALUES (13, 'LG', 'Image/logo139.jpg', NULL, 1, '2020-09-03 22:19:23', '2020-09-03 22:19:23');
INSERT INTO `brand` VALUES (14, 'Dell', 'Image/logo140.jpg', NULL, 1, '2020-09-03 22:19:34', '2020-09-03 22:19:34');
INSERT INTO `brand` VALUES (15, 'Lenovo', 'Image/logo141.jpg', NULL, 1, '2020-09-03 22:19:46', '2020-09-03 22:19:46');
INSERT INTO `brand` VALUES (16, 'Asus', 'Image/logo142.jpg', NULL, 1, '2020-09-03 22:19:58', '2020-09-03 22:19:58');
INSERT INTO `brand` VALUES (17, 'Acer', 'Image/logo143.jpg', NULL, 1, '2020-09-03 22:20:10', '2020-09-03 22:20:10');
INSERT INTO `brand` VALUES (18, 'HP', 'Image/logo144.jpg', NULL, 1, '2020-09-03 22:20:22', '2020-09-03 22:20:22');

-- ----------------------------
-- Table structure for category
-- ----------------------------
DROP TABLE IF EXISTS `category`;
CREATE TABLE `category`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `parentId` int NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `parentId`(`parentId`) USING BTREE,
  CONSTRAINT `category_ibfk_1` FOREIGN KEY (`parentId`) REFERENCES `category` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 8 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of category
-- ----------------------------
INSERT INTO `category` VALUES (1, 'Điện thoại', '', '', 1, '2020-08-02 19:23:07', '2020-08-02 19:23:07', NULL);
INSERT INTO `category` VALUES (2, 'Phụ kiện', '', '', 1, '2020-08-31 21:11:22', '2020-08-31 21:11:22', NULL);
INSERT INTO `category` VALUES (3, 'Samsung', '', '', 1, '2020-08-31 21:12:08', '2020-08-31 21:12:08', 1);
INSERT INTO `category` VALUES (4, 'Apple', '', '', 1, '2020-08-31 21:12:42', '2020-08-31 21:12:42', 1);
INSERT INTO `category` VALUES (5, 'Cáp sạc', '', '', 1, '2020-09-01 16:37:57', '2020-09-01 16:37:57', 2);
INSERT INTO `category` VALUES (6, 'Tai nghe', 'TN', 'Tai nghe', 1, '2020-09-03 22:32:50', '2020-09-03 22:32:50', 2);
INSERT INTO `category` VALUES (7, 'Laptop', '', '', 1, '2020-09-03 22:57:00', '2020-09-03 22:57:00', NULL);

-- ----------------------------
-- Table structure for color
-- ----------------------------
DROP TABLE IF EXISTS `color`;
CREATE TABLE `color`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of color
-- ----------------------------
INSERT INTO `color` VALUES (1, 'Gold', 1, '2020-08-02 00:24:41', '2020-08-02 00:24:41');
INSERT INTO `color` VALUES (2, 'Xanh lá', 1, '2020-08-02 14:33:56', '2020-08-02 14:33:56');
INSERT INTO `color` VALUES (3, 'Đen', 1, '2020-09-01 16:42:45', '2020-09-01 16:42:45');
INSERT INTO `color` VALUES (4, 'Trắng', 1, '2020-09-01 16:42:45', '2020-09-01 16:42:45');
INSERT INTO `color` VALUES (5, 'Bạc', 1, '2020-09-01 16:43:04', '2020-09-01 16:43:04');

-- ----------------------------
-- Table structure for comment
-- ----------------------------
DROP TABLE IF EXISTS `comment`;
CREATE TABLE `comment`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `userId` int NULL DEFAULT NULL,
  `productId` int NOT NULL,
  `fullname` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `content` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `reply` int NULL DEFAULT NULL,
  `parent` int NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `comment_user_fk`(`userId`) USING BTREE,
  INDEX `comment_product_fk`(`productId`) USING BTREE,
  INDEX `parent`(`parent`) USING BTREE,
  CONSTRAINT `comment_ibfk_1` FOREIGN KEY (`parent`) REFERENCES `comment` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `comment_product_fk` FOREIGN KEY (`productId`) REFERENCES `product` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `comment_user_fk` FOREIGN KEY (`userId`) REFERENCES `users` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of comment
-- ----------------------------

-- ----------------------------
-- Table structure for discount
-- ----------------------------
DROP TABLE IF EXISTS `discount`;
CREATE TABLE `discount`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `productId` int NOT NULL,
  `startDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `endDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `percentage` int NOT NULL,
  `status` int NOT NULL,
  `activeFlag` int NOT NULL,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `discountId_productId_fk`(`productId`) USING BTREE,
  CONSTRAINT `discountId_productId_fk` FOREIGN KEY (`productId`) REFERENCES `product` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of discount
-- ----------------------------

-- ----------------------------
-- Table structure for importproduct
-- ----------------------------
DROP TABLE IF EXISTS `importproduct`;
CREATE TABLE `importproduct`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `supplierId` int NOT NULL,
  `productId` int NOT NULL,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `importId_supplierid_fk`(`supplierId`) USING BTREE,
  INDEX `importId_productd_fk`(`productId`) USING BTREE,
  CONSTRAINT `importId_productd_fk` FOREIGN KEY (`productId`) REFERENCES `product` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `importId_supplierid_fk` FOREIGN KEY (`supplierId`) REFERENCES `supplier` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of importproduct
-- ----------------------------

-- ----------------------------
-- Table structure for importproductdetail
-- ----------------------------
DROP TABLE IF EXISTS `importproductdetail`;
CREATE TABLE `importproductdetail`  (
  `importProductId` int NOT NULL,
  `productDetailId` int NOT NULL,
  `price` decimal(10, 0) NOT NULL,
  `quantity` int NOT NULL,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`importProductId`, `productDetailId`) USING BTREE,
  INDEX `improDetail_productDetail_fk`(`productDetailId`) USING BTREE,
  CONSTRAINT `improDetail_import_fk` FOREIGN KEY (`importProductId`) REFERENCES `importproduct` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `improDetail_productDetail_fk` FOREIGN KEY (`productDetailId`) REFERENCES `productdetail` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of importproductdetail
-- ----------------------------

-- ----------------------------
-- Table structure for menu
-- ----------------------------
DROP TABLE IF EXISTS `menu`;
CREATE TABLE `menu`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `parentId` int NOT NULL,
  `url` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `orderIndex` int NOT NULL DEFAULT 0,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of menu
-- ----------------------------

-- ----------------------------
-- Table structure for order
-- ----------------------------
DROP TABLE IF EXISTS `order`;
CREATE TABLE `order`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `userId` int NULL DEFAULT NULL,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `phoneNumber` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `address` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `payment` int NOT NULL,
  `quantity` int NOT NULL,
  `amount` decimal(10, 0) NULL DEFAULT NULL,
  `status` int NULL DEFAULT NULL,
  `activeFlag` int NULL DEFAULT 1,
  `createDate` timestamp(0) NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `oderId_UsersId_fk`(`userId`) USING BTREE,
  CONSTRAINT `oderId_UsersId_fk` FOREIGN KEY (`userId`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 13 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of order
-- ----------------------------
INSERT INTO `order` VALUES (2, NULL, 'dfs', '34543545', 'dfsdfsdfsd', 0, 1, 34345435, 0, 1, '2020-09-02 04:56:40', '2020-09-02 04:56:40');
INSERT INTO `order` VALUES (4, NULL, 'long', '0545345345', 'KTX Khu B,Đại Học Quốc Gia TP HCM', 1, 3, 22440000, 0, NULL, NULL, NULL);
INSERT INTO `order` VALUES (5, NULL, 'man', '0545345345', 'KTX Khu B,Đại Học Quốc Gia TP HCM', 1, 2, 23000000, 0, 1, '0000-00-00 00:00:00', '0000-00-00 00:00:00');
INSERT INTO `order` VALUES (6, NULL, 'cong man', '0545345345', 'KTX Khu B,Đại Học Quốc Gia TP HCM', 1, 3, 22290000, 0, 1, '2020-09-02 15:39:07', '2020-09-02 15:39:07');
INSERT INTO `order` VALUES (7, NULL, 'fdsf', '0545345345', 'KTX Khu B,Đại Học Quốc Gia TP HCM', 1, 2, 11290000, 0, 1, '2020-09-02 16:21:16', '2020-09-02 16:21:16');
INSERT INTO `order` VALUES (8, NULL, 'đf', '0545345345', 'KTX Khu B,Đại Học Quốc Gia TP HCM', 0, 2, 11290000, 0, 1, '2020-09-02 16:39:45', '2020-09-02 16:39:45');
INSERT INTO `order` VALUES (9, NULL, 'fsdf', '0545345345', 'KTX Khu B,Đại Học Quốc Gia TP HCM', 2, 2, 23000000, 0, 1, '2020-09-02 17:00:02', '2020-09-02 17:00:02');
INSERT INTO `order` VALUES (10, NULL, 'ndhhdfdf', '0545345345', 'KTX Khu B,Đại Học Quốc Gia TP HCM', 2, 3, 22290000, 0, 1, '2020-09-03 12:50:03', '2020-09-03 12:50:03');
INSERT INTO `order` VALUES (11, NULL, 'fdsf', '0545345345', 'KTX Khu B,Đại Học Quốc Gia TP HCM', 2, 2, 27590000, 0, 1, '2020-09-03 12:57:59', '2020-09-03 12:57:59');
INSERT INTO `order` VALUES (12, NULL, 'Trương Công Mẫn', '01201201302', 'Củ chi', 2, 1, 12000000, 0, 1, '2020-09-03 16:24:44', '2020-09-03 16:24:44');

-- ----------------------------
-- Table structure for orderdetail
-- ----------------------------
DROP TABLE IF EXISTS `orderdetail`;
CREATE TABLE `orderdetail`  (
  `orderId` int NOT NULL,
  `productDetailId` int NOT NULL,
  `quanlity` int NOT NULL,
  `price` decimal(10, 0) NOT NULL,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`orderId`, `productDetailId`) USING BTREE,
  INDEX `orderDetail_ProductDetailId_fk`(`productDetailId`) USING BTREE,
  CONSTRAINT `orderDetail_ProductDetailId_fk` FOREIGN KEY (`productDetailId`) REFERENCES `productdetail` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `orderDetail_oderId_fk` FOREIGN KEY (`orderId`) REFERENCES `order` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of orderdetail
-- ----------------------------

-- ----------------------------
-- Table structure for product
-- ----------------------------
DROP TABLE IF EXISTS `product`;
CREATE TABLE `product`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `categoryId` int NOT NULL,
  `brandId` int NOT NULL,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `imgMain` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `productId_BrandId_fk`(`brandId`) USING BTREE,
  INDEX `product_category_fk`(`categoryId`) USING BTREE,
  CONSTRAINT `productId_BrandId_fk` FOREIGN KEY (`brandId`) REFERENCES `brand` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `product_category_fk` FOREIGN KEY (`categoryId`) REFERENCES `category` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 18 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of product
-- ----------------------------
INSERT INTO `product` VALUES (9, 1, 4, 'Samsung Galaxy Note 20', 'SSN20', '', 'Image/product/200-note-20-3-180x125.png', 1, '2020-09-03 23:01:51', '2020-09-03 23:01:51');
INSERT INTO `product` VALUES (10, 1, 12, 'Vsmart Active 3 ', 'VA3', '', 'Image/product/vsmart-active-3-6gb-purple-ruby-400x460-1-400x460.png', 1, '2020-09-03 23:03:12', '2020-09-03 23:03:12');
INSERT INTO `product` VALUES (11, 1, 12, 'Vsmart Joy 3', 'VJ3', '', 'Image/product/vsmart-joy-3-tim-400x460-400x460.png', 1, '2020-09-03 23:03:36', '2020-09-03 23:03:36');
INSERT INTO `product` VALUES (12, 1, 9, 'iPhone 11 Pro Max', 'IP11PM', '', 'Image/product/iphone-11-pro-max-black-400x460.png', 1, '2020-09-03 23:05:11', '2020-09-03 23:05:11');
INSERT INTO `product` VALUES (13, 1, 9, 'iPhone 11 ', 'IP11', '', 'Image/product/iphone-11-256gb-black-400x460.png', 1, '2020-09-03 23:05:31', '2020-09-03 23:05:31');
INSERT INTO `product` VALUES (14, 1, 9, 'iPhone 8 Plus ', 'IP8L', '', 'Image/product/iphone-8-plus-128gb-082720-052722-400x460.png', 1, '2020-09-03 23:05:51', '2020-09-03 23:05:51');
INSERT INTO `product` VALUES (15, 7, 14, 'Dell Inspiron 3493 ', 'N4I5122WA', '', 'Image/product/dell-inspiron-3493-i5-n4i5122w-222088-600x600.jpg', 1, '2020-09-03 23:06:30', '2020-09-03 23:06:30');
INSERT INTO `product` VALUES (16, 7, 14, 'Dell Vostro 5490', 'V4I5106W', '', 'Image/product/dell-vostro-5490-i5-10210u-8gb-256gb-win10-v4i510-9-213861-600x600.jpg', 1, '2020-09-03 23:07:03', '2020-09-03 23:07:03');
INSERT INTO `product` VALUES (17, 7, 16, 'Asus VivoBook X509JA', 'EJ480T', '', 'Image/product/asus-vivobook-x509ja-i3-ej480t-225608-600x600.jpg', 1, '2020-09-03 23:07:29', '2020-09-03 23:07:29');

-- ----------------------------
-- Table structure for product_voucher
-- ----------------------------
DROP TABLE IF EXISTS `product_voucher`;
CREATE TABLE `product_voucher`  (
  `productId` int NOT NULL,
  `voucherId` int NOT NULL,
  PRIMARY KEY (`productId`, `voucherId`) USING BTREE,
  INDEX `voucher_productVoucher`(`voucherId`) USING BTREE,
  CONSTRAINT `product_productVoucher` FOREIGN KEY (`productId`) REFERENCES `product` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `voucher_productVoucher` FOREIGN KEY (`voucherId`) REFERENCES `voucher` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of product_voucher
-- ----------------------------

-- ----------------------------
-- Table structure for productdetail
-- ----------------------------
DROP TABLE IF EXISTS `productdetail`;
CREATE TABLE `productdetail`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `productId` int NOT NULL,
  `specId` int NOT NULL,
  `colorId` int NOT NULL,
  `price` decimal(10, 0) NOT NULL,
  `imgUrl` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `productDetailId_colorId_fk`(`colorId`) USING BTREE,
  INDEX `productDetailId_productId_fk`(`productId`) USING BTREE,
  INDEX `proDetail_spec_fk`(`specId`) USING BTREE,
  CONSTRAINT `proDetail_spec_fk` FOREIGN KEY (`specId`) REFERENCES `spec` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `productDetailId_colorId_fk` FOREIGN KEY (`colorId`) REFERENCES `color` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `productDetailId_productId_fk` FOREIGN KEY (`productId`) REFERENCES `product` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 15 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of productdetail
-- ----------------------------
INSERT INTO `productdetail` VALUES (9, 9, 1, 1, 27300000, 'ip11Pro-gold.png', 1, '2020-09-03 23:22:09', '2020-09-03 23:22:09');
INSERT INTO `productdetail` VALUES (11, 9, 1, 2, 27000000, 'ip11Pro-xanhla.png', 1, '2020-09-03 23:31:27', '2020-09-03 23:31:27');
INSERT INTO `productdetail` VALUES (12, 9, 2, 2, 26800000, 'ip11Pro-xanhla.png', 1, '2020-09-03 23:36:02', '2020-09-03 23:36:02');
INSERT INTO `productdetail` VALUES (13, 9, 3, 2, 11000000, 'ip11Pro-xanhla.png', 1, '2020-09-03 23:37:13', '2020-09-03 23:37:13');
INSERT INTO `productdetail` VALUES (14, 9, 3, 1, 12000000, 'ip11Pro-gold.png', 1, '2020-09-03 23:37:46', '2020-09-03 23:37:46');

-- ----------------------------
-- Table structure for role
-- ----------------------------
DROP TABLE IF EXISTS `role`;
CREATE TABLE `role`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `roleName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `description` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 9 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of role
-- ----------------------------
INSERT INTO `role` VALUES (1, 'User', '', 1, '2020-09-03 15:49:40', '2020-09-03 15:49:40');
INSERT INTO `role` VALUES (2, 'Admin', '', 1, '2020-09-03 15:49:49', '2020-09-03 15:49:49');
INSERT INTO `role` VALUES (3, 'AdminAddProduct', '', 1, '2020-09-03 15:52:13', '2020-09-03 15:52:13');
INSERT INTO `role` VALUES (4, 'AdminAddUser', '', 1, '2020-09-03 15:52:22', '2020-09-03 15:52:22');
INSERT INTO `role` VALUES (5, 'AdminManagerColorProduct', '', 1, '2020-09-03 15:52:31', '2020-09-03 15:52:31');
INSERT INTO `role` VALUES (6, 'AdminManagerUser', '', 1, '2020-09-03 15:52:38', '2020-09-03 15:52:38');
INSERT INTO `role` VALUES (7, 'AdminProfileProduct', '', 1, '2020-09-03 15:52:47', '2020-09-03 15:52:47');
INSERT INTO `role` VALUES (8, 'AdminProfileUser', '', 1, '2020-09-03 15:52:55', '2020-09-03 15:52:55');

-- ----------------------------
-- Table structure for roleuser
-- ----------------------------
DROP TABLE IF EXISTS `roleuser`;
CREATE TABLE `roleuser`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `userId` int NOT NULL,
  `roleId` int NOT NULL,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `roleUserId_UserId_fk`(`userId`) USING BTREE,
  INDEX `roleUserId_RoleId_fk`(`roleId`) USING BTREE,
  CONSTRAINT `roleUserId_RoleId_fk` FOREIGN KEY (`roleId`) REFERENCES `role` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `roleUserId_UserId_fk` FOREIGN KEY (`userId`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 13 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of roleuser
-- ----------------------------
INSERT INTO `roleuser` VALUES (1, 1, 2, 1, '2020-09-03 15:50:02', '2020-09-03 15:50:02');
INSERT INTO `roleuser` VALUES (2, 1, 3, 1, '2020-09-03 15:53:24', '2020-09-03 15:53:24');
INSERT INTO `roleuser` VALUES (3, 1, 4, 1, '2020-09-03 15:53:31', '2020-09-03 15:53:31');
INSERT INTO `roleuser` VALUES (4, 1, 6, 1, '2020-09-03 15:53:38', '2020-09-03 15:53:38');
INSERT INTO `roleuser` VALUES (5, 1, 8, 1, '2020-09-03 15:53:50', '2020-09-03 15:53:50');
INSERT INTO `roleuser` VALUES (7, 3, 2, 1, '2020-09-03 21:18:20', '2020-09-03 21:18:20');
INSERT INTO `roleuser` VALUES (8, 3, 3, 1, '2020-09-03 21:18:52', '2020-09-03 21:18:52');
INSERT INTO `roleuser` VALUES (9, 3, 4, 1, '2020-09-03 21:19:03', '2020-09-03 21:19:03');
INSERT INTO `roleuser` VALUES (10, 3, 5, 1, '2020-09-03 21:19:12', '2020-09-03 21:19:12');
INSERT INTO `roleuser` VALUES (11, 3, 6, 1, '2020-09-03 21:19:21', '2020-09-03 21:19:21');
INSERT INTO `roleuser` VALUES (12, 3, 7, 1, '2020-09-03 21:19:31', '2020-09-03 21:19:31');

-- ----------------------------
-- Table structure for spec
-- ----------------------------
DROP TABLE IF EXISTS `spec`;
CREATE TABLE `spec`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of spec
-- ----------------------------
INSERT INTO `spec` VALUES (1, 1, '2020-08-02 00:24:14', '2020-08-02 00:24:14');
INSERT INTO `spec` VALUES (2, 1, '2020-08-02 14:35:08', '2020-08-02 14:35:08');
INSERT INTO `spec` VALUES (3, 1, '2020-08-03 02:56:58', '2020-08-03 02:56:58');
INSERT INTO `spec` VALUES (4, 1, '2020-09-01 16:39:52', '2020-09-01 16:39:52');

-- ----------------------------
-- Table structure for specdetail
-- ----------------------------
DROP TABLE IF EXISTS `specdetail`;
CREATE TABLE `specdetail`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `specId` int NOT NULL,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `value` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `specId_specDetailId_fk`(`specId`) USING BTREE,
  CONSTRAINT `specId_specDetailId_fk` FOREIGN KEY (`specId`) REFERENCES `spec` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 8 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of specdetail
-- ----------------------------
INSERT INTO `specdetail` VALUES (1, 1, 'Bộ nhớ trong', '64', 1, '2020-08-02 14:35:01', '2020-08-02 14:35:01');
INSERT INTO `specdetail` VALUES (2, 2, 'Bộ nhớ trong', '128', 1, '2020-08-02 14:35:22', '2020-08-02 14:35:22');
INSERT INTO `specdetail` VALUES (3, 3, 'Bộ nhớ trong', '32', 1, '2020-08-03 02:57:23', '2020-08-03 02:57:23');
INSERT INTO `specdetail` VALUES (4, 4, 'Hãng sản xuất', 'Mophie', 1, '2020-09-01 16:41:16', '2020-09-01 16:41:16');
INSERT INTO `specdetail` VALUES (5, 4, 'Dòng điện vào', '100-240V/ (50-60Hz)', 1, '2020-09-01 16:41:16', '2020-09-01 16:41:16');
INSERT INTO `specdetail` VALUES (6, 4, 'Dòng điện ra', '5V-3A, 9V-2A, 12V-1.5A (Max)', 1, '2020-09-01 16:41:55', '2020-09-01 16:41:55');
INSERT INTO `specdetail` VALUES (7, 4, 'Cổng sạc ra', 'USB-C', 1, '2020-09-01 16:41:55', '2020-09-01 16:41:55');

-- ----------------------------
-- Table structure for storage
-- ----------------------------
DROP TABLE IF EXISTS `storage`;
CREATE TABLE `storage`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `productDetailId` int NOT NULL,
  `quantity` int NOT NULL,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `productDetail_storage_fk`(`productDetailId`) USING BTREE,
  CONSTRAINT `productDetail_storage_fk` FOREIGN KEY (`productDetailId`) REFERENCES `productdetail` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 8 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of storage
-- ----------------------------

-- ----------------------------
-- Table structure for supplier
-- ----------------------------
DROP TABLE IF EXISTS `supplier`;
CREATE TABLE `supplier`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `address` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of supplier
-- ----------------------------

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `password` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `email` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES (1, 'teo', 'vLFfghR5tNV3K9DKhmwArV+SbjWAcgZZzIDTnJ0JgCo=', 'hieu25102015aa@gmail.com', 'Trương Công Mẫn', 1, '2020-09-03 15:45:01', '2020-09-03 15:45:01');
INSERT INTO `users` VALUES (2, 'teo1', 'vLFfghR5tNV3K9DKhmwArV+SbjWAcgZZzIDTnJ0JgCo=', 'hieu25102015aa@gmail.com', 'Trương Công Mẫn', 1, '2020-09-03 15:45:01', '2020-09-03 15:45:01');
INSERT INTO `users` VALUES (3, 'giangnguyen', '73l8gRjwLftklgfdXT+MdiMEjJwGPVMsyVxe16iYpk8=', 'nguyendangduynonglam@gmail.com', 'Nguyễn Thị Kim Hoa', 1, '2020-09-03 21:17:50', '2020-09-03 21:17:50');

-- ----------------------------
-- Table structure for voucher
-- ----------------------------
DROP TABLE IF EXISTS `voucher`;
CREATE TABLE `voucher`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `startDate` timestamp(0) NULL DEFAULT NULL,
  `endDate` timestamp(0) NULL DEFAULT NULL,
  `productId` int NOT NULL,
  `price` decimal(10, 0) NOT NULL,
  `status` int NOT NULL,
  `activeFlag` int NOT NULL DEFAULT 1,
  `createDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  `updateDate` timestamp(0) NOT NULL DEFAULT current_timestamp(0),
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `voucherId_ProductId_fk`(`productId`) USING BTREE,
  CONSTRAINT `voucherId_ProductId_fk` FOREIGN KEY (`productId`) REFERENCES `product` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of voucher
-- ----------------------------

SET FOREIGN_KEY_CHECKS = 1;
