insert into Test
values(5,'www');

create table `User`(
	`id` int auto_increment,
    `username` varchar(64) not null unique,
    `displayName` varchar(128) not null,
    `salt` binary(128) not null,
    `pwd` binary(512) not null,
    constraint `pk_User` primary key (`id`)
);

create table `Friend`(
	`uid1` int,
    `uid2` int,
    `status` bool default 0,
    constraint `fk_uid1` foreign key (`uid1`) references `User`(id),
    constraint `fk_uid2` foreign key (`uid2`) references `User`(id),
    constraint `pk_Friend` primary key (`uid1`,`uid2`)
);