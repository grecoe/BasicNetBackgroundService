# BasicNetBackgroundService

This project is a simple .NET based BackgrounService which shows how to use dependency injection for various objects. 

Some are auto created by the Service framework, others you must generate.

Things to pay attention to:

|||
|--|--|
|appsettings.json|Those configuration pieces we need that DO NOT contain a secret EVER!|
|Program.cs|This is where all the "magic" happens to create objects.|
| Worker/Worker.cs|The actual background service injected with objects required, in particular an IEnumberable of IPersistData objects.|
|Models/|Implementations of the specialized configuration objects needed by the various IPersistData implementations along with the IPersistData implementations themselves.|

Have fun!
