
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
<<<<<<< HEAD
-- Date Created: 03/19/2015 08:44:34
-- Generated from EDMX file: C:\Users\Appzone\Documents\Visual Studio 2013\Projects\Contact\Contact.Core\DataAccess\DataModel.edmx
=======
-- Date Created: 06/19/2014 11:18:31
-- Generated from EDMX file: G:\Contact\Contact.Core\DataAccess\DataModel.edmx
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ContactDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Employee_User]', 'F') IS NOT NULL
<<<<<<< HEAD
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employee_User];
=======
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK_Employee_User];
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
GO
IF OBJECT_ID(N'[dbo].[FK_RolePermissions_Permission]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RolePermissions] DROP CONSTRAINT [FK_RolePermissions_Permission];
GO
IF OBJECT_ID(N'[dbo].[FK_RolePermissions_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RolePermissions] DROP CONSTRAINT [FK_RolePermissions_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_Role]', 'F') IS NOT NULL
<<<<<<< HEAD
    ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRole_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRole_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Employee_User1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employee_User1];
=======
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_User];
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

<<<<<<< HEAD
IF OBJECT_ID(N'[dbo].[Contacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contacts];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Permissions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permissions];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
=======
IF OBJECT_ID(N'[dbo].[Contact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contact];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[Permission]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permission];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
GO
IF OBJECT_ID(N'[dbo].[RolePermissions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RolePermissions];
GO
<<<<<<< HEAD
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[UserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRoles];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
=======
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[UserRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRole];
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [ContactID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [PhoneNumber] nvarchar(50)  NOT NULL,
    [EmailAddress] nvarchar(50)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [UserID] int  NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
<<<<<<< HEAD
    [LastName] nvarchar(50)  NOT NULL,
    [DeptID] int  NOT NULL
=======
    [LastName] nvarchar(50)  NOT NULL
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
);
GO

-- Creating table 'Permissions'
CREATE TABLE [dbo].[Permissions] (
    [PermissionID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(50)  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(50)  NULL
);
GO

-- Creating table 'RolePermissions'
CREATE TABLE [dbo].[RolePermissions] (
    [RolePermissionID] int IDENTITY(1,1) NOT NULL,
    [RoleID] int  NOT NULL,
    [PermissionID] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
<<<<<<< HEAD
    [Password] nvarchar(50)  NOT NULL,
    [Username] nvarchar(50)  NULL
=======
    [Password] nvarchar(50)  NOT NULL
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
);
GO

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [UserRoleID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [RoleID] int  NOT NULL
);
GO

<<<<<<< HEAD
-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [DeptID] int IDENTITY(1,1)  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Description] nvarchar(50)  NULL
);
GO

=======
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ContactID] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY CLUSTERED ([ContactID] ASC);
GO

-- Creating primary key on [UserID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [PermissionID] in table 'Permissions'
ALTER TABLE [dbo].[Permissions]
ADD CONSTRAINT [PK_Permissions]
    PRIMARY KEY CLUSTERED ([PermissionID] ASC);
GO

-- Creating primary key on [RoleID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [RolePermissionID] in table 'RolePermissions'
ALTER TABLE [dbo].[RolePermissions]
ADD CONSTRAINT [PK_RolePermissions]
    PRIMARY KEY CLUSTERED ([RolePermissionID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [UserRoleID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([UserRoleID] ASC);
GO

<<<<<<< HEAD
-- Creating primary key on [DeptID] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([DeptID] ASC);
GO

=======
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employee_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PermissionID] in table 'RolePermissions'
ALTER TABLE [dbo].[RolePermissions]
ADD CONSTRAINT [FK_RolePermissions_Permission]
    FOREIGN KEY ([PermissionID])
    REFERENCES [dbo].[Permissions]
        ([PermissionID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RolePermissions_Permission'
CREATE INDEX [IX_FK_RolePermissions_Permission]
ON [dbo].[RolePermissions]
    ([PermissionID]);
GO

-- Creating foreign key on [RoleID] in table 'RolePermissions'
ALTER TABLE [dbo].[RolePermissions]
ADD CONSTRAINT [FK_RolePermissions_Role]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RolePermissions_Role'
CREATE INDEX [IX_FK_RolePermissions_Role]
ON [dbo].[RolePermissions]
    ([RoleID]);
GO

-- Creating foreign key on [RoleID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRole_Role]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_Role'
CREATE INDEX [IX_FK_UserRole_Role]
ON [dbo].[UserRoles]
    ([RoleID]);
GO

-- Creating foreign key on [UserID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRole_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_User'
CREATE INDEX [IX_FK_UserRole_User]
ON [dbo].[UserRoles]
    ([UserID]);
GO

<<<<<<< HEAD
-- Creating foreign key on [DeptID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employee_User1]
    FOREIGN KEY ([DeptID])
    REFERENCES [dbo].[Departments]
        ([DeptID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_User1'
CREATE INDEX [IX_FK_Employee_User1]
ON [dbo].[Employees]
    ([DeptID]);
GO

=======
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------