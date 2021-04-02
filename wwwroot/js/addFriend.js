var addFriendDialog;

function doAddFriend(){
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("placeholder").innerHTML = this.responseText;
            initAddRoomDialog();
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
        console.log(`/Chat/SearchUser/${this.searchBox.value.trim()}`);
        xhr.open("GET",`/Chat/SearchUser?str=${this.searchBox.value.trim()}`);
        xhr.send();
    }
    displayResult(list){
        this.resultPanel.innerHTML = "";
        list.forEach(function(user){
            var elm = document.createElement("div");
            elm.className = "found-user clickable";
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