#addin "nuget:?package=Cake.Json"
#addin "nuget:?package=Newtonsoft.Json&version=11.0.2"
#addin "nuget:?package=Cake.SqlServer"

public class DatabaseSettings
{
    public string ConnectionString { get; set; }
    public string DbCreationPath { get; set; }
}

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "CreateDatabase");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////
Task("CreateDatabase")
    .Does(() =>
{
    var settings = DeserializeJsonFromFile<DatabaseSettings>(@"settings.json");
    string dbName = "AntiBlog";


    if(DatabaseExists(settings.ConnectionString, dbName)){
        Information("Database already exist");
    }
    else
    {
      var createSettings = new CreateDatabaseSettings()
                        .WithPrimaryFile(settings.DbCreationPath + "AntiBlog.mdf")
                        .WithLogFile(settings.DbCreationPath + "AntiBlog.ldf");

      CreateDatabase(settings.ConnectionString, dbName, createSettings);  
    }
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
