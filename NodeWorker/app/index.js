// Starting point for your node.js app
// Make sure all files are set to copy into the output dir
// Commit all npm modules in your repo as AppHarbor does not support 'npm install' yet

setTimeout(function () {
    // Simulate doing ome work by waiting a few seconds
    // Exit with a non-zero code to have your worked run again
    // Exit with a zero code to have your worker stopped until your next
    process.exit(0);
}, 5000);