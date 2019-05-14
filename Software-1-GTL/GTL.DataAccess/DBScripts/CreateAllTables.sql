create table Addresses(
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

create table MemberTypes(
TypeName varchar(20) not null,
GracePeriod int not null,
LoanPeriod int not null,
PRIMARY KEY(TypeName)
)

create table Members(
SSN int not null,
MobilePhoneNr varchar(20) not null,
FirstName varchar(50) not null,
LastName varchar (50) not null,
CampusAddressID int not null,
HomeAddressID int not null,
IsActive bit not null,
MemberType varchar(20) not null,
DateCreated DateTime not null,
PRIMARY KEY(SSN),
FOREIGN KEY(CampusAddressID) REFERENCES Addresses(AddressID), 
FOREIGN KEY(HomeAddressID) REFERENCES Addresses(AddressID),
FOREIGN KEY(MemberType) REFERENCES MemberTypes(TypeName)
)

create table LibrarianRoles(
RoleName varchar(50) not null,
PRIMARY KEY(RoleName)
)

create table Librarians(
LibrarianSSN int not null,
Username varchar(30) unique not null,
"Password" varchar(30) not null,
LibrarianRole varchar(50) not null,
DateHired DateTime not null,
PRIMARY KEY(LibrarianSSN ), 
FOREIGN KEY(LibrarianSSN ) REFERENCES Members(SSN),
FOREIGN KEY(LibrarianRole) REFERENCES LibrarianRoles(RoleName)
)

create table Loans(
LoanID int Identity,
LibrarianID int not null,
MemberID int not null,
DateCreated DateTime not null,
PRIMARY KEY(LoanID),
FOREIGN KEY(LibrarianID) REFERENCES Librarians(LibrarianSSN ),
FOREIGN KEY(MemberID) REFERENCES Members(SSN)
)

create table LibraryCards(
CardID int not null,
MemberID int not null,
DateCreated DateTime not null,
ExpirationDate DateTime not null,
PRIMARY KEY(CardID),
FOREIGN KEY(MemberID) REFERENCES Members(SSN)
)

create table Titles(
TitleID int Identity,
Publisher varchar(50) not null,
TitleName varchar(200) not null,
"Language" varchar (50),
ISBN int not null,
Edition int not null,
PublicationYear int not null,
"Description" varchar (max),
"Type" varchar (50) not null,
"Subject" varchar(20) not null,
IsLoanable bit not null,
DateCreated DateTime not null,
PRIMARY KEY (TitleID),
) 

create table Books(
TitleID int not null,
CopyNr int not null,
BookState varchar(50),
Available bit,
DateAcquired DateTime,
PRIMARY KEY(TitleID, CopyNr),
FOREIGN KEY(TitleID) REFERENCES Titles(TitleID)
) 

create table LoanBooks(
LoanID int not null,
BookID int not null,
CopyNr int not null,
DateReturned DateTime,
PRIMARY KEY(LoanID, BookID, CopyNr),
FOREIGN KEY(LoanID) REFERENCES Loans(LoanID),
FOREIGN KEY(BookID, CopyNr) REFERENCES Books(TitleID, CopyNr)
)

create table Authors(
AuthorID int Identity,
FirstName varchar (50) not null,
MiddleName varchar (100),
LastName varchar (50) not null,
"Description" varchar (max),
YearOfBirth int,
YearOfDeath int,
PRIMARY KEY(AuthorID),
)

create table AuthorTitle(
TitleID int not null,
AuthorID int not null,
PRIMARY KEY(TitleID, AuthorID),
FOREIGN KEY(TitleID) REFERENCES Titles(TitleID),
FOREIGN KEY(AuthorID) REFERENCES Authors(AuthorID)
)

create table Notices(
NoticeID int Identity,
MemberID int not null,
"Status" varchar (20) not null,
"Message" varchar(max) not null,
DateSent DateTime,
DateCreated DateTime not null,
PRIMARY KEY(NoticeID),
FOREIGN KEY(MemberID) REFERENCES Members(SSN)
)

create table BookNotice(
NoticeID int not null,
BookID int not null,
CopyNr int not null,
PRIMARY KEY(NoticeID),
FOREIGN KEY(NoticeID) REFERENCES Notices(NoticeID),
FOREIGN KEY(BookID, CopyNr) REFERENCES Books(TitleID, CopyNr)
)

create table LibraryCardNotice(
NoticeID int not null,
CardID int not null,
PRIMARY KEY(NoticeID),
FOREIGN KEY(NoticeID) REFERENCES Notices(NoticeID),
FOREIGN KEY(CardID) REFERENCES LibraryCards(CardID)
)

create table BookWish(
WishID int Identity,
Reason varchar (max) not null,
Amount int not null,
"Status" varchar(20) not null,
TitleID int not null,
LibrarianID int not null,
DateCreated DateTime not null,
PRIMARY KEY(WishID),
FOREIGN KEY(TitleID) REFERENCES Titles(TitleID),
FOREIGN KEY(LibrarianID) REFERENCES Librarians(LibrarianSSN)
)

create table ForeignLibraries(
LibraryName varchar(100) not null,
APIKey varchar(100),
LibraryEmail varchar(60) not null,
LibraryPhoneNr varchar(40) not null,
IsCooperating bit not null,
LibraryAddressID int not null,
DateAdded DateTime not null,
PRIMARY KEY(LibraryName),
FOREIGN KEY(LibraryAddressID) REFERENCES Addresses(AddressID)
)

create table ForeignAcqusitionApplication(
ApplicationID int not null,
"Status" varchar(20) not null,
ContactFirstName varchar(50) not null,
ContactLastName varchar(50) not null,
"Message" varchar(max) not null,
ForeignLibraryID varchar(100) not null,
TitleID int not null,
DateCreated DateTime not null,
PRIMARY KEY(ApplicationID),
FOREIGN KEY(TitleID) REFERENCES Titles(TitleID),
FOREIGN KEY(ForeignLibraryID) REFERENCES ForeignLibraries(LibraryName)
)

create table "Permissions"(
Permission varchar(100) not null,
PRIMARY KEY(Permission)
)

create table LibrarianRolePermissions(
PermissionID varchar(100) not null,
LibrarianRoleID varchar(50) not null,
PRIMARY KEY(PermissionID, LibrarianRoleID),
FOREIGN KEY(PermissionID) REFERENCES "Permissions"(Permission),
FOREIGN KEY(LibrarianRoleID) REFERENCES LibrarianRoles(RoleName)
)
