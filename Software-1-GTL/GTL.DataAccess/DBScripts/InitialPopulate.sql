/* RUN THIS LAST */


INSERT INTO MemberType VALUES('Student', 7, 30, 5)

INSERT INTO LibrarianRole VALUES('ChiefLibrarian')

INSERT INTO [Address] VALUES('9000', 'Aalborg', 'Blegkilde', '6', 1, '17', '+45 98765432')

INSERT INTO Member VALUES (002020002, '+45 12345678', 'Karen', 'Wuppel', 1, 1, 1, 'Student', GETDATE())
INSERT INTO Member VALUES (123456, '+45 12345678', 'Jarlund', 'Meki', 1, 1, 1, 'Student', GETDATE())
INSERT INTO Member VALUES (001010001, '+45 12345678', 'Martin', 'Stein', 1, 1, 1, 'Student', GETDATE())


Insert into Librarian values (002020002, 'Magret45', 'Horses4Lyfe', 'ChiefLibrarian', GETDATE())
Insert into Librarian values (123456, 'Bookmaster1337', 'Glasses', 'ChiefLibrarian', GETDATE())

INSERT INTO Title VALUES ('Grp5 publishing', 'Journey of failure', 'Danglish', 123456, 5, 1234, 'Lots of text', 'Magazine', 'Schoolwork', 1, GETDATE())
INSERT INTO Title VALUES ('Adventure Co.', 'A song of Winnieh and Ice', 'English', 5545, 1, 2019, 'Lots of text', 'Book', 'Fantasy', 1, GETDATE())

DECLARE @date datetime = GETDATE()

EXEC addBookCopy 1, 'New', 1, @date
EXEC addBookCopy 1, 'New', 1, @date

EXEC addBookCopy 2, 'Worn', 1, @date


