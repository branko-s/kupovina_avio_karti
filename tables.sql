create or alter table korisnik
(
	ime_prezime			varchar(40)		not null,
	e-mail				varchar(40)		unique,
	adresa				varchar(50)		not null,
	pol					char(1)			check(pol='m' or pol='z')
	username			varchar(20)		primary key,
	pass				varchar(20)		unique,
	tip					char(1)			check(tip='u' or tip='a')
)

create or alter table aerodrom
(
	id					smallint		primary key,
	naziv				varchar(40)		not null,
	grad				varchar(30)		not null
)

create or alter table avio_kompanija
(
	id					smallint		primary key,
	naziv				varchar(30)		not null,
)

create or alter table let
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

create or alter table avion 
(
	id					smallint		primary key,
	naziv				varchar(20)		not null,
	br_red_biz_klase	smallint		not null,
	br_red_eko_klase	smallint		not null,
	br_kolona			tinyint			not null,
	avio_kompanija_id	smallint		not null,
	foreign key(avio_kompanija_id) references avio_kompanija(id),
	check(br_red_biz_klase>=0),
	check(br_red_eko_klase>=0),
	check(br_kolona>0)
)

create or alter table sediste
(
	red					tinyint			check(), --ispisi fju red <= avion.br_red_biz_klase + avion.br_red_eko_klase
	kolona				tinyint			check(), --ispisi fju kolona <= avion.br_kolona
	klasa				char(1)			check(klasa='b' or klasa='e'), -- if red < avion.br_red_biz_klase klasa=('b' or null) else klasa=('e' or null)
	avion_id			smallint		not null,
	primary key(red, kolona, avion_id)
)

create or alter table zauzetost_sedista
(
	red					tinyint			
	kolona				tinyint			
	broj_leta			bigint			
	zauzetost			char(1)			check(zauzetost='z' or zauzetost='s'),
	primary key(red, kolona),
	foreign key(red) references sediste(red),
	foreign key(kolona) references sediste(kolona),
)

create or alter table karta
(
	putnik				varchar(40)		not null,
	broj_leta			bigint			not null,
	red_sedista			tinyint			not null
	kolona_sedista		tinyint				
	klasa				char(1)
	kapija				tinyint
	ukupna_cena			int
)