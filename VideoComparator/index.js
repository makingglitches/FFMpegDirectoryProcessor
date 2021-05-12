var express = require('express');
var app=express();
var fs=require('fs');
var cors = require('cors');
var bodyparser = require('body-parser');


var olddir=String.raw`C:\Users\John\Desktop\Combined Photos etc\mp4sonserver`;
var newdir=String.raw`C:\Users\John\Desktop\Combined Photos etc\mp4spulled`;

console.log(olddir);

const fileUrl = require('file-url');

app.use(bodyparser.json());


app.options("/downloadscript", cors());

// body is reached with standard cors for form encoded data, preflight request is complained about
// otherwise hence the app.options duplicate for this request.
app.post("/downloadscript",cors(),function(req,res)
{
    res.contentType("text/plain");

    var matchedfiles = req.body;
    console.log(req.body); 

    var script = "cd &quot;"+  String.raw`C:\Users\John\Desktop\Combined Photos etc\mp4s`+"&quot;\n<br>";


    for(var i in matchedfiles)
    {
        script+="rm &quot;"+matchedfiles[i].original+"&quot;\n<br>";
    }
    
    console.log(script);
    res.send(script);
});

app.get("/videos", function(req,res)
{
    // know why npm is a a fricking nightmare even if windows wasnt bugged as shit ?
    // its a direct vector to introduce fucking unwanted code into someones project that
    // does quiet bad shit.
    res.header("Access-Control-Allow-Origin","*");

    var recodedir = newdir;
    var mp4dir = olddir;

    // seriously what kind of retard designed javascrpt ? why would this not be a function call that looked
    // for the limited fucking escaped characters and just convert them back ?
    // course that wouldnt be the best way of doing things
    //FUCKING MICROSOFT !!!! AND ITS DECISION TO RIP OFF UNIX AND USE DIFFERENT 
    // PATH SEPERATORS !!!
    var recodefiles=fs.readdirSync(recodedir);
    var mp4files=fs.readdirSync(mp4dir);
    var finalfiles = [];

    for (var i in recodefiles)
    {
        for (var j in mp4files)
        {
            if (recodefiles[i].replace("_recode.mp4","") == mp4files[j].replace(".mp4","") ||
            recodefiles[i] == mp4files[j])
            {
                finalfiles.push({original:   olddir+"\\" +mp4files[j], recoded: newdir+"\\"+recodefiles[i], match:false});
            }
        }
    }
  
    res.json(finalfiles);
});

app.listen(3000,function()
{
    console.log("And its listening.");
});