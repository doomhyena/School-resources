/****** Object:  Table [dbo].[Comments]    Script Date: 2022. 05. 22. 20:13:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Creator] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
	[TopicID] [int] NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[Prequel] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topics]    Script Date: 2022. 05. 22. 20:13:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topics](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Parent] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Creator] [int] NOT NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2022. 05. 22. 20:13:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](25) NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[Role] [nvarchar](12) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 
GO
INSERT [dbo].[Comments] ([id], [Creator], [Created], [TopicID], [Text], [Prequel], [Active]) VALUES (1102, 2015, CAST(N'2022-03-01T12:00:00.000' AS DateTime), 33, N'Most kezdtem el foglalkozni a VS.NET -tel és a C# nyelvvel. Ha van köztetek olyan, aki ezzel foglalkozik vagy csak érdekli itt a helye.

Szívesen vennék egy-két magyar nyelvű leírást, ha van valakinek. Angolul a Microsoft ellátja az embert temérdek tutoriallal meg sample progival, de magyarul eddig alig találtam valamit.

Nagyon tetszik egyébként a környezet, mert nem kell minden windows-os dolgot lekódolni. Egy sor alapvető műveletet kivesz a kezünkből a VS.NET.
Ettől függetlenül nem a legkönnyebb nyelv, mert full objektumorientált, ami (nekem) kicsit nehezebb téma a régi c++ -os tömbkezelésnél, stb.

Szóval várok minden nemű írást ide, legyen az vélemény attól, aki próbálta, kódrészlet, kérdés... bármi a témában.', 0, 1)
GO
INSERT [dbo].[Comments] ([id], [Creator], [Created], [TopicID], [Text], [Prequel], [Active]) VALUES (1103, 2015, CAST(N'2022-03-01T12:15:00.000' AS DateTime), 34, N'Üdvözlet mindenkinek!
A témát azért nyitottam hogy a címben megnevezett programozási nyelvet kitárgyaljuk, illetve segítséget nyújtsunk azoknak akik kérnek (első vagyok e sorban :D ).

A Python egy magas szintű objektum-orientált programozási nyelv, ami némileg hasonlít egyes szkriptnyelvekhez (Perlhez, Scheme-hez, TCL--hez), illetve más nyelvekhez is (Java, C). Fő előnye hogy "könnyen" (khm :U ) tanulható, komoly alkalmazások fejlesztésére is alkalmazható, sőt rendkívül hatékony.

Főbb előnyei:
hordozható, integrálható, viszonylag egyszerű, nagyteljesítményű, dinamikus, s nyílt a forráskódja.

Python-ról magyarul:
[Wikipédia]
[Python.hu]
[Python oktatás]
-
[Python 2.5.2 Windows operációs rendszerre]

Hogyan kezdjünk hozzá a tanulásához?
Nehéz lenne okosat mondanom, ugyanis én se vagyok a programozás nagyöregje, DE úgy látom jó úton haladok. Gérard Swinnen : Tanuljunk meg programozni Python nyelven c. könyvét nagyon ajánlom, ami ingyenesen letölthető a python.free-h.net oldalról. E mellé pedig érdemes beszerezni Brad Dayley: Python zsebköny c. csodáját, ami sok hasznos Python programrészletet foglal magában.', 0, 1)
GO
INSERT [dbo].[Comments] ([id], [Creator], [Created], [TopicID], [Text], [Prequel], [Active]) VALUES (1104, 2015, CAST(N'2022-03-01T13:33:00.000' AS DateTime), 35, N'Hi!

Láttam, hogy nincs igazi Java topic, ezért gondoltam, én nyitok egyet, jó lenne, ha itt kérdezgetnénk Java-s dolgokat. Szóval, hogy megnyissam a sort, lenne is egy kérdésem. Szóval van egy egyszerű Java alkalmazás, é szeretnék beolvasni az inputról. Van két {B}int tpusú változó, és {B}readCharacter(){/B} függvénnyel próbáltam beolvasni, de nem igazán ismeri a függvényt a fordító. Mit kell importálni, hogy működjön?

Kb. ilyen a progi:
class xy{
public static void main(String []args)
{
int x;
int y;
x=readCharacter();
y=readCharacter();
}
}

Ha van ötlet, írjatok!!', 0, 1)
GO
INSERT [dbo].[Comments] ([id], [Creator], [Created], [TopicID], [Text], [Prequel], [Active]) VALUES (1105, 2017, CAST(N'2022-03-01T23:00:00.000' AS DateTime), 35, N'Hali!

Ezt máshogy lehet csak megoldani.
Most már túl álmos vagyok a válaszhoz, de addig is, amíg fel nem ébredek, töltsd le az alábbi filet:
ftp://ftp.gdf.hu/Public/Java/javaprog.zip

Ebben lesz egy Extra nevű csomag, abban egy Console nevű osztály. Abban van számbeolvasó rutin (mert amúgy csak stringbe lehetne).', 1104, 1)
GO
INSERT [dbo].[Comments] ([id], [Creator], [Created], [TopicID], [Text], [Prequel], [Active]) VALUES (1106, 2014, CAST(N'2022-03-01T10:11:00.000' AS DateTime), 33, N'Én a C# mesteri szinten című könyvből tanulok.
Keresgéltem a neten magyar nyelvű szakirodalom után, de nem-igen találtam semmit. A könyvben az alapok elég jól benne vannak szerintem. Egyébként én is programoztam C++-ban, de szerintem C#-ben sokkal könnyebb windows ablakos progik létrehozása. Mondjuk most már c++-ban is lehet ''''Windows Forms Application (.NET)'''' projectet készíteni, szal nem kell az MFC-vel kínlódni.
', 0, 1)
GO
INSERT [dbo].[Comments] ([id], [Creator], [Created], [TopicID], [Text], [Prequel], [Active]) VALUES (1107, 2017, CAST(N'2022-03-03T00:00:00.000' AS DateTime), 33, N'hat igen, ha valamit javaban fejlesztesz, akkor azt valoban valtoztatas nelkul futtathatod MACen, linuxon, solarison, windowson is, de a .NET frameworknek csak windowsos portja van, barmilyen meglepo is ez a m$ reszerol :(
amugy a gombok, meg stapobbi elemmel kapcsolatban... nezd meg a borland c++ buildert, es kerdezd meg a m$ot, hogy mi tartott 10 evig? ok mar 10, de legalabb 9 eve csinalnak ilyen appokat IDEket :(
amugy felreertes ne essek, jo a VS 2K3, csak ha 5 evvel korabban jon, akkor meg korszerunek is mondhatnank...', 0, 1)
GO
INSERT [dbo].[Comments] ([id], [Creator], [Created], [TopicID], [Text], [Prequel], [Active]) VALUES (1108, 2014, CAST(N'2022-03-03T08:12:00.000' AS DateTime), 33, N'Lenne is egy kérdésem: Kivételkezelés.

Számomra ez egy bonyolult téma. Vajon használhatok kivételt az előre várt problémákra is? Honnan tudom, hogy melyik kivétel a ''''megfelelő'''' az eldobhatók közül és lehet ezeket rangsorolni, hogy ne mindent dobjon el, ha már nem kell?

(Lehet, hogy a kérdések buták, de igazán nem vagyok othon az ilyesmiben.)', 0, 1)
GO
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
SET IDENTITY_INSERT [dbo].[Topics] ON 
GO
INSERT [dbo].[Topics] ([id], [Parent], [Name], [Created], [Creator]) VALUES (32, 0, N'Programozás', CAST(N'2022-01-01T00:00:00.000' AS DateTime), 2014)
GO
INSERT [dbo].[Topics] ([id], [Parent], [Name], [Created], [Creator]) VALUES (33, 32, N'C#', CAST(N'2022-01-02T00:00:00.000' AS DateTime), 2015)
GO
INSERT [dbo].[Topics] ([id], [Parent], [Name], [Created], [Creator]) VALUES (34, 32, N'Python', CAST(N'2022-02-02T00:00:00.000' AS DateTime), 2015)
GO
INSERT [dbo].[Topics] ([id], [Parent], [Name], [Created], [Creator]) VALUES (35, 32, N'Java', CAST(N'2022-02-01T00:00:00.000' AS DateTime), 2015)
GO
SET IDENTITY_INSERT [dbo].[Topics] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([id], [Name], [Username], [Password], [Role]) VALUES (2014, N'Thomas Anderson', N'Neo', N'517dc00f10cb25b980e9d564baf8e65753bf0e4f97c8834937abb3337b4aa951b30eedf37b8afb4e31e5ffa388f30bdb9fdf60a96355bda552e4f892d47e4d8d', N'Admin')
GO
INSERT [dbo].[Users] ([id], [Name], [Username], [Password], [Role]) VALUES (2015, N'Henry Dorsett Case', N'Case', N'78a83bf4e0d8f6b2d3cae6dd7c70619e486420075b0638b95c030b4b9e5dd6aa4e0ffb04c0fc2657496aa98ea81a2ec4da7f1cc2ce46bafa25e1fc83ea144a2c', N'Editor')
GO
INSERT [dbo].[Users] ([id], [Name], [Username], [Password], [Role]) VALUES (2017, N'Rick Deckard', N'Console', N'e9ba822b5ee8de40d5acd4f8654d45a24a3cc68110c8960d7f0bbc938a8fca07e78043585da5dde9fa928610999bbc4044bc3fe9b169de8aca60b27aaa342680', N'User')
GO
INSERT [dbo].[Users] ([id], [Name], [Username], [Password], [Role]) VALUES (2018, N'William Henry Gates III', N'Bill', N'cab4f6f6daa9a3c167277135ede59a85480b19095887d3a2daa822a8c795252c4e628440a537daa4cda0f337c185a59acd9cfb13b8dc87a937644b7a7ec4529d', N'User')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Comments] ADD  CONSTRAINT [DF_Comment_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Topic] FOREIGN KEY([TopicID])
REFERENCES [dbo].[Topics] ([id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comment_Topic]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User] FOREIGN KEY([Creator])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comment_User]
GO
ALTER TABLE [dbo].[Topics]  WITH CHECK ADD  CONSTRAINT [FK_Topic_User] FOREIGN KEY([Creator])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Topics] CHECK CONSTRAINT [FK_Topic_User]
GO
USE [master]
GO
ALTER DATABASE [CommentsDB] SET  READ_WRITE 
GO
