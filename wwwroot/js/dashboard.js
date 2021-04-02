function loadTableFromSQL(table) {
    var xhttp = new XMLHttpRequest();
    var sql = document.getElementsByName('sql')[0].value;
    xhttp.onreadystatechange = function() {
        if (this.readyState == 4) {
            if (this.status == 200) {
                var obj = JSON.parse(this.responseText);
                createTable(obj, table);
            } else if (this.status == 500) {
                alert('Execute SQL statemen failed! Please check and try again!');
            }
        }
    };

    xhttp.open('GET', `Dashboard/ExecuteSQL?sql=${sql}&table=${table}`, true);
    xhttp.send();
}

function createHeader(table) {
    var header = document.getElementsByClassName('m-0 text-dark')[0];
    header.innerHTML = table;
}

function createTable(array, table) {
    var main = document.getElementsByClassName('content')[0];
    var div = document.createElement('div');
    div.setAttribute('id', 'main-content');

    var tbl = document.createElement('table');
    tbl.setAttribute('class', 'customTable');
    tbl.setAttribute('border', '1');

    var tbody = document.createElement('tbody');
    array.forEach((element, index) => {
        //Id, Username, DisplayName, Salt
        var tr = document.createElement('tr');
        element.forEach((item) => {
            let temp =
                index == 0 ?
                document.createElement('th') :
                document.createElement('td');
            temp.innerHTML = item;
            tr.appendChild(temp);
        });
        tbody.appendChild(tr);
    });
    tbl.appendChild(tbody);
    div.appendChild(tbl);
    main.innerHTML = '';

    createHeader(table);
    main.appendChild(createTableControl(table));
    main.appendChild(div);
}

function loadSqlTextField(table) {
    var div = document.createElement('div');
    div.setAttribute('class', 'sql-text');

    var tbl = document.createElement('input');
    tbl.setAttribute('name', 'table');
    tbl.setAttribute('value', `${table}`);
    tbl.style.display = 'none';

    var textarea = document.createElement('textarea');
    textarea.setAttribute('form', 'sql-exe');
    textarea.setAttribute('name', 'sql');

    var submit = document.createElement('button');
    submit.setAttribute('onclick', `loadTableFromSQL('${table}')`);
    submit.innerHTML = 'Execute';

    div.appendChild(tbl);
    div.appendChild(textarea);
    div.appendChild(submit);

    var main = document.getElementsByClassName('content')[0];
    main.innerHTML = '';
    main.appendChild(createTableControl(table));
    main.appendChild(div);
}

async function onClickInsertButton(table) {
    getXMLHttpResponse(table);
}

function createTableInsert() {
    var div = document.createElement('div');
    div.setAttribute('class', 'table-insert');
    return div;
}