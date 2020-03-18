#addin "nuget:?package=Cake.Json"
#addin "nuget:?package=Newtonsoft.Json&version=11.0.2"
#addin "nuget:?package=Cake.SqlServer"

#load "ConfigModels/models.cake"
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "create-database");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////
Task("create-database")
    .Does(() =>
{
    var settings = DeserializeJsonFromFile<DatabaseSettings>(@"settings.json");
  
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

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
