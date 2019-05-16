create table [Address](
AddressID int unique not null,
Zip varchar(25) not null,
City varchar(100) not null,
StreetName varchar(100) not null,
StreetNr varchar(50) not null,
FloorNr int,
AptNr varchar(10),
PhoneNr varchar(20),
PRIMARY KEY(Zip, City, StreetName, StreetNr, FloorNR, AptNr) 
)

create table MemberType(
TypeName varchar(20) not null,
GracePeriod int not null,
LoanPeriod int not null,
MaxBooksLoaned int not null,
PRIMARY KEY(TypeName)
)

create table Member(
SSN int not null,
MobilePhoneNr varchar(20) not null,
FirstName varchar(50) not null,
LastName varchar (50) not null,
CampusAddressID int not null,
HomeAddressID int not null,
IsActive bit not null,
[Type] varchar(20) not null,
DateCreated DateTime not null,
PRIMARY KEY(SSN),
FOREIGN KEY(CampusAddressID) REFERENCES [Address](AddressID), 
FOREIGN KEY(HomeAddressID) REFERENCES [Address](AddressID),
FOREIGN KEY([Type]) REFERENCES MemberType(TypeName)
)

create table LibrarianRole(
RoleName varchar(50) not null,
PRIMARY KEY(RoleName)
)

create table Librarian(
SSN int not null,
Username varchar(30) unique not null,
[Password] varchar(30) not null,
LibrarianRole varchar(50) not null,
DateHired DateTime not null,
PRIMARY KEY(SSN ), 
FOREIGN KEY(SSN ) REFERENCES Member(SSN),
FOREIGN KEY(LibrarianRole) REFERENCES LibrarianRole(RoleName)
)

create table Loan(
ID int Identity,
LibrarianID int not null,
MemberID int not null,
DateCreated DateTime not null,
PRIMARY KEY(ID),
FOREIGN KEY(LibrarianID) REFERENCES Librarian(SSN ),
FOREIGN KEY(MemberID) REFERENCES Member(SSN)
)

create table LibraryCard(
CardNr int not null,
MemberID int not null,
DateCreated DateTime not null,
ExpirationDate DateTime not null,
PRIMARY KEY(CardNr),
FOREIGN KEY(MemberID) REFERENCES Member(SSN)
)

create table Title(
ID int Identity,
Publisher varchar(50) not null,
TitleName varchar(200) not null,
[Language] varchar (50),
ISBN int not null,
Edition int not null,
PublicationYear int not null,
[Description] varchar (max),
[Type] varchar (50) not null,
[Subject] varchar(20) not null,
IsLoanable bit not null,
DateCreated DateTime not null,
PRIMARY KEY (ID),
) 

create table Book(
TitleID int not null,
CopyNr int not null,
BookState varchar(50),
Available bit,
DateAcquired DateTime,
PRIMARY KEY(TitleID, CopyNr),
FOREIGN KEY(TitleID) REFERENCES Title(ID)
) 

create table LoanBook(
LoanID int not null,
BookID int not null,
CopyNr int not null,
DateReturned DateTime,
PRIMARY KEY(LoanID, BookID, CopyNr),
FOREIGN KEY(LoanID) REFERENCES Loan(ID),
FOREIGN KEY(BookID, CopyNr) REFERENCES Book(TitleID, CopyNr)
)

create table Author(
ID int Identity,
FirstName varchar (50) not null,
MiddleName varchar (100),
LastName varchar (50) not null,
[Description] varchar (max),
YearOfBirth int,
YearOfDeath int,
PRIMARY KEY(ID),
)

create table AuthorTitle(
TitleID int not null,
AuthorID int not null,
PRIMARY KEY(TitleID, AuthorID),
FOREIGN KEY(TitleID) REFERENCES Title(ID),
FOREIGN KEY(AuthorID) REFERENCES Author(ID)
)

create table Notice(
ID int Identity,
MemberID int not null,
[Status] varchar (20) not null,
[Message] varchar(max) not null,
DateSent DateTime,
DateCreated DateTime not null,
PRIMARY KEY(ID),
FOREIGN KEY(MemberID) REFERENCES Member(SSN)
)

create table BookNotice(
NoticeID int not null,
BookID int not null,
CopyNr int not null,
PRIMARY KEY(NoticeID),
FOREIGN KEY(NoticeID) REFERENCES Notice(ID),
FOREIGN KEY(BookID, CopyNr) REFERENCES Book(TitleID, CopyNr)
)

create table LibraryCardNotice(
NoticeID int not null,
CardID int not null,
PRIMARY KEY(NoticeID),
FOREIGN KEY(NoticeID) REFERENCES Notice(ID),
FOREIGN KEY(CardID) REFERENCES LibraryCard(CardNr)
)

create table BookWish(
ID int Identity,
Reason varchar (max) not null,
Amount int not null,
[Status] varchar(20) not null,
TitleID int not null,
LibrarianID int not null,
DateCreated DateTime not null,
PRIMARY KEY(ID),
FOREIGN KEY(TitleID) REFERENCES Title(ID),
FOREIGN KEY(LibrarianID) REFERENCES Librarian(SSN)
)

create table ForeignLibrary(
LibraryName varchar(100) not null,
APIKey varchar(100),
LibraryEmail varchar(60) not null,
LibraryPhoneNr varchar(40) not null,
IsCooperating bit not null,
LibraryAddressID int not null,
DateAdded DateTime not null,
PRIMARY KEY(LibraryName),
FOREIGN KEY(LibraryAddressID) REFERENCES [Address](AddressID)
)

create table ForeignAcqusitionApplication(
ID int not null,
[Status] varchar(20) not null,
ContactFirstName varchar(50) not null,
ContactLastName varchar(50) not null,
[Message] varchar(max) not null,
ForeignLibraryID varchar(100) not null,
TitleID int not null,
DateCreated DateTime not null,
PRIMARY KEY(ID),
FOREIGN KEY(TitleID) REFERENCES Title(ID),
FOREIGN KEY(ForeignLibraryID) REFERENCES ForeignLibrary(LibraryName)
)

create table [Permission](
Permission varchar(100) not null,
PRIMARY KEY(Permission)
)

create table LibrarianRolePermission(
PermissionID varchar(100) not null,
LibrarianRoleID varchar(50) not null,
PRIMARY KEY(PermissionID, LibrarianRoleID),
FOREIGN KEY(PermissionID) REFERENCES [Permission](Permission),
FOREIGN KEY(LibrarianRoleID) REFERENCES LibrarianRole(RoleName)
)
