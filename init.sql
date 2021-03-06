SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: SIGame; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "SIGame" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Russian_Russia.1251';


ALTER DATABASE "SIGame" OWNER TO postgres;

\connect "SIGame"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: category; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.category (
    id integer NOT NULL,
    category_name text
);


ALTER TABLE public.category OWNER TO postgres;

--
-- Name: questions; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.questions (
    id integer NOT NULL,
    category_id integer NOT NULL,
    value integer NOT NULL,
    question text NOT NULL,
    answer text NOT NULL
);


ALTER TABLE public.questions OWNER TO postgres;

--
-- Name: questions_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.questions_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.questions_id_seq OWNER TO postgres;

--
-- Name: questions_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.questions_id_seq OWNED BY public.questions.id;


--
-- Name: sessions; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sessions (
    id integer NOT NULL,
    ip text NOT NULL
);


ALTER TABLE public.sessions OWNER TO postgres;

--
-- Name: sessions_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.sessions_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.sessions_id_seq OWNER TO postgres;

--
-- Name: sessions_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.sessions_id_seq OWNED BY public.sessions.id;


--
-- Name: questions id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.questions ALTER COLUMN id SET DEFAULT nextval('public.questions_id_seq'::regclass);


--
-- Name: sessions id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sessions ALTER COLUMN id SET DEFAULT nextval('public.sessions_id_seq'::regclass);


--
-- Data for Name: category; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.category (id, category_name) FROM stdin;
1	sports
2	animals
3	people
4	television
5	history
6	food
\.


--
-- Data for Name: questions; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.questions (id, category_id, value, question, answer) FROM stdin;
1	1	200	Ben Crenshaw & Phil Mickelson are the only 3-time winners of this college sports championship tournament	golf
2	1	200	Tom Landry coached this team to 270 wins during his 29-year career	Dallas Cowboys
3	1	400	In this game, an entry sport to baseball, the batter hits the ball that rests atop a tube	T-ball
4	1	400	It is the sport played professionally by Andre Agassi	tennis
5	1	600	What the Europeans call association football, we call this	soccer
6	1	600	In golf it is the proper word to yell when your ball is headed toward another player	fore
7	1	800	This winter Olympic sport is contested in 2-man & 4-man events	Bobsled
8	1	800	Since the 1950s players from this continent have been the dominant force in table tennis	Asia
9	1	1000	This piece of fencing equipment is made of strong wire mesh & may be padded	mask
10	1	1000	Four letter word for all the gear used for controlling a horse in harness racing	tack
11	2	200	It is the only Asian great ape	orangutan
12	2	200	It is what an archerfish shoots to bring down insects	water
13	2	400	This predator that comes in gray and red types is a bit camera-shy, but its tracks are seen here	wolf
14	2	400	It is the amused African mammal heard here	hyena
15	2	600	On the squirrel monkey of South America, this may be 16 inches long	tail
16	2	600	Animal that was the main staple of the Plains Indians economy	buffalo
17	2	800	The bulls of this tusked aquatic mammal also known as the morse may weigh over 3,000 pounds	walrus
18	2	800	While on safari in Africa, your guide may point out a dik-dik, a small one of these animals	antelope
19	2	1000	Its legs are 6 feet long & its neck can be even longer	giraffe
20	2	1000	Bactrian & dromedary are the 2 main types of this desert creature	camel
21	3	200	Kim Jong Un has succeeded his father as the leader of this country	North Korea
22	3	200	In July 2011 this former First Lady passed away in Rancho Mirage, California at the age of 93	Betty Ford
23	3	400	At Comic-Con 2011, Adam West, Burt Ward & Julie Newmar reunited for a panel on this TV series	Batman
24	3	400	This husband of Gabrielle Giffords piloted the final mission of the space shuttle Endeavour	Mark Kelly
25	3	600	Once second in line to the British throne, today he is fourth	Andrew
26	3	600	In April 2010 People reported this daughter of Tom Cruise is turning 4 with a style all her own	Suri
27	3	800	Seen here, this Spavinaw, Oklahoma native joined the Yankees in 1951	Mickey Mantle
28	3	800	He wore a kilt when he married Madonna in a Scottish castle	Guy Ritchie
29	3	1000	In 1947 this Oklahoma faith healer began his Healing Waters Ministry	Oral Roberts
30	3	1000	In 1997 People was on the crime beat with this victim	Versace
31	4	200	Kyle Chandler is the coach of a small-town high school football team on this critically acclaimed TV show	Friday Night Lights
32	4	200	Just when Wentworth Miller thought he was out, they pull him back--into jail--on this Fox drama	Prison Break
33	4	400	Starbuck is a woman on the Sci-Fi Channel version of this series	Battlestar Galactica
34	4	400	Mick St. John is a P.I. who sucks--blood, that is--on this vampirific CBS show	Moonlight
35	4	600	Jack, Chrissy & Janet shared a Santa Monica apartment on this sitcom	Three Company
36	4	600	He is played Pete Ryan, Alexander Mundy & Jonathan Hart	Robert Wagner
37	4	800	This man, seen here, now does his presiding on television	Mayor Koch
38	4	800	In 1997 this show is season premiere drew 43 million viewers to NBC	ER
39	4	1000	The owner of the stud farm where this "talking" horse was bred is seeking landmark status for the site	Mr. Ed
40	4	1000	In 1996 he won the first acting Emmy for a cable TV series for playing Artie on "The Larry Sanders Show"	Rip Torn
41	5	200	70 delegates were chosen for this 1781 gathering; 55 attended & 39 ended up signing	Constitutional Convention
42	5	200	Protests in the Philippines in 1986 drove this longtime leader into exile	Marcos
43	5	400	In 2013 this Brazilian president was not happy that the U.S. was listening in on her phone calls	Dilma Rousseff
44	5	400	In the 11th century she was the occasionally naked in public wife of Earl Leofric	Lady Godiva
45	5	600	On Aug. 7, 1964 this resolution passed in the House, 414 to zero	Gulf of Tonkin resolution
46	5	600	The German Empire had this "Iron Chancellor" from 1871 to 1890	Bismarck
47	5	800	Napoleon & his troops captured Cairo in the 1798 battle of these landmarks	Pyramids
48	5	800	Marigalante was another name for this 1492 flagship	the Santa Maria
49	5	1000	This king who put his seal on a historic 13th Century document was known as Lackland	King John I
50	5	1000	Delegates from 34 countries attended this body final session April 18, 1946	League of Nations
51	6	200	Served in chicken soup, knaidel is another name for this Jewish favorite	matzo ball
52	6	200	Vitelottes, a type of these tubers, have almost-black skin & purple flesh	potato
53	6	400	A favorite since ancient times, this Chinese fruit is called a "nut" when it is dried	lychee
54	6	400	Munich traditional Weisswurst, a veal sausage, is naked without Senf, German for this	mustard
55	6	600	Meat on a stick sounds better if you use the French term, "en" this	brochette
56	6	600	Poutine, a Montreal treat, is covered with gravy & this solid element of cheese	curd
57	6	800	Oh baby, in 1953 Ore-Ida invented this hash brown product	tater tots
58	6	800	Whether red, black or Nassau, a grouper is a type of this	fish
59	6	1000	To make provolone, use milk from this animal	cow
60	6	1000	From the Italian word for rice, it is a rice dish cooked with broth & often grated cheese	Risotto
\.


--
-- Data for Name: sessions; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sessions (id, ip) FROM stdin;
1	testip
2	testip2
\.


--
-- Name: questions_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.questions_id_seq', 60, true);


--
-- Name: sessions_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.sessions_id_seq', 2, true);


--
-- Name: category category_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.category
    ADD CONSTRAINT category_pkey PRIMARY KEY (id);


--
-- Name: questions questions_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.questions
    ADD CONSTRAINT questions_pkey PRIMARY KEY (id);


--
-- Name: sessions sessions_ip_unique; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sessions
    ADD CONSTRAINT sessions_ip_unique UNIQUE (ip);


--
-- Name: sessions sessions_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sessions
    ADD CONSTRAINT sessions_pkey PRIMARY KEY (id);


--
-- PostgreSQL database dump complete
--

