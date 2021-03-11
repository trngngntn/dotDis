var activeUser;
var chatUser;

var socket;

function init(id){
  activeUser = id;
  socket = new WebSocket("wss://localhost:5001/ws");
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
}

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
        case TYPE_B_RECV_PRIVATE_MESG:
            var privMesg = JSON.parse(obj.data);
            var newElm = document.createElement("p");
            newElm.innerHTML = privMesg.detail;
            document.getElementById("mesg-output").appendChild(newElm);
            break;
        case TYPE_B_INFO_USER_ONL:
            setUserStatus(obj.data, true);
            break;
        case TYPE_B_INFO_USER_OFF:
            setUserStatus(obj.data, false);
            break;    
        default:
            break;
    }
}
function setUserStatus(id, status){
    var elm = document.getElementById(`status-user-${id}`);
    console.log(`status-user-${id}`);
    if(status){
        elm.innerHTML = "Online";
        elm.style.color = "green";
    } else {
        elm.innerHTML = "Offline";
        elm.style.color = "red";
    }
}
function setChatUser(id){
  chatUser = id;
}

function sendMesg() {
  var mesg = document.getElementById("field-mesg-input").value;
  var privMesg = new PrivateMessage(activeUser, chatUser, mesg);
  var obj = new JSONGeneric("sent_private_message", JSON.stringify(privMesg));
  wsSendMesg(obj);
}
