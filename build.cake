#addin "nuget:?package=Cake.Json"
#addin "nuget:?package=Newtonsoft.Json&version=11.0.2"
#addin "nuget:?package=Cake.SqlServer"

#load "ConfigModels/models.cake"
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "create-tables");
var settings = DeserializeJsonFromFile<DatabaseSettings>(@"settings.json");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

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
                        .WithPrimaryFile(settings.DbCreationPath + "AntiBlog.mdf")
                        .WithLogFile(settings.DbCreationPath + "AntiBlog.ldf");

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