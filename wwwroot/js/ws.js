//WebSocket declaration and initialisation
var socket = new WebSocket("wss://localhost:5001/ws");
//
socket.onopen = function(mesg){
    wsOpen(mesg);
}
socket.onmessage = function(mesg){
    wsGetMesg(mesg);
}
socket.onclose = function(mesg){
    wsClose(mesg);
}
socket.onerror = function(mesg){
    wsError(mesg);
}
//
function wsOpen(){
    console.log("Connected to WebSocket at ........");
}
function wsClose(){
    socket.close();
    console.log("Closed connection to ........");
}
function wsError(mesg){
    console.error(mesg);
}
function wsSendMesg(){
    var imesg = document.getElementById("input-mesg").value;
    socket.send(imesg);
    console.log(`Sent message: "${imesg}"`);
}
function wsGetMesg(mesg){
    document.getElementById("respond-mesg").innerHTML = mesg.data;
    console.log(`Received message: "${mesg.data}"`)
}