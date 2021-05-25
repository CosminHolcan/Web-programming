INSERT INTO users(username, password)
VALUES ('cezar', 'cez07'),
('mircea', 'batran')

CREATE TABLE sessions
(
	id smallserial primary key,
	userid smallint references users(id),
	"noQuestionsPerPage" smallint not null,
	"noTotalQuestions" smallint not null,
	active boolean
)

CREATE TABLE asset
(
	id smallserial primary key,
	userid smallint references users(id),
	description varchar(255) not null,
	value int 
)

CREATE TABLE question
(
	id smallserial primary key,
	question varchar(255) not null,
	answer1 varchar(255) not null,
	answer2 varchar(255) not null,
	answer3 varchar(255) not null,
	correct smallserial constraint correct_range check (correct >=1 and correct <=3)
)

INSERT INTO question(question, answer1, answer2, answer3, correct)
VALUES ('Presedintele Romaniei este ?', 'Klaus Iohannis', 'Stefan cel Mare', 'Vlad Tepes', 1),
('Cel mai lung fluviu din lume ?', 'Amazon', 'Nil', 'Fluviul Galben', 2),
('Capitala Scotiei ?', 'Edinburgh', 'Glasgow', 'Manchester', 1),
('In ce an s-a scufundat Titanicul ?', '1910', '1914', '1912', 3),
('In ce an s-a nascut Michael Jackson ?', '1950', '1958', '1964', 2),
('Ce actor a castigat Oscarul in 1993 si 1994 ?', 'Robert de Niro', 'Al Pacino', 'Tom Hanks', 3),
('Echipa cu cele mai multe trofee Champions League ?', 'Real Madrid', 'Barcelona', 'Bayern Munchen', 1),
('Tara Soarelui Rasare este ?', 'Japnoa', 'China', 'Coreea de Sud', 1),
('Napoleon Bonaparte a murit in anul ?', '1802', '1821', '1864', 2),
('Tara cu capitala Reykjavik ?', 'Nigeria', 'Danemarca', 'Islanda', 3)

