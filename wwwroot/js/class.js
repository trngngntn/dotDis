class PrivateMessage {
    constructor(sendId, detail){
        this.sendId = sendId;
        if(sendId == 1) this.recvId = 3;
        else this.recvId = 1;
        this.detail = detail;
    }
}

class JSONGeneric {
    constructor(type, data){
        this.type = type;
        this.data = data;
    }
}