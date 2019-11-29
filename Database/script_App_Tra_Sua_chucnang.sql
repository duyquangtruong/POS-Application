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
-- Function đém số lượng ly đã bán của sản phẩm
CREATE FUNCTION fDemSoSP(@ProductID int) 
RETURNS int AS 
BEGIN 
	DECLARE @nPro int; 
	SELECT @nPro = sum(BDT.BDQuantity) 
	FROM PRODUCT AS PRO, BILLDETAIL AS BDT
	WHERE PRO.ProductID = BDT.ProductID and PRO.ProductID = @ProductID; 
	IF (@nPro IS NULL) 
		SET @nPro = 0; 
	RETURN @nPro;
END
GO
--select dbo.fDemSoSP(1)
GO
-- Function đém tổng số ly đã bán
CREATE FUNCTION fDemTongSoLy() 
RETURNS int AS 
BEGIN 
	DECLARE @nSum int; 
	SELECT @nSum = sum(BDQuantity) 
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
	SET Popular = (SELECT round(cast(dbo.fDemSoSP(PRO.ProductID) as float) / dbo.fDemTongSoLy(), 1) 
	FROM PRODUCT AS PRO, BILLDETAIL AS BDT
	WHERE PRO.ProductID = BDT.ProductID and PRO.ProductID = @ProductID)
	WHERE ProductID = @ProductID
END
GO
--Ví dụ:
--EXEC pCapNhatPopular 1

-- Thủ tục tính tổng tiền của 1 sản phẩm trong chi tiết hóa đơn với tham số đầu vào: BillDetailID, BillID, ProductID
CREATE PROCEDURE pTotalAmountBillDetail @BillDetailID int, @BillID int, @ProductID int
AS
BEGIN
	UPDATE BILLDETAIL
	SET BDTotalAmout = (SELECT PRO.Price * BDT.BDQuantity 
	FROM PRODUCT AS PRO, BILLDETAIL AS BDT
	WHERE PRO.ProductID = BDT.ProductID and PRO.ProductID = @ProductID)
	WHERE BillDetailID = @BillDetailID AND BillID = @BillID
END
GO
--EXEC pTotalAmountBillDetail 1 , 111, 1
GO
-- Thủ tục tính tổng tiền hóa đơn với tham số đầu vào: BillID
CREATE PROCEDURE pTotalAmountBill @BillID int
AS
BEGIN
	UPDATE BILL
	SET TotalAmout = (SELECT SUM(BDT.BDTotalAmout) 
	FROM BILL AS BI, BILLDETAIL AS BDT
	WHERE BI.BillID = BDT.BillID and BI.BillID = @BillID)
	WHERE BillID = @BillID
END
GO
--EXEC pTotalAmountBill 111
GO

create procedure pThemChiTietHoaDon @BillDetailID INT, @BillID INT, @ProductID INT, @BDQuantity INT
AS
BEGIN
	-- Kiểm tra BillID có tồn tại
	IF(EXISTS(SELECT BillID FROM BILL WHERE @BillID = BillID))
	BEGIN
		-- Kiểm tra BillDetailID có hợp lệ
		IF(EXISTS(SELECT BillDetailID FROM BILLDETAIL WHERE @BillDetailID = BillDetailID))
		BEGIN
			RAISERROR (N'BillDetailID ĐÃ TỒN TẠI', 16, 1)
		END
		ELSE
		BEGIN
			IF(EXISTS(SELECT BillID FROM BILL WHERE @BillID < BillID))
			BEGIN
				RAISERROR (N'BillID ĐÃ QUA XỬ LÝ', 14, 1)
			END
			ELSE
			BEGIN
				INSERT INTO BILLDETAIL(BillDetailID, BillID, ProductID, BDQuantity) 
				VALUES (@BillDetailID, @BillID, @ProductID, @BDQuantity)
				EXEC pTotalAmountBillDetail @BillDetailID , @BillID, @ProductID
			END
		END
	END
	ELSE
	BEGIN
		PRINT N'BillID KHÔNG TỒN TẠI TRONG DATABASE'
	END
END
GO 
DROP PROC pThemChiTietHoaDon
--EXEC pThemChiTietHoaDon 7, 222, 7, 1
GO
--Tìm kiếm hóa đơn theo ngày (từ ngày... đến ngày...)--
CREATE FUNCTION fTimHoaDonTheoNgay (@TuNgay DATETIME, @DenNgay DATETIME)
RETURNS table
AS
	return (SELECT * FROM BILL WHERE Date BETWEEN @TuNgay AND @DenNgay)
GO
--Ví dụ:
--select * from dbo.fTimHoaDonTheoNgay('2019-11-20', '2019-12-1')

--Không cho phép xóa hóa đơn--
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
