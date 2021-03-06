CREATE TABLE category (
    id integer primary key autoincrement,
    category_name text
);

CREATE TABLE questions (
    id integer primary key autoincrement,
    category_id integer NOT NULL,
    value integer NOT NULL,
    question text NOT NULL,
    answer text NOT NULL
);

CREATE TABLE sessions (
    id integer primary key autoincrement,
    ip text NOT NULL
);

INSERT INTO category VALUES (1, 'sports');
INSERT INTO category VALUES (2, 'animals');
INSERT INTO category VALUES (3, 'people');
INSERT INTO category VALUES (4, 'television');
INSERT INTO category VALUES (5, 'history');
INSERT INTO category VALUES (6, 'food');

INSERT INTO questions VALUES (1, 1, 200, 'Ben Crenshaw & Phil Mickelson are the only 3-time winners of this college sports championship tournament', 'golf');
INSERT INTO questions VALUES (2, 1, 200, 'Tom Landry coached this team to 270 wins during his 29-year career', 'Dallas Cowboys');
INSERT INTO questions VALUES (3, 1, 400, 'In this game, an entry sport to baseball, the batter hits the ball that rests atop a tube', 'T-ball');
INSERT INTO questions VALUES (4, 1, 400, 'It is the sport played professionally by Andre Agassi', 'tennis');
INSERT INTO questions VALUES (5, 1, 600, 'What the Europeans call association football, we call this', 'soccer');
INSERT INTO questions VALUES (6, 1, 600, 'In golf it is the proper word to yell when your ball is headed toward another player', 'fore');
INSERT INTO questions VALUES (7, 1, 800, 'This winter Olympic sport is contested in 2-man & 4-man events', 'Bobsled');
INSERT INTO questions VALUES (8, 1, 800, 'Since the 1950s players from this continent have been the dominant force in table tennis', 'Asia');
INSERT INTO questions VALUES (9, 1, 1000, 'This piece of fencing equipment is made of strong wire mesh & may be padded', 'mask');
INSERT INTO questions VALUES (10, 1, 1000, 'Four letter word for all the gear used for controlling a horse in harness racing', 'tack');
INSERT INTO questions VALUES (11, 2, 200, 'It is the only Asian great ape', 'orangutan');
INSERT INTO questions VALUES (12, 2, 200, 'It is what an archerfish shoots to bring down insects', 'water');
INSERT INTO questions VALUES (13, 2, 400, 'This predator that comes in gray and red types is a bit camera-shy, but its tracks are seen here', 'wolf');
INSERT INTO questions VALUES (14, 2, 400, 'It is the amused African mammal heard here', 'hyena');
INSERT INTO questions VALUES (15, 2, 600, 'On the squirrel monkey of South America, this may be 16 inches long', 'tail');
INSERT INTO questions VALUES (16, 2, 600, 'Animal that was the main staple of the Plains Indians economy', 'buffalo');
INSERT INTO questions VALUES (17, 2, 800, 'The bulls of this tusked aquatic mammal also known as the morse may weigh over 3,000 pounds', 'walrus');
INSERT INTO questions VALUES (18, 2, 800, 'While on safari in Africa, your guide may point out a dik-dik, a small one of these animals', 'antelope');
INSERT INTO questions VALUES (19, 2, 1000, 'Its legs are 6 feet long & its neck can be even longer', 'giraffe');
INSERT INTO questions VALUES (20, 2, 1000, 'Bactrian & dromedary are the 2 main types of this desert creature', 'camel');
INSERT INTO questions VALUES (21, 3, 200, 'Kim Jong Un has succeeded his father as the leader of this country', 'North Korea');
INSERT INTO questions VALUES (22, 3, 200, 'In July 2011 this former First Lady passed away in Rancho Mirage, California at the age of 93', 'Betty Ford');
INSERT INTO questions VALUES (23, 3, 400, 'At Comic-Con 2011, Adam West, Burt Ward & Julie Newmar reunited for a panel on this TV series', 'Batman');
INSERT INTO questions VALUES (24, 3, 400, 'This husband of Gabrielle Giffords piloted the final mission of the space shuttle Endeavour', 'Mark Kelly');
INSERT INTO questions VALUES (25, 3, 600, 'Once second in line to the British throne, today he is fourth', 'Andrew');
INSERT INTO questions VALUES (26, 3, 600, 'In April 2010 People reported this daughter of Tom Cruise is turning 4 with a style all her own', 'Suri');
INSERT INTO questions VALUES (27, 3, 800, 'Seen here, this Spavinaw, Oklahoma native joined the Yankees in 1951', 'Mickey Mantle');
INSERT INTO questions VALUES (28, 3, 800, 'He wore a kilt when he married Madonna in a Scottish castle', 'Guy Ritchie');
INSERT INTO questions VALUES (29, 3, 1000, 'In 1947 this Oklahoma faith healer began his Healing Waters Ministry', 'Oral Roberts');
INSERT INTO questions VALUES (30, 3, 1000, 'In 1997 People was on the crime beat with this victim', 'Versace');
INSERT INTO questions VALUES (31, 4, 200, 'Kyle Chandler is the coach of a small-town high school football team on this critically acclaimed TV show', 'Friday Night Lights');
INSERT INTO questions VALUES (32, 4, 200, 'Just when Wentworth Miller thought he was out, they pull him back--into jail--on this Fox drama', 'Prison Break');
INSERT INTO questions VALUES (33, 4, 400, 'Starbuck is a woman on the Sci-Fi Channel version of this series', 'Battlestar Galactica');
INSERT INTO questions VALUES (34, 4, 400, 'Mick St. John is a P.I. who sucks--blood, that is--on this vampirific CBS show', 'Moonlight');
INSERT INTO questions VALUES (35, 4, 600, 'Jack, Chrissy & Janet shared a Santa Monica apartment on this sitcom', 'Three Company');
INSERT INTO questions VALUES (36, 4, 600, 'He is played Pete Ryan, Alexander Mundy & Jonathan Hart', 'Robert Wagner');
INSERT INTO questions VALUES (37, 4, 800, 'This man, seen here, now does his presiding on television', 'Mayor Koch');
INSERT INTO questions VALUES (38, 4, 800, 'In 1997 this show is season premiere drew 43 million viewers to NBC', 'ER');
INSERT INTO questions VALUES (39, 4, 1000, 'The owner of the stud farm where this "talking" horse was bred is seeking landmark status for the site', 'Mr. Ed');
INSERT INTO questions VALUES (40, 4, 1000, 'In 1996 he won the first acting Emmy for a cable TV series for playing Artie on "The Larry Sanders Show"', 'Rip Torn');
INSERT INTO questions VALUES (41, 5, 200, '70 delegates were chosen for this 1781 gathering; 55 attended & 39 ended up signing', 'Constitutional Convention');
INSERT INTO questions VALUES (42, 5, 200, 'Protests in the Philippines in 1986 drove this longtime leader into exile', 'Marcos');
INSERT INTO questions VALUES (43, 5, 400, 'In 2013 this Brazilian president was not happy that the U.S. was listening in on her phone calls', 'Dilma Rousseff');
INSERT INTO questions VALUES (44, 5, 400, 'In the 11th century she was the occasionally naked in public wife of Earl Leofric', 'Lady Godiva');
INSERT INTO questions VALUES (45, 5, 600, 'On Aug. 7, 1964 this resolution passed in the House, 414 to zero', 'Gulf of Tonkin resolution');
INSERT INTO questions VALUES (46, 5, 600, 'The German Empire had this "Iron Chancellor" from 1871 to 1890', 'Bismarck');
INSERT INTO questions VALUES (47, 5, 800, 'Napoleon & his troops captured Cairo in the 1798 battle of these landmarks', 'Pyramids');
INSERT INTO questions VALUES (48, 5, 800, 'Marigalante was another name for this 1492 flagship', 'the Santa Maria');
INSERT INTO questions VALUES (49, 5, 1000, 'This king who put his seal on a historic 13th Century document was known as Lackland', 'King John I');
INSERT INTO questions VALUES (50, 5, 1000, 'Delegates from 34 countries attended this body final session April 18, 1946', 'League of Nations');
INSERT INTO questions VALUES (51, 6, 200, 'Served in chicken soup, knaidel is another name for this Jewish favorite', 'matzo ball');
INSERT INTO questions VALUES (52, 6, 200, 'Vitelottes, a type of these tubers, have almost-black skin & purple flesh', 'potato');
INSERT INTO questions VALUES (53, 6, 400, 'A favorite since ancient times, this Chinese fruit is called a "nut" when it is dried', 'lychee');
INSERT INTO questions VALUES (54, 6, 400, 'Munich traditional Weisswurst, a veal sausage, is naked without Senf, German for this', 'mustard');
INSERT INTO questions VALUES (55, 6, 600, 'Meat on a stick sounds better if you use the French term, "en" this', 'brochette');
INSERT INTO questions VALUES (56, 6, 600, 'Poutine, a Montreal treat, is covered with gravy & this solid element of cheese', 'curd');
INSERT INTO questions VALUES (57, 6, 800, 'Oh baby, in 1953 Ore-Ida invented this hash brown product', 'tater tots');
INSERT INTO questions VALUES (58, 6, 800, 'Whether red, black or Nassau, a grouper is a type of this', 'fish');
INSERT INTO questions VALUES (59, 6, 1000, 'To make provolone, use milk from this animal', 'cow');
INSERT INTO questions VALUES (60, 6, 1000, 'From the Italian word for rice, it is a rice dish cooked with broth & often grated cheese', 'Risotto');


--
-- Data for Name: sessions; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO sessions VALUES (8, '192.168.1.176:8000');

