DECLARE @counter INT;
SET @counter = 1;

WHILE @counter <= 50
BEGIN
    
    DECLARE @admissionNo VARCHAR(10);
    SET @admissionNo = CONCAT('STID', RIGHT('000' + CAST(@counter AS VARCHAR(3)), 3));

  
    INSERT INTO AdmissionNoTable (admissionNo) VALUES (@admissionNo);

    SET @counter = @counter + 1;
END;