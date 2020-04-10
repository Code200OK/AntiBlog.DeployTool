#addin "nuget:?package=Cake.Json"
#addin "nuget:?package=Newtonsoft.Json&version=11.0.2"
#addin "nuget:?package=Cake.SqlServer"

#load "ConfigModels/models.cake"
#load "DBEntities/*.cake"
#load "sql/sql utils/QueryInteraction.cake"
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "populate-data");
var settings = DeserializeJsonFromFile<DatabaseSettings>(@"settings.json");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("populate-data")
.IsDependentOn("create-tables")
    .Does(() =>
{
    QueryInteraction.Insert<Role>("Role", settings.TestConnString);
});


Task("create-tables")
.IsDependentOn("create-database")
    .Does(() =>
{
    ExecuteSqlFile(settings.ConnectionString, "sql/ddl.sql");  
});


Task("create-database")
    .Does(() =>
{
    if(DatabaseExists(settings.ConnectionString, settings.DbName)){
        Information("Database already exist");
    }
    else
    {
      var createSettings = new CreateDatabaseSettings()
                        .WithPrimaryFile(settings.DbCreationPath + settings.DbName + ".mdf")
                        .WithLogFile(settings.DbCreationPath + settings.DbName + ".ldf");

      CreateDatabase(settings.ConnectionString, settings.DbName, createSettings);  
    }
});

Task("drop-database")
    .Does(() =>
{
    DropDatabase(settings.ConnectionString, settings.DbName);
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);