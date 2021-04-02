var activeUser = null;
var chatUser = null;
var chatRoom = null;
var chatChannel = null;
var activeChat = null;

var socket;

function init(id) {
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
  console.log(`Sent message: "${JSON.stringify(data)}"`);
  socket.send(JSON.stringify(data));
}
function wsGetMesg(mesg) {
  var obj = JSON.parse(mesg.data);
  console.log(`Received message: "${mesg.data}"`);
  switch (obj.type) {
    //Process private messages
    case TYPE_B_RECV_PRIVATE_MESG:
      var privMesg = JSON.parse(obj.data);
      createNewMesg(privMesg.detail, 0);
      break;
    case TYPE_B_INFO_PRIVATE_MESG:
      var mesgList = JSON.parse(obj.data);
      console.log(mesgList);
      mesgList.forEach((mesg) => {
        if (mesg.sendId == activeUser) {
          appendMesg(mesg, 1);
        } else appendMesg(mesg, 0);
      });
      break;
    //Process channel messages
    case TYPE_B_RECV_CHANNEL_MESG:
      var chanMesg = JSON.parse(obj.data);
      createNewMesg(chanMesg.detail, 0);
      break;
    case TYPE_B_INFO_CHANNEL_MESG:
      var mesgList = JSON.parse(obj.data);
      console.log(mesgList);
      mesgList.forEach((mesg) => {
        if (mesg.sendId == activeUser) {
          appendMesg(mesg, 1);
        } else appendMesg(mesg, 2);
      });
      break;
    //Process info
    case TYPE_B_INFO_USER_ONL:
      setUserStatus(obj.data, true);
      break;
    case TYPE_B_INFO_USER_OFF:
      setUserStatus(obj.data, false);
      break;
    case TYPE_B_INFO_SEND_ERROR:
      alert("Send Error!");
      break;
    case TYPE_B_INFO_ROOM_CHANNEL:
      var channels = JSON.parse(obj.data);
      displayChannels(channels);
      break;
    case TYPE_B_INFO_ROOM_MEMBER:
      var members = JSON.parse(obj.data);
      displayMembers(members);
    default:
      break;
  }
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function setUserStatus(id, status) {
  var elm = document.getElementById(`status-user-${id}`);
  console.log(`status-user-${id}`);
  if (status) {
    elm.style.backgroundColor = "green";
  } else {
    elm.style.backgroundColor = "silver";
  }
}
var curPrivateMesgIndex = new Array();
var curChannelMesgIndex = new Array();

function setChatUser(id) {
  chatUser = id;
  activeChat = 1;
  document.getElementById("chat-name").innerHTML = document.getElementById(
    `uid-${id}-name`
  ).innerHTML;
  var obj = new JSONGeneric(TYPE_R_SUBS_PRIVATE_MESG, `${id}`);
  wsSendMesg(obj);
  clearMesgPane();
  curPrivateMesgIndex[id] = 0;
  loadPrivateMesg(id);
  clearChannels();
}

function setChatChannel(id) {
  chatChannel = id;
  document.getElementById("chat-name").innerHTML = document.getElementById(
    `cid-${id}-name`
  ).innerHTML;
  var obj = new JSONGeneric(TYPE_R_SUBS_PRIVATE_MESG, `${id}`);
  wsSendMesg(obj);
  clearMesgPane();
  curChannelMesgIndex[id] = 0;
  loadChannelMesg(id);
}

function setChatRoom(id) {
  chatRoom = id;
  activeChat = 2;
  document.getElementById("chat-name").innerHTML = document.getElementById(
    `rid-${id}-name`
  ).innerHTML;
  var obj = new JSONGeneric(TYPE_R_LOAD_ROOM_INFO, `${id}`);
  wsSendMesg(obj);
  clearMesgPane();
  clearChannels();
  var panelMain = document.getElementById("panel-detail-user");
  panelMain.style.left = "-300px";
  var panelRoom = document.getElementById("panel-detail-room");
  panelRoom.style.right = "0";
  var name = document.getElementById("active-room-name");
  name.innerHTML = document.getElementById(`rid-${id}-name`).innerHTML;
}

function hideChatRoom() {
  var panelMain = document.getElementById("panel-detail-user");
  panelMain.style.left = "0";
  var panelRoom = document.getElementById("panel-detail-room");
  panelRoom.style.right = "-300px";
}

function displayChannels(channels) {
  var textChannel = document.getElementById("panel-channel-text-list");
  var voiceChannel = document.getElementById("panel-channel-voice-list");
  channels.forEach(function (channel) {
    var newElm = document.createElement("div");
    newElm.className = "entry clickable";
    newElm.id = `cid-${channel.type}`;
    var newName = document.createElement("div");
    newName.className = "name";
    newName.id = `cid-${channel.type}-name`;
    newName.innerHTML = channel.name;
    newElm.appendChild(newName);
    console.log(newElm);
    if (channel.type == 1) {
      newElm.setAttribute("onclick", `setChatChannel(${channel.id})`);
      textChannel.appendChild(newElm);
    } else {
      voiceChannel.appendChild(newElm);
    }
  });
}

function displayMembers(members) {
  var memberList = document.getElementById("panel-room-member-list");
  members.forEach(function (member) {
    var newElm = document.createElement("div");
    newElm.className = "entry";
    newElm.id = `room-uid-${member.id}`;
    var newName = document.createElement("div");
    newName.className = "name";
    newName.id = `room-uid-${member.id}-name`;
    newName.innerHTML = member.name;
    newElm.innerHTML = "<img class='avatar' src='img/avatar.png'></img>";
    newElm.appendChild(newName);
    console.log(newElm);
    memberList.appendChild(newElm);
  });
}

function clearChannels() {
  var textChannel = document.getElementById("panel-channel-text-list");
  var voiceChannel = document.getElementById("panel-channel-voice-list");
  textChannel.innerHTML = "";
  voiceChannel.innerHTML = "";
}

function clearMesgPane() {
  var elm = (document.getElementById("pane-mesg").innerHTML = "");
}

function loadPrivateMesg(uid) {
  var obj = new JSONGeneric(TYPE_R_LOAD_PRIVATE_MESG, `${uid};${curPrivateMesgIndex[uid]}`);
  curPrivateMesgIndex[uid] += 25;
  wsSendMesg(obj);
}

function loadChannelMesg(cid) {
  var obj = new JSONGeneric(TYPE_R_LOAD_CHANNEL_MESG, `${cid};${curChannelMesgIndex[cid]}`);
  curChannelMesgIndex[cid] += 25;
  wsSendMesg(obj);
}

function sendMesg() {
  var mesg = document.getElementById("field-mesg").value;
  if (mesg == "") return;
  if (activeChat == 1) {
    var privMesg = new PrivateMessage(activeUser, chatUser, mesg);
    var obj = new JSONGeneric(TYPE_R_SENT_PRIVATE_MESG, JSON.stringify(privMesg));
    wsSendMesg(obj);
    createNewMesg(mesg, 1);
  } else {
    var chanMesg = new ChannelMessage(chatChannel, activeUser, mesg);
    var obj = new JSONGeneric(TYPE_R_SENT_CHANNEL_MESG, JSON.stringify(chanMesg));
    wsSendMesg(obj);
    createNewMesg(mesg, 1);
  }
}

function createNewMesg(detail, type) {
  var mesgPane = document.getElementById("pane-mesg");
  var newMesgWrap = document.createElement("div");
  newMesgWrap.className = " bubble-wrapper";
  var newMesg = document.createElement("div");
  newMesg.innerHTML = detail;
  newMesg.className = "bubble-mesg";
  if (type === 1) {
    newMesg.className += " own-mesg";
  } else {
    newMesg.className += " other-mesg";
  }
  newMesgWrap.appendChild(newMesg);
  mesgPane.appendChild(newMesgWrap);
}
var lastSendUID = 0;
var lastMesgElm = null;
function appendMesg(mesg, type) {
  var mesgPane = document.getElementById("pane-mesg");
  var newMesgWrap = document.createElement("div");
  newMesgWrap.className = " bubble-wrapper";
  var newMesg = document.createElement("div");
  newMesg.innerHTML = mesg.detail;
  newMesg.className = "bubble-mesg";
  if (type === 1) {
    newMesg.className += " own-mesg";
    lastSendUID = 0;
  } else {
    newMesg.className += " other-mesg";
  }
  if (type == 2) {
    if (mesg.sendId == lastSendUID) {
      lastMesgElm.firstChild.remove();
    }
    createBubbleInfo(mesg.sendId, newMesgWrap);
  }
  newMesgWrap.appendChild(newMesg);
  lastMesgElm = newMesgWrap;
  mesgPane.insertBefore(newMesgWrap, mesgPane.firstChild);
}

function createBubbleInfo(sendId, wrap){
  var name = document.getElementById(`room-uid-${sendId}-name`).innerHTML;
  var infoElm = document.createElement("div");
  lastSendUID = sendId;
  infoElm.className = "sender-info";
  infoElm.innerHTML = `<img class="avatar" src="img/avatar.png"></img><div class="name">${name}</div>`;
  wrap.appendChild(infoElm);
}

function scrollToBottom(){
  var panelMesg = document.getElementById("pane-mesg");
  panelMesg.scrollTop = panelMesg.scrollHeight;
}