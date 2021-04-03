var addFriendDialog;

function doAddFriend(){
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("placeholder").innerHTML = this.responseText;
            initAddFriendDialog();
        } 
    };
    xhttp.open("GET", "/AddFriendDialog.html", true);
    xhttp.send();
}

function showPrev(){
    btPrev.style.zIndex = 10;
    btPrev.style.opacity = 100;
}
function showOk(){
    btOk.style.zIndex = 10;
    btOk.style.opacity = 100;
}
function hidePrev(){
    btPrev.style.zIndex = -10;
    btPrev.style.opacity = 0;
}
function hideOk(){
    btOk.style.zIndex = -10;
    btOk.style.opacity = 0;
}

function initAddFriendDialog(){
    btPrev = document.getElementById("dialog-bt-previous");
    btOk = document.getElementById("dialog-bt-ok");
    btCancel = document.getElementById("dialog-bt-cancel");
    btPrev.setAttribute("onclick", "addFriendDialog.doPrev()");
    btOk.setAttribute("onclick", "addFriendDialog.doOk()");
    btCancel.setAttribute("onclick", "addFriendDialog.doCancel()");
    addFriendDialog = new AddFriendDialog();
}
function addFriend(uid, name){
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            if(this.responseText == "done"){
                var list = document.getElementById("panel-friend-list");
                var elm = document.createElement("div");
                elm.className = `entry clickable`;
                elm.id = `uid-${uid}`;
                elm.setAttribute("onclick", `setChatUser(${uid})`);
                elm.innerHTML = `<img class="avatar" src="img/avatar.png"></img>
                <div class="name" id="uid-${uid}-name">${name}</div>
                <div id="status-user-${uid}" class="status-dot"></div>`;
                list.appendChild(elm);
            }
        } 
    };
    xhttp.open("GET", `/Chat/AddFriend?fuid=${uid}`, true);
    xhttp.send();
}
class AddFriendDialog {
    constructor(){
        this.addFriendPanel = document.getElementById("box-add-friend");
        this.searchBox = document.getElementById("search-name");
        this.resultPanel = document.getElementById("result-list");
        this.searchBox.setAttribute("oninput", "addFriendDialog.doSearch()");
        hideOk();
        hidePrev();
    }
    doPrev(){
        this.hideCreateRoomPanel();
        this.hideJoinRoomPanel();
        this.showAddRoomPanel();
    }
    doOk(){

    }
    doSearch(){
        if(this.searchBox.value.trim() == ""){
            this.resultPanel.innerHTML = "";
            return;
        } 
        var xhr = new XMLHttpRequest();
        xhr.onreadystatechange = function() {
            if (this.readyState == 4 && this.status == 200) {
                addFriendDialog.displayResult(JSON.parse(this.responseText));
            } else console.log("pending");
        };
        xhr.open("GET",`/Chat/SearchUser?uid=${activeUser}&str=${this.searchBox.value.trim()}`);
        xhr.send();
    }
    displayResult(list){
        this.resultPanel.innerHTML = "";
        list.forEach(function(user){
            var elm = document.createElement("div");
            elm.className = "found-user clickable";
            elm.setAttribute("onclick", `addFriend(${user.id},"${user.name}")`);
            var elmAva = document.createElement("img");
            elmAva.className = "avatar";
            elmAva.src = "img/avatar.png";
            elm.appendChild(elmAva);
            var elmName = document.createElement("div");
            elmName.className = "found-user-name";
            elmName.innerHTML = `${user.name} (${user.username})`;
            elm.appendChild(elmName);
            addFriendDialog.resultPanel.appendChild(elm);
        });
    }
    doCancel(){
        var placeholder = document.getElementById("placeholder");
        placeholder.removeChild(placeholder.firstChild);
        placeholder.innerHTML = "";
    }
    
}