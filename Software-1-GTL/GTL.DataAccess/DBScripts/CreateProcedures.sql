CREATE PROCEDURE addBookCopy
	@titleID int,
	@bookState varchar(50),
	@available bit,
	@dateAcquired DateTime
AS
BEGIN
	DECLARE @copNr int = ((SELECT COUNT(*) FROM dbo.Book WHERE TitleID = @titleID) + 1);
	INSERT INTO Book VALUES(
		@titleID,
		@copNr,
		@bookState,
		@available,
		@dateAcquired
	)

	SELECT TOP 1 * FROM dbo.Book WHERE TitleID = @titleID AND CopyNr = @copNr;
END

GO

