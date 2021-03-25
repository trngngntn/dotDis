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
  console.log(`Sent message: "${JSON.stringify(data)}"`);
  socket.send(JSON.stringify(data));

}
function wsGetMesg(mesg){
    var obj = JSON.parse(mesg.data);
    console.log(`Received message: "${mesg.data}"`);
    switch(obj.type){
        case TYPE_B_RECV_PRIVATE_MESG:
            var privMesg = JSON.parse(obj.data);
            createNewMesg(privMesg.detail ,0);
            break;
        case TYPE_B_INFO_PRIVATE_MESG:
            var mesgList = JSON.parse(obj.data);
            console.log(mesgList);
            mesgList.forEach(mesg => {
              if(mesg.sendId == activeUser){
                appendMesg(mesg.detail, 1);
              } else appendMesg(mesg.detail, 0);
            });
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
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function setUserStatus(id, status){
    var elm = document.getElementById(`status-user-${id}`);
    console.log(`status-user-${id}`);
    if(status){
        elm.style.backgroundColor = "green";
    } else {
        elm.style.backgroundColor = "silver";
    }
}
var curPrivateMesgIndex = new Array();
var curChannelMesgIndex;

function setChatUser(id){
  chatUser = id;
  document.getElementById("chat-name").innerHTML = document.getElementById(`uid-${id}-name`).innerHTML;
  var obj = new JSONGeneric(TYPE_R_SUBS_PRIVATE_MESG, `${id}`);
  wsSendMesg(obj);
  clearMesgPane();
  curPrivateMesgIndex[id] = 0;
  loadPrivateMesg(id);
}

function clearMesgPane(){
  var elm = document.getElementById("pane-mesg").innerHTML = "";
}

function loadPrivateMesg(uid){
  var obj = new JSONGeneric(TYPE_R_LOAD_PRIVATE_MESG, `${uid};${curPrivateMesgIndex[uid]}`);
  curPrivateMesgIndex[uid] += 25;
  wsSendMesg(obj);
}

function sendMesg() {
  var mesg = document.getElementById("field-mesg").value;
  if(mesg == "") return;
  var privMesg = new PrivateMessage(activeUser, chatUser, mesg);
  var obj = new JSONGeneric(TYPE_R_SENT_PRIVATE_MESG, JSON.stringify(privMesg));
  wsSendMesg(obj);
  createNewMesg(mesg, 1);
}

function createNewMesg(detail, type){
  var mesgPane = document.getElementById("pane-mesg");
  var newMesgWrap = document.createElement("div");
  newMesgWrap.className = " bubble-wrapper";
  var newMesg = document.createElement("div");
  newMesg.innerHTML = detail;
  newMesg.className = "bubble-mesg";
  if(type === 1){
    newMesg.className+=" own-mesg";
  } else {
    newMesg.className+=" other-mesg";
  }
  newMesgWrap.appendChild(newMesg);
  mesgPane.appendChild(newMesgWrap);
}

function appendMesg(detail, type){
  var mesgPane = document.getElementById("pane-mesg");
  var newMesgWrap = document.createElement("div");
  newMesgWrap.className = " bubble-wrapper";
  var newMesg = document.createElement("div");
  newMesg.innerHTML = detail;
  newMesg.className = "bubble-mesg";
  if(type === 1){
    newMesg.className+=" own-mesg";
  } else {
    newMesg.className+=" other-mesg";
  }
  newMesgWrap.appendChild(newMesg);
  mesgPane.insertBefore(newMesgWrap, mesgPane.firstChild);
}
