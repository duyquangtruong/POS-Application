﻿USE AppTraSua
GO
--nhập liệu
INSERT dbo.[USERGROUP] VALUES (1, N'Quản lý')
INSERT dbo.[USERGROUP] VALUES (2, N'Thu ngân')
GO
INSERT dbo.[USER] VALUES (1, 'thungan01', 'AXXXZZ1234-AZA', 1, 2)
INSERT dbo.[USER] VALUES (2,'thungan02', 'AXXXZZ1234-AZA', 1, 2)
INSERT dbo.[USER] VALUES (3,'QUANLY', 'AXXXZZ1234-AZA', 1, 1)
GO
INSERT dbo.[PRO_TYPE] VALUES (1, N'Trà sữa')
INSERT dbo.[PRO_TYPE] VALUES (2, N'Trà nguyên chất')
INSERT dbo.[PRO_TYPE] VALUES (3, N'Thức uống sáng tạo')
INSERT dbo.[PRO_TYPE] VALUES (4, N'Thức uống đá xay')
INSERT dbo.[PRO_TYPE] VALUES (5, N'Thức uống đặc biệt')
INSERT dbo.[PRO_TYPE] VALUES (6, N'Thức uống khác')
INSERT dbo.[PRO_TYPE] VALUES (7, N'Topping')
GO
INSERT dbo.[PRODUCT] VALUES (1, N'Sữa Tươi Okinawa - M', 1, 47000, 6, NULL)
INSERT dbo.[PRODUCT] VALUES (2, N'Sữa Tươi Okinawa - L', 1, 53000, 6, NULL)
INSERT dbo.[PRODUCT] VALUES (3, N'Strawberry Earl Grey Latte - M', 1, 57000, 6, NULL)
INSERT dbo.[PRODUCT] VALUES (4, N'Strawberry Earl Grey Latte - L', 1, 63000, 6, NULL)
INSERT dbo.[PRODUCT] VALUES (5, N'Mango Matcha Latte - M', 1, 57000, 6, NULL)
INSERT dbo.[PRODUCT] VALUES (6, N'Okinawa Latte - M', 1, 51000, 6, NULL)
INSERT dbo.[PRODUCT] VALUES (7, N'Okinawa Latte - L', 1, 57000, 6, NULL)

INSERT dbo.[PRODUCT] VALUES (8, N'Trà Bí Đao Kem Sữa - M', 1, 47000, 5, NULL)
INSERT dbo.[PRODUCT] VALUES (9, N'Trà Bí Đao Kem Sữa - L', 1, 53000, 5, NULL)
INSERT dbo.[PRODUCT] VALUES (10, N'Trà Oolong Kem Sữa - M', 1, 47000, 5, NULL)
INSERT dbo.[PRODUCT] VALUES (11, N'Trà Oolong Kem Sữa - L', 1, 53000, 5, NULL)
INSERT dbo.[PRODUCT] VALUES (12, N'Trà Oolong Kem Sữa - Nóng', 1, 47000, 5, NULL)
INSERT dbo.[PRODUCT] VALUES (13, N'Trà Earl Grey Kem Sữa - M', 1, 47000, 5, NULL)
INSERT dbo.[PRODUCT] VALUES (14, N'Trà Earl Grey Kem Sữa - L', 1, 53000, 5, NULL)
INSERT dbo.[PRODUCT] VALUES (15, N'Trà Đen Kem Sữa - M', 1, 43000, 5, NULL)
INSERT dbo.[PRODUCT] VALUES (16, N'Trà Đen Kem Sữa - L', 1, 49000, 5, NULL)
INSERT dbo.[PRODUCT] VALUES (17, N'Trà Đen Kem Sữa - Nóng', 1, 43000, 5, NULL)
INSERT dbo.[PRODUCT] VALUES (18, N'Trà Xanh Kem Sữa - M', 1, 43000, 5, NULL)
INSERT dbo.[PRODUCT] VALUES (19, N'Trà Xanh Kem Sữa - L', 1, 47000, 5, NULL)
INSERT dbo.[PRODUCT] VALUES (20, N'Trà Xanh Kem Sữa - Nóng', 1, 43000, 5, NULL)

INSERT dbo.[PRODUCT] VALUES (21, N'Trà Sữa Xoài Trân Châu Đen - M', 1, 51000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (22, N'Trà Sữa Xoài Trân Châu Đen - L', 1, 57000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (23, N'Trà Sữa Xoài Trân Châu Đen - Nóng', 1, 51000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (24, N'Trà Sữa Okinawa - M', 1, 51000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (25, N'Trà Sữa Okinawa - L', 1, 57000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (26, N'Trà Sữa Okinawa - Nóng', 1, 51000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (27, N'Trà Sữa Matcha Đậu Đỏ - M', 1, 53000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (28, N'Trà Sữa Matcha Đậu Đỏ - L', 1, 59000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (29, N'Trà Sữa Matcha Đậu Đỏ - Nóng', 1, 53000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (30, N'Trà sữa Oolong 3J - M', 1, 53000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (31, N'Trà sữa Oolong 3J - L', 1, 59000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (32, N'Trà Sữa Pudding Đậu Đỏ - M', 1, 47000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (33, N'Trà Sữa Pudding Đậu Đỏ - L', 1, 53000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (34, N'Trà Sữa Chocolate - M', 1, 47000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (35, N'Trà Sữa Chocolate - L', 1, 53000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (36, N'Trà Sữa Chocolate - Nóng', 1, 47000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (37, N'Trà Sữa Trân Châu Đen - M', 1, 43000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (38, N'Trà Sữa Trân Châu Đen - L', 1, 49000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (39, N'Trà Sữa Trân Châu Đen - Nóng', 1, 43000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (40, N'Trà Sữa Hokkaido - M', 1, 43000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (41, N'Trà Sữa Hokkaido - L', 1, 49000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (42, N'Trà Sữa Cà Phê - M', 1, 43000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (43, N'Trà Sữa Cà Phê - L', 1, 49000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (44, N'Trà Sữa Cà Phê - Nóng', 1, 43000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (45, N'Trà Sữa Sương Sáo - M', 1, 43000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (46, N'Trà Sữa Sương Sáo - L', 1, 49000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (47, N'Trà Sữa Oolong - M', 1, 43000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (48, N'Trà Sữa Oolong - L', 1, 49000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (49, N'Trà Sữa Oolong - Nóng', 1, 43000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (50, N'Trà Sữa Trà Đen - M', 1, 40000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (51, N'Trà Sữa Trà Đen - L', 1, 46000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (52, N'Trà Sữa Trà Đen - Nóng', 1, 40000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (53, N'Trà Sữa Trà Xanh - M', 1, 40000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (54, N'Trà Sữa Trà Xanh - L', 1, 46000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (55, N'Trà Sữa Trà Xanh - Nóng', 1, 40000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (56, N'Trà Sữa Khoai Môn - M', 1, 47000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (57, N'Trà Sữa Khoai Môn - L', 1, 53000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (58, N'Trà Sữa Earl Grey - M', 1, 43000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (59, N'Trà Sữa Earl Grey - L', 1, 49000, 1, NULL)
INSERT dbo.[PRODUCT] VALUES (60, N'Trà Sữa Earl Grey - Nóng', 1, 43000, 1, NULL)

INSERT dbo.[PRODUCT] VALUES (61, N'Trà Bí Đao Alisan - M', 1, 36000, 2, NULL)
INSERT dbo.[PRODUCT] VALUES (62, N'Trà Bí Đao Alisan - L', 1, 42000, 2, NULL)
INSERT dbo.[PRODUCT] VALUES (63, N'Trà Bí Đao - M', 1, 36000, 2, NULL)
INSERT dbo.[PRODUCT] VALUES (64, N'Trà Bí Đao - L', 1, 42000, 2, NULL)
INSERT dbo.[PRODUCT] VALUES (65, N'Trà Alisan - M', 1, 36000, 2, NULL)
INSERT dbo.[PRODUCT] VALUES (66, N'Trà Alisan - L', 1, 42000, 2, NULL)
INSERT dbo.[PRODUCT] VALUES (67, N'Trà Alisan - Nóng', 1, 36000, 2, NULL)
INSERT dbo.[PRODUCT] VALUES (68, N'Trà Earl Grey - M', 1, 36000, 2, NULL)
INSERT dbo.[PRODUCT] VALUES (69, N'Trà Earl Grey - L', 1, 42000, 2, NULL)
INSERT dbo.[PRODUCT] VALUES (70, N'Trà Earl Grey - Nóng', 1, 36000, 2, NULL)
INSERT dbo.[PRODUCT] VALUES (71, N'Trà Oolong - M', 1, 36000, 2, NULL)
INSERT dbo.[PRODUCT] VALUES (72, N'Trà Oolong - L', 1, 42000, 2, NULL)
INSERT dbo.[PRODUCT] VALUES (73, N'Trà Oolong - Nóng', 1, 36000, 2, NULL)
INSERT dbo.[PRODUCT] VALUES (74, N'Trà Đen - M', 1, 33000, 2, NULL)
INSERT dbo.[PRODUCT] VALUES (75, N'Trà Đen - L', 1, 39000, 2, NULL)
INSERT dbo.[PRODUCT] VALUES (76, N'Trà Đen - Nóng', 1, 33000, 2, NULL)
INSERT dbo.[PRODUCT] VALUES (77, N'Trà Xanh - M', 1, 33000, 2, NULL)
INSERT dbo.[PRODUCT] VALUES (78, N'Trà Xanh - L', 1, 39000, 2, NULL)
INSERT dbo.[PRODUCT] VALUES (79, N'Trà Xanh - Nóng', 1, 33000, 2, NULL)

INSERT dbo.[PRODUCT] VALUES (80, N'QQ Chanh Dây Trà Xanh - M', 1, 47000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (81, N'QQ Chanh Dây Trà Xanh - L', 1, 53000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (82, N'Chanh Ai-yu và Trân Châu Trắng - M', 1, 43000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (83, N'Chanh Ai-yu và Trân Châu Trắng - L', 1, 49000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (84, N'Đào Hồng Mận Hạt É - M', 1, 43000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (85, N'Đào Hồng Mận Hạt É - L', 1, 49000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (86, N'Trà Oolong Vải - M', 1, 43000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (87, N'Trà Oolong Vải - L', 1, 49000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (88, N'Trà Alisan Vải - M', 1, 43000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (89, N'Trà Alisan Vải - L', 1, 49000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (90, N'Trà Alisan Vải - Nóng', 1, 43000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (91, N'Trà Alisan Xoài - M', 1, 43000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (92, N'Trà Alisan Xoài - L', 1, 49000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (93, N'Trà Alisan Xoài - Nóng', 1, 43000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (94, N'Trà Xanh Chanh Dây - M', 1, 43000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (95, N'Trà Xanh Chanh Dây - L', 1, 49000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (96, N'Trà Xanh Chanh Dây - Nóng', 1, 43000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (97, N'Trà Alisan Chanh Dây - M', 1, 40000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (98, N'Trà Alisan Chanh Dây - L', 1, 46000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (99, N'Trà Alisan Chanh Dây - Nóng', 1, 40000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (100, N'Trà Đen Đào - M', 1, 40000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (101, N'Trà Đen Đào - L', 1, 46000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (102, N'Trà Đen Đào - Nóng', 1, 40000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (103, N'Trà Xanh Đào - M', 1, 40000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (104, N'Trà Xanh Đào - L', 1, 46000, 3, NULL)
INSERT dbo.[PRODUCT] VALUES (105, N'Trà Xanh Đào - Nóng', 1, 40000, 3, NULL)

INSERT dbo.[PRODUCT] VALUES (106, N'Strawberry Oreo Smoothie - M', 1, 63000, 4, NULL)
INSERT dbo.[PRODUCT] VALUES (107, N'Chocolate Đá Xay - M', 1, 59000, 4, NULL)
INSERT dbo.[PRODUCT] VALUES (108, N'Khoai Môn Đá Xay - M', 1, 59000, 4, NULL)
INSERT dbo.[PRODUCT] VALUES (109, N'Matcha Đá Xay - M', 1, 59000, 4, NULL)
INSERT dbo.[PRODUCT] VALUES (110, N'Yakult Đào Đá Xay - M', 1, 59000, 4, NULL)
INSERT dbo.[PRODUCT] VALUES (111, N'Xoài Đá Xay - M', 1, 54000, 4, NULL)

INSERT dbo.[PRODUCT] VALUES (112, N'Kem Sữa', 1, 16000, 7, NULL)
INSERT dbo.[PRODUCT] VALUES (113, N'Nha Đam', 1, 10000, 7, NULL)
INSERT dbo.[PRODUCT] VALUES (114, N'Hạt É', 1, 10000, 7, NULL)
INSERT dbo.[PRODUCT] VALUES (115, N'Trân Châu Đen', 1, 10000, 7, NULL)
INSERT dbo.[PRODUCT] VALUES (116, N'Trân Châu Trắng', 1, 10000, 7, NULL)
INSERT dbo.[PRODUCT] VALUES (117, N'Đậu Đỏ', 1, 10000, 7, NULL)
INSERT dbo.[PRODUCT] VALUES (118, N'Sương Sáo', 1, 10000, 7, NULL)
INSERT dbo.[PRODUCT] VALUES (119, N'Thạch Nâu', 1, 10000, 7, NULL)
INSERT dbo.[PRODUCT] VALUES (120, N'Thạch Trái Cây', 1, 10000, 7, NULL)
INSERT dbo.[PRODUCT] VALUES (121, N'Thạch Ai-yu', 1, 10000, 7, NULL)
INSERT dbo.[PRODUCT] VALUES (122, N'Thạch Dừa', 1, 10000, 7, NULL)
INSERT dbo.[PRODUCT] VALUES (123, N'Pudding', 1, 10000, 7, NULL)
INSERT dbo.[PRODUCT] VALUES (124, N'Combo 2 Loại Hạt', 1, 17000, 7, NULL)
INSERT dbo.[PRODUCT] VALUES (125, N'Combo 3 Loại Hạt', 1, 25000, 7, NULL)

GO
INSERT dbo.[CUS_TYPE] VALUES (1, N'Giao hàng')
INSERT dbo.[CUS_TYPE] VALUES (2, N'Khu uống tại quán')
GO
INSERT dbo.[BILL] VALUES (111, '2019-11-25 17:15:00.000', 2, 100000)
INSERT dbo.[BILL] VALUES (222, '2019-11-25 16:15:00.000', 1, 177000)
GO
INSERT dbo.[BILLDETAIL] VALUES (1, 111, 1, 1, 47000)
INSERT dbo.[BILLDETAIL] VALUES (2, 111, 2, 1, 53000)
INSERT dbo.[BILLDETAIL] VALUES (3, 222, 3, 1, 57000)
INSERT dbo.[BILLDETAIL] VALUES (4, 222, 4, 1, 63000)
INSERT dbo.[BILLDETAIL] VALUES (5, 222, 5, 1, 57000)