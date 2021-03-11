var activeUser;
function setActiveUser(id) {
  activeUser = id;
}

//WebSocket declaration and initialisation
var socket = new WebSocket("wss://localhost:5001/ws");
//
socket.onopen = function (mesg) {
  wsOpen(mesg);
};
socket.onmessage = function (mesg) {
  wsGetMesg(mesg);
};
socket.onclose = function (mesg) {
  wsClose(mesg);
};
socket.onerror = function (mesg) {
  wsError(mesg);
};
//
<<<<<<< HEAD
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
            newElm.innerHTML = privMesg.detail;
            document.getElementById("mesg-output").appendChild(newElm);
            break;
        case "user_online":
            SetUserStatus(obj.data, true);
            break;
        case "user_offline":
            SetUserStatus(obj.data, false);
            break;    
        default:
            break;
    }
=======
function wsOpen() {
  console.log("Connected to WebSocket at ........");
}
function wsClose() {
  socket.close();
  console.log("Closed connection to ........");
}
function wsError(mesg) {
  console.error(mesg);
}
function wsSendMesg(data) {
  socket.send(JSON.stringify(data));
  console.log(`Sent message: "${JSON.stringify(data)}"`);
}
function wsGetMesg(mesg) {
  var obj = JSON.parse(mesg.data);
  console.log(`Received message: "${mesg.data}"`);
  switch (obj.type) {
    case "recv_private_message":
      var privMesg = JSON.parse(obj.data);
      var newElm = document.createElement("p");
      newElm.innerHTML = privMesg.detail;
      document.getElementById("mesg-output").appendChild(newElm);
      break;
    default:
      break;
  }
>>>>>>> a83d70e96dfd80180622c9c280ba2df9709e7e34
}
function SetUserStatus(id, status){
    var elm = document.getElementById(`status-${id}`);
    if(status){
        elm.innerHTML = "Online";
        elm.style.color = "green";
    } else {
        elm.innerHTML = "Offline";
        elm.style.color = "red";
    }
}

function sendMesg() {
  var mesg = document.getElementById("field-mesg-input").value;
  var privMesg = new PrivateMessage(activeUser, mesg);
  var obj = new JSONGeneric("sent_private_message", JSON.stringify(privMesg));
  wsSendMesg(obj);
}
