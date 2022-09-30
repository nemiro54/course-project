CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "AspNetRoles" (
    "Id" TEXT NOT NULL,
    "Name" TEXT NULL,
    "NormalizedName" TEXT NULL,
    "ConcurrencyStamp" TEXT NULL,
    CONSTRAINT "PK_AspNetRoles" PRIMARY KEY ("Id")
);

CREATE TABLE "AspNetUsers" (
    "Id" TEXT NOT NULL,
    "UserName" TEXT NULL,
    "NormalizedUserName" TEXT NULL,
    "Email" TEXT NULL,
    "NormalizedEmail" TEXT NULL,
    "EmailConfirmed" INTEGER NOT NULL,
    "PasswordHash" TEXT NULL,
    "SecurityStamp" TEXT NULL,
    "ConcurrencyStamp" TEXT NULL,
    "PhoneNumber" TEXT NULL,
    "PhoneNumberConfirmed" INTEGER NOT NULL,
    "TwoFactorEnabled" INTEGER NOT NULL,
    "LockoutEnd" TEXT NULL,
    "LockoutEnabled" INTEGER NOT NULL,
    "AccessFailedCount" INTEGER NOT NULL,
    CONSTRAINT "PK_AspNetUsers" PRIMARY KEY ("Id")
);

CREATE TABLE "AspNetRoleClaims" (
    "Id" INTEGER NOT NULL,
    "RoleId" TEXT NOT NULL,
    "ClaimType" TEXT NULL,
    "ClaimValue" TEXT NULL,
    CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserClaims" (
    "Id" INTEGER NOT NULL,
    "UserId" TEXT NOT NULL,
    "ClaimType" TEXT NULL,
    "ClaimValue" TEXT NULL,
    CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserLogins" (
    "LoginProvider" TEXT NOT NULL,
    "ProviderKey" TEXT NOT NULL,
    "ProviderDisplayName" TEXT NULL,
    "UserId" TEXT NOT NULL,
    CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey"),
    CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserRoles" (
    "UserId" TEXT NOT NULL,
    "RoleId" TEXT NOT NULL,
    CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId"),
    CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserTokens" (
    "UserId" TEXT NOT NULL,
    "LoginProvider" TEXT NOT NULL,
    "Name" TEXT NOT NULL,
    "Value" TEXT NULL,
    CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name"),
    CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" ("RoleId");

CREATE UNIQUE INDEX "RoleNameIndex" ON "AspNetRoles" ("NormalizedName");

CREATE INDEX "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" ("UserId");

CREATE INDEX "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" ("UserId");

CREATE INDEX "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" ("RoleId");

CREATE INDEX "EmailIndex" ON "AspNetUsers" ("NormalizedEmail");

CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" ("NormalizedUserName");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('00000000000000_CreateIdentitySchema', '6.0.9');

COMMIT;

START TRANSACTION;

ALTER TABLE "AspNetUserTokens" ALTER COLUMN "Value" TYPE text;

ALTER TABLE "AspNetUserTokens" ALTER COLUMN "Name" TYPE character varying(128);

ALTER TABLE "AspNetUserTokens" ALTER COLUMN "LoginProvider" TYPE character varying(128);

ALTER TABLE "AspNetUserTokens" ALTER COLUMN "UserId" TYPE text;

ALTER TABLE "AspNetUsers" ALTER COLUMN "UserName" TYPE character varying(256);

ALTER TABLE "AspNetUsers" ALTER COLUMN "TwoFactorEnabled" TYPE boolean;

ALTER TABLE "AspNetUsers" ALTER COLUMN "SecurityStamp" TYPE text;

ALTER TABLE "AspNetUsers" ALTER COLUMN "PhoneNumberConfirmed" TYPE boolean;

ALTER TABLE "AspNetUsers" ALTER COLUMN "PhoneNumber" TYPE text;

ALTER TABLE "AspNetUsers" ALTER COLUMN "PasswordHash" TYPE text;

ALTER TABLE "AspNetUsers" ALTER COLUMN "NormalizedUserName" TYPE character varying(256);

ALTER TABLE "AspNetUsers" ALTER COLUMN "NormalizedEmail" TYPE character varying(256);

ALTER TABLE "AspNetUsers" ALTER COLUMN "LockoutEnd" TYPE timestamp with time zone;

ALTER TABLE "AspNetUsers" ALTER COLUMN "LockoutEnabled" TYPE boolean;

ALTER TABLE "AspNetUsers" ALTER COLUMN "EmailConfirmed" TYPE boolean;

ALTER TABLE "AspNetUsers" ALTER COLUMN "Email" TYPE character varying(256);

ALTER TABLE "AspNetUsers" ALTER COLUMN "ConcurrencyStamp" TYPE text;

ALTER TABLE "AspNetUsers" ALTER COLUMN "AccessFailedCount" TYPE integer;

ALTER TABLE "AspNetUsers" ALTER COLUMN "Id" TYPE text;

ALTER TABLE "AspNetUserRoles" ALTER COLUMN "RoleId" TYPE text;

ALTER TABLE "AspNetUserRoles" ALTER COLUMN "UserId" TYPE text;

ALTER TABLE "AspNetUserLogins" ALTER COLUMN "UserId" TYPE text;

ALTER TABLE "AspNetUserLogins" ALTER COLUMN "ProviderDisplayName" TYPE text;

ALTER TABLE "AspNetUserLogins" ALTER COLUMN "ProviderKey" TYPE character varying(128);

ALTER TABLE "AspNetUserLogins" ALTER COLUMN "LoginProvider" TYPE character varying(128);

ALTER TABLE "AspNetUserClaims" ALTER COLUMN "UserId" TYPE text;

ALTER TABLE "AspNetUserClaims" ALTER COLUMN "ClaimValue" TYPE text;

ALTER TABLE "AspNetUserClaims" ALTER COLUMN "ClaimType" TYPE text;

ALTER TABLE "AspNetUserClaims" ALTER COLUMN "Id" TYPE integer;
ALTER TABLE "AspNetUserClaims" ALTER COLUMN "Id" DROP DEFAULT;
ALTER TABLE "AspNetUserClaims" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY;

ALTER TABLE "AspNetRoles" ALTER COLUMN "NormalizedName" TYPE character varying(256);

ALTER TABLE "AspNetRoles" ALTER COLUMN "Name" TYPE character varying(256);

ALTER TABLE "AspNetRoles" ALTER COLUMN "ConcurrencyStamp" TYPE text;

ALTER TABLE "AspNetRoles" ALTER COLUMN "Id" TYPE text;

ALTER TABLE "AspNetRoleClaims" ALTER COLUMN "RoleId" TYPE text;

ALTER TABLE "AspNetRoleClaims" ALTER COLUMN "ClaimValue" TYPE text;

ALTER TABLE "AspNetRoleClaims" ALTER COLUMN "ClaimType" TYPE text;

ALTER TABLE "AspNetRoleClaims" ALTER COLUMN "Id" TYPE integer;
ALTER TABLE "AspNetRoleClaims" ALTER COLUMN "Id" DROP DEFAULT;
ALTER TABLE "AspNetRoleClaims" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20220930153005_ConectPostgreSQL', '6.0.9');

COMMIT;

