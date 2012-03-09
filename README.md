NodeWorker is a c# console application wrapper to run node.js code as a background worker on AppHarbor.

To use it, simple clone the project, add your node.js code into the app folder and push the whole thing to AppHarbor.

AppHarbor will build the exe and run it as per a regular c# background worker.

A couple of things to watch.

* By default the command `node app/index.js` is run, if you need a different entry point or more arguments, make sure you add them.  
* Make sure the code in your app folder is set to copy into the build folder.  
* Your <appSettings/> section will be copied into the node `process.env` hash similar to `iisnode`
* There is no console logging supported. Howeveryou can use the logentries add-on from AppHarbor with the nodejs client provided by logentries if you need to track what is happening.