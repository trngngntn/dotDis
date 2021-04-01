use `dotDis`;
create table `User`(
	`id` int auto_increment,
    `username` varchar(64) not null unique,
    `displayName` varchar(128) not null,
    `salt` char(16) not null,
    `pwd` char(64) not null,
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

create table `Session`(
    `id` char(16),
	`uid` int,
    constraint `pk_Session` primary key (`id`),
	constraint `fk_uid` foreign key (`uid`) references `User`(id)
);
create table `Private_Mesg`(
	`id` int auto_increment,
    `send_id` int,
    `recv_id` int,
    `created` datetime default now(),
    `detail` varchar(1024),
    constraint `pk_Private_Mesg` primary key (`id`)
 );
 
 select * from `Test`