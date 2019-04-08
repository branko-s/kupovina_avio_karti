alter table korisnik
(
	ime_prezime			nvarchar(40)	not null,
	email				varchar(40)		unique,
	adresa				nvarchar(50)	not null,
	pol					char(1)			check(pol in ('m','z')),
	username			varchar(20)		primary key,
	pass				varchar(20)		unique,
	tip					char(1)			check(tip in ('u','a'))
)
/*
create table aerodrom
(
	id					smallint		primary key,
	naziv				varchar(40)		not null,
	grad				varchar(30)		not null
)

create table avio_kompanija
(
	id					smallint		primary key,
	naziv				varchar(30)		not null
)

create table avion 
(
	id					smallint		primary key,
	naziv				varchar(20)		not null,
	br_red_biz_klase	smallint		check(br_red_biz_klase>=0),
	br_red_eko_klase	smallint		check(br_red_eko_klase>=0),
	br_kolona			tinyint			check(br_kolona>0),
	avio_kompanija_id	smallint		not null,
	foreign key(avio_kompanija_id) references avio_kompanija(id),
	check(br_red_biz_klase >= 0),
	check(br_red_eko_klase >= 0),
	check(br_kolona > 0 and br_kolona < br_red_biz_klase + br_red_eko_klase)
)

create table let
(
	broj_leta			bigint			primary key,	
	pilot				varchar(40)		not null,
	vreme_polaska		datetimeoffset	not null,
	vreme_dolaska		datetimeoffset	not null,
	cena				int				not null,
	odrediste			smallint		not null,
	destinacija			smallint		not null,
	avio_kompanija_id	smallint		not null,
	avion_id			smallint		not null,
	foreign key(odrediste) references aerodrom(id),
	foreign key(destinacija) references aerodrom(id),
	foreign key(avio_kompanija_id) references avio_kompanija(id),
	foreign key(avion_id) references avion(id),
	check(cena>=0)
)

create table sediste
(
	red					tinyint			check(red>0),
	kolona				tinyint			check(kolona>0),
	klasa				char(1)			check(klasa='b' or klasa='e'),
	avion_id			smallint		not null,
	primary key(red, kolona, avion_id),
	foreign key(avion_id) references avion(id)
)

create table zauzetost_sedista
(
	red					tinyint			check(red>0),
	kolona				tinyint			check(kolona>0),
	broj_leta			bigint			not null,
	zauzetost			char(1)			check(zauzetost='z' or zauzetost='s' or zauzetost=null),
	primary key(red, kolona, broj_leta),
	foreign key(broj_leta) references let(broj_leta)
)

create table karta
(
	putnik				varchar(40)		not null,
	broj_leta			bigint			not null,
	red					tinyint			check(red>0),
	kolona				tinyint			check(kolona>0),
	klasa				char(1)			check(klasa='b' or klasa='e'),
	kapija				tinyint			check(kapija>0),
	ukupna_cena			int				check(ukupna_cena>=0),
	primary key(putnik, broj_leta),
	foreign key(broj_leta) references let(broj_leta)
)*/