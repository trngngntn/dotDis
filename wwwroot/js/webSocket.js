var activeUser;
var chatUser = null;

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
            createNewMesg(privMesg.detail ,0);
            break;
        case TYPE_B_INFO_USER_ONL:
            setUserStatus(obj.data, true);
            break;
        case TYPE_B_INFO_USER_OFF:
            setUserStatus(obj.data, false);
            break;
        case TYPE_B_INFO_SEND_ERROR:
            alert("Send Error!");
            break;
        default:
            break;
    }
}
function setUserStatus(id, status){
    var elm = document.getElementById(`status-user-${id}`);
    console.log(`status-user-${id}`);
    if(status){
        elm.style.backgroundColor = "green";
    } else {
        elm.style.backgroundColor = "silver";
    }
}
function setChatUser(id){
  chatUser = id;
  document.getElementById("button-send").disabled = false;
  var obj = new JSONGeneric(TYPE_R_SUBS_PRIVATE_MESG, id);
  wsSendMesg(obj);

}

function sendMesg() {
  var mesg = document.getElementById("field-mesg-input").value;
  if(mesg == "") return;
  var privMesg = new PrivateMessage(activeUser, chatUser, mesg);
  var obj = new JSONGeneric(TYPE_R_SENT_PRIVATE_MESG, JSON.stringify(privMesg));
  wsSendMesg(obj);
  createNewMesg(mesg, 1);
}

function createNewMesg(detail, type){
  var mesgList = document.getElementById("mesg-list");
  var newMesgWrap = document.createElement("div");
  newMesgWrap.className = "mesg-wrap";
  var newMesg = document.createElement("div");
  newMesg.innerHTML = detail;
  newMesg.className = "mesg-bubble";
  if(type === 1){
    newMesg.className+=" mesg-own";
  } else {
    newMesg.className+=" mesg-other";
  }
  newMesgWrap.appendChild(newMesg);
  mesgList.appendChild(newMesgWrap);
}
