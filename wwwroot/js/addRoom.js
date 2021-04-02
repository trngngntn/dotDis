var addRoomDialog;
var btPrev, btOk, btCancel;

function doAddRoom(){
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("placeholder").innerHTML = this.responseText;
            initAddRoomDialog();
        } 
    };
    xhttp.open("GET", "/AddRoomDialog.html", true);
    xhttp.send();
}

function initAddRoomDialog(){
    btPrev = document.getElementById("dialog-bt-previous");
    btOk = document.getElementById("dialog-bt-ok");
    btCancel = document.getElementById("dialog-bt-cancel");
    btPrev.setAttribute("onclick", "addRoomDialog.doPrev()");
    btOk.setAttribute("onclick", "addRoomDialog.doOk()");
    btCancel.setAttribute("onclick", "addRoomDialog.doCancel()");
    addRoomDialog = new AddRoomDialog();
}

class AddRoomDialog {
    constructor(){
        this.addRoomPanel = document.getElementById("box-add-room");
        this.createRoomPanel = document.getElementById("box-create-room");
        this.joinRoomPanel = document.getElementById("box-join-room");
        this.txtRoomName = document.getElementById("room-create-name");
        this.txtInvite = document.getElementById("room-inv-code");
        this.txtRoomName.setAttribute("oninput", "addRoomDialog.checkShowOk()");
        hidePrev();
        hideOk();
    }
    doPrev(){
        this.hideCreateRoomPanel();
        this.hideJoinRoomPanel();
        this.showAddRoomPanel();
        hidePrev();
    }
    checkShowOk(){
        if(this.txtRoomName.value.trim() != "" || this.txtInvite.value.trim() != ""){
            showOk();
        } else {
            hideOk();
        }
    }
    doOk(){
        if(this.option == 0) // create new room
        {
            var name = this.txtRoomName.value;
            var xhr = new XMLHttpRequest();
            xhr.onreadystatechange = function(){
                if (this.readyState == 4 && this.status == 200) {
                    var room = new Object();
                    room.name = name;
                    room.id = this.responseText;
                    addRoom(room);
                    addRoomDialog.doCancel();
                }
            };
            var param = `name=${name}&uid=${activeUser}`;
            console.log(param);
            xhr.open('GET', `/Chat/AddRoom?name=${name}&uid=${activeUser}`, true);
            xhr.send();
        } else { // join

        }
    }
    doCancel(){
        var placeholder = document.getElementById("placeholder");
        placeholder.removeChild(placeholder.firstChild);
        placeholder.innerHTML = "";
    }
    toCreate(){
        this.option = 0;
        this.hideAddRoomPanel();
        this.showCreateRoomPanel();
        showPrev();
    }
    toJoin(){
        this.option = 1;
        this.hideAddRoomPanel();
        this.showJoinRoomPanel();
        showPrev();
    }
    showAddRoomPanel() {
        this.addRoomPanel.style.left = "0";
    }
    showCreateRoomPanel() {
        this.createRoomPanel.style.left = "0";
    }
    showJoinRoomPanel() {
        this.joinRoomPanel.style.left = "0";
    }
    hideAddRoomPanel() {
        this.addRoomPanel.style.left = "-100%";
    }
    hideCreateRoomPanel() {
        this.createRoomPanel.style.left = "100%";
    }
    hideJoinRoomPanel() {
        this.joinRoomPanel.style.left = "100%";
    }
}