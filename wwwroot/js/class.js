const TYPE_R_SUBS_PRIVATE_MESG = 0;
const TYPE_R_UNSB_PRVATE_MESG = 1;
const TYPE_R_SUBS_CHANNEL_MESG = 2;
const TYPE_R_UNSB_CHANNEL_MESG = 3;
const TYPE_R_LOAD_PRIVATE_MESG = 4;
const TYPE_R_LOAD_CHANNEL_MESG = 5;
const TYPE_R_SENT_PRIVATE_MESG = 6;
const TYPE_R_SENT_CHANNEL_MESG = 7;
const TYPE_B_RECV_PRIVATE_MESG = 8;
const TYPE_B_RECV_CHANNEL_MESG = 9;
const TYPE_B_INFO_PRIVATE_MESG = 10;
const TYPE_B_INFO_CHANNEL_MESG = 11;
const TYPE_B_INFO_USER_ONL = 12;
const TYPE_B_INFO_USER_OFF = 13;
const TYPE_B_INFO_SEND_OK = 14;
const TYPE_B_INFO_SEND_ERROR = 15;

const TYPE_R_LOAD_ROOM_INFO = 100;
const TYPE_B_INFO_ROOM_CHANNEL = 101;

class PrivateMessage {
    constructor(sendId, recvId, detail){
        this.sendId = sendId;
        this.recvId = recvId;
        this.detail = detail;
    }
}
class ChannelMessage {
    constructor(channelId, sendId, detail){
        this.channelId = channelId;
        this.sendId = sendId;
        this.detail = detail;
    }
}

class Channel {
    constructor(id, name, type){
        this.id = id;
        this.name = name;
        this.type = type;
    }
}

class JSONGeneric {
    constructor(type, data){
        this.type = type;
        this.data = data;
    }
}