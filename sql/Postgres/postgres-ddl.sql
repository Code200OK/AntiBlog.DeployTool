CREATE TABLE "Role"
(
    Id   SERIAL      NOT NULL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL
);
    
CREATE TABLE "Status"
(
    Id   SERIAL      NOT NULL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL
);

create table "AppUser"
(
    Id               bigserial     not null primary key,
    Name             varchar(250)  not null,
    Surname          varchar(250)  not null,
    Email            varchar(2048) not null,
    Login            varchar(250)  not null,
    PasswordHash     bytea         not null,
    PasswordSalt     bytea         not null,
    RegistrationDate Date          not null,
    RoleId           integer       not null,
    CONSTRAINT "RoleIdFK" FOREIGN KEY (RoleId)
        REFERENCES "Role" (Id) MATCH FULL
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);

CREATE TABLE "Project"
(
    Id       SERIAL       NOT NULL PRIMARY KEY,
    Name     VARCHAR(100) NOT NULL,
    Color    VARCHAR(30)  NULL,
    UserId   INTEGER      NOT NULL,
    StatusId INTEGER      NOT NULL,
    CONSTRAINT "UserIdFK" FOREIGN KEY (UserId)
        REFERENCES "AppUser" (Id) MATCH FULL
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
    CONSTRAINT "StatusIdFK" FOREIGN KEY (StatusId)
        REFERENCES "Status" (Id) MATCH FULL
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);

CREATE TABLE "UserTask"
(
    Id          SERIAL        NOT NULL PRIMARY KEY,
    Description VARCHAR(8000) NOT NULL,
    Priority    VARCHAR(30)   NOT NULL,
    ProjectTag  VARCHAR(50)   NOT NULL,
    Deadline    DATE          NULL,
    ProjectId   INT           NOT NULL,
    CONSTRAINT "ProjectIdFK" FOREIGN KEY (ProjectId)
        REFERENCES "Project" (Id) MATCH FULL
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);



