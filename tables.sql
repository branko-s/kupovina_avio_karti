//kad nece da se uloguje treba pokrenuti MSSQLSERVER servis

drop table karta
drop table zauzetost_sedista
drop table sediste
drop table let
drop table avion
drop table korisnik
drop table avio_kompanija
drop table aerodrom

create table korisnik
(
	username			varchar(15)		primary key		,
	pass				varchar(15)		not null		unique,
	email				varchar(40)		not null		unique check(email like '%_@___%'),
	ime_prezime			nvarchar(40)	not null		,
	adresa				nvarchar(50)	not null		,
	pol					char(1)							check(pol in ('m','z')), --nije obavezno za unosenje
	tip					char(1)			not null		check(tip in ('u','a'))  --u user, a admin
)

create table aerodrom
(
	id					smallint		primary key		identity(1,1),
	naziv				nvarchar(40)	not null		,
	grad				nvarchar(30)	not null
)

create table avio_kompanija
(
	id					smallint		primary key		identity(1,1),
	naziv				nvarchar(30)	not null
)

create table avion
(
	id					smallint		primary key		identity(1,1),
	naziv				nvarchar(20)	not null		,
	br_red_biz_klase	tinyint			not null		check(br_red_biz_klase>=0),
	br_red_eko_klase	tinyint			not null		check(br_red_eko_klase>=0),
	br_kolona			tinyint			not null		,
	avio_kompanija_id	smallint		not null		foreign key references avio_kompanija(id) on delete cascade on update cascade,
	check(br_kolona > 0 and br_kolona < br_red_biz_klase + br_red_eko_klase)
)

create table let
(
	broj_leta			bigint			primary key		identity(1,1),
	pilot				nvarchar(40)	not null		,
	vreme_polaska		datetimeoffset	not null		,
	vreme_dolaska		datetimeoffset	not null		,
	cena				int				not null		check(cena>=0),
	odrediste			smallint		not null		foreign key references aerodrom(id)	on delete cascade on update cascade,
	destinacija			smallint		not null		foreign key references aerodrom(id) on delete no action on update no action, -- dodati trigger ili stored procedure
	--nepotrebno avio_kompanija_id	smallint		not null		foreign key references avio_kompanija(id) on delete cascade on update cascade,
	avion_id			smallint		not null		foreign key references avion(id) on delete cascade on update cascade
)

create table sediste
(
	red					tinyint			not null		check(red>0),
	kolona				tinyint			not null		check(kolona>0),
	klasa				char(1)			not null		check(klasa='b' or klasa='e'), --b biznis, e ekonomska
	avion_id			smallint		not null		foreign key references avion(id) on delete cascade on update cascade,
	primary key(red, kolona, avion_id)
)

create table zauzetost_sedista
(
	red					tinyint			not null		check(red>0),
	kolona				tinyint			not null		check(kolona>0),
	broj_leta			bigint			not null		foreign key references let(broj_leta) on delete cascade on update cascade,
	zauzetost			char(1)							check(zauzetost='z' or zauzetost='s'), --z zauzeto, s slobodno
	primary key(red, kolona, broj_leta)	
)

create table karta
(
	id					bigint			primary key		identity(1,1),
	putnik				nvarchar(40)	not null		,
	broj_leta			bigint			not null		foreign key references let(broj_leta) on delete cascade on update cascade,
	red					tinyint			not null		check(red>0),
	kolona				tinyint			not null		check(kolona>0),
	klasa				char(1)			not null		check(klasa='b' or klasa='e'),
	kapija				tinyint			not null		check(kapija>0),
	ukupna_cena			int				not null		check(ukupna_cena>=0),
	--primary key(putnik, broj_leta)
)