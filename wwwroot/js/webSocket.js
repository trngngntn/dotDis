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
function wsSendMesg(data){
    socket.send(JSON.stringify(data));
    console.log(`Sent message: "${JSON.stringify(data)}"`);
}
function wsGetMesg(mesg){
    var obj = JSON.parse(mesg.data);
    console.log(`Received message: "${mesg.data}"`);
    switch(obj.type){
        case "recv_private_message":
            var privMesg = JSON.parse(obj.data);
            var newElm = document.createElement("p");
            newElm.innerHTML(privMesg.detail);
            document.getElementById("mesg-output").appendChild(newElm);
            break;
        default:
            break;
    }
}
var activeUser;
function sendMesg(){
    var mesg = document.getElementById("field-mesg-input").value;
    var privMesg = new PrivateMessage(activeUser, mesg);
    var obj = new JSONGeneric("sent_private_message", JSON.stringify(privMesg));
    wsSendMesg(obj);
}