USE AppTraSua
GO
--index
CREATE NONCLUSTERED INDEX ProductName 
	ON [PRODUCT] ([ProductID] ASC, [ProductName] ASC)

CREATE NONCLUSTERED INDEX ProductID_BillDetail
	ON [BILLDETAIL] ([ProductID])

CREATE NONCLUSTERED INDEX BillID_BillDetail
	ON [BILLDETAIL] ([BillID])
GO

--produce, function, trigger
-- Function đếm số lượng ly đã bán của sản phẩm
CREATE FUNCTION fDemSoSP(@ProductID int) 
RETURNS int AS 
BEGIN 
	DECLARE @nPro int; 
	SELECT @nPro = SUM(BDT.BDQuantity) 
	FROM PRODUCT AS PRO, BILLDETAIL AS BDT
	WHERE PRO.ProductID = BDT.ProductID and PRO.ProductID = @ProductID; 
	IF (@nPro IS NULL) 
		SET @nPro = 0; 
	RETURN @nPro;
END
GO
--select dbo.fDemSoSP(1)
GO
-- Function đếm tổng số ly đã bán
CREATE FUNCTION fDemTongSoLy() 
RETURNS int AS 
BEGIN 
	DECLARE @nSum int; 
	SELECT @nSum = SUM(BDQuantity) 
	FROM BILLDETAIL;
	IF (@nSum IS NULL) 
		SET @nSum = 0; 
	RETURN @nSum;
END
GO
--select round(cast(dbo.fDemSoSP(1) as float) / dbo.fDemTongSoLy(), 1)
GO
-- Thủ tục cập nhật lại popular của 1 sản phẩm với tham số đầu vào: ProductID
CREATE PROCEDURE pCapNhatPopular @ProductID int
AS
BEGIN
	UPDATE PRODUCT
	SET Popular = (SELECT DISTINCT ROUND(CAST(dbo.fDemSoSP(PRO.ProductID) as float) / dbo.fDemTongSoLy(), 1) 
	FROM PRODUCT AS PRO, BILLDETAIL AS BDT
	WHERE PRO.ProductID = BDT.ProductID and PRO.ProductID = @ProductID)
	WHERE ProductID = @ProductID
END
GO
--DROP PROCEDURE pCapNhatPopular
--Ví dụ:
--EXEC pCapNhatPopular 1


-- Thủ tục cập nhật lại popular cho tất cả sản phẩm
CREATE PROCEDURE pCapNhatPopularAll
AS
BEGIN
	DECLARE @ID INT = 1 ;
	DECLARE @Count INT = (SELECT COUNT(*) FROM PRODUCT) ;
 
	WHILE @ID <= @Count
	BEGIN
		EXEC pCapNhatPopular @ID

		SET @ID = @ID + 1 ;
	END
END
GO
--Ví dụ:
--EXEC pCapNhatPopularAll
GO

-- Thủ tục bắt đầu khởi tạo hóa đơn
CREATE PROCEDURE pKhoiTaoHoaDon
AS
BEGIN
	INSERT INTO dbo.[BILL]([Date], [CusTypeID]) VALUES (NULL, NULL)
END
GO 
--EXEC pKhoiTaoHoaDon
go

-- Thủ tục thêm chi tiết hóa đơn
CREATE PROCEDURE pThemChiTietHoaDon @ProductID INT, @BDQuantity INT
AS
BEGIN
	INSERT INTO BILLDETAIL ([BillID], [ProductID], [BDQuantity], [BDTotalAmout]) VALUES
	((SELECT [NextBillID] FROM [TEMPNUMBER]), @ProductID, @BDQuantity, 	(SELECT Price * @BDQuantity FROM PRODUCT WHERE ProductID = @ProductID))
END
GO 
--DROP PROC pThemChiTietHoaDon
--EXEC pThemChiTietHoaDon 7, 2
GO

-- Thủ tục kết thúc hóa đơn
CREATE PROCEDURE pKetThucHoaDon @CusTypeID INT
AS
BEGIN
	UPDATE [BILL]
	SET [Date] = GETDATE(), [CusTypeID] = @CusTypeID, [TotalAmout] = (SELECT SUM(BDT.BDTotalAmout) 
	FROM [BILL] AS BI, [BILLDETAIL] AS BDT
	WHERE BI.BillID = BDT.BillID)
	WHERE BillID = (SELECT [NextBillID] FROM [TEMPNUMBER])

	UPDATE [TEMPNUMBER]
	SET [NextBillID] = [NextBillID] + 1
END
GO 
--EXEC pKetThucHoaDon 2
GO

-- Hàm tìm kiếm hóa đơn theo ngày (từ ngày... đến ngày...)
CREATE FUNCTION fTimHoaDonTheoNgay (@TuNgay DATETIME, @DenNgay DATETIME)
RETURNS table
AS
	return (SELECT * FROM BILL WHERE Date BETWEEN @TuNgay AND @DenNgay)
GO
--Ví dụ:
--select * from dbo.fTimHoaDonTheoNgay('2019-11-20', '2019-12-10')

-- Không cho phép xóa hóa đơn
CREATE TRIGGER trgXoaChiTietHoaDon
ON BILLDETAIL
FOR DELETE
AS
BEGIN
	BEGIN
		RAISERROR (N'LỖI: KHÔNG ĐƯỢC XÓA CHI TIẾT HÓA ĐƠN', 16, 1)
		ROLLBACK
	END
END
GO

CREATE TRIGGER trgXoaHoaDon
ON BILL
FOR DELETE
AS
BEGIN
	BEGIN
		RAISERROR (N'LỖI: KHÔNG ĐƯỢC XÓA HÓA ĐƠN', 16, 1)
		ROLLBACK
	END
END
GO