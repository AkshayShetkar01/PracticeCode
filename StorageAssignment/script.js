function saveToLocalStorage(){
    let lName =  document.querySelector('#lName').value ;
    let branch =  document.querySelector('#branch').value ;
    localStorage.setItem(lName,branch);
}

function saveToSessionStorage(){
    let sName =  document.querySelector('#sName').value ;
    let city =  document.querySelector('#city').value ;
    sessionStorage.setItem(sName,city);
}

function clearLocalStorage(){
    localStorage.clear();
}

function clearSessionStorage(){
    sessionStorage.clear();
}