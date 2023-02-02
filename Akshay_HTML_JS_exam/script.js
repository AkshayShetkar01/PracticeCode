const themeChangeBtn = document.querySelector('.themeChange-btn');
const container = document.querySelector('.container');
const msg = document.querySelector('#msg');
const loadBtn = document.querySelector('.controls-load');
const twelveHours = document.querySelector('#twelveHours');
const twentyFourHours = document.querySelector('#twentyFourHours');
const startSelector = document.querySelector("#start");
const endSelector = document.querySelector("#end");
const displayBtn = document.querySelector(".displayTime-btn");
const clearBtn = document.querySelector(".controls-clear");
let elements = document.getElementsByName("timeFormat");
displayBtn.disabled = true;
let meridiem;

function themeChange() {
    document.querySelector(".container").classList.toggle("dark");
}

let minuteInterval = math.range(0, 60, 15, false);
let hourInterval24 = math.range(0, 24, 1, false);
let hourInterval1 = math.range(0, 12, 1, true);
let hourInterval2 = math.range(1, 12, 1, false);
let hourInterval12 = [...hourInterval1._data , ...hourInterval2._data];

let minutuesArr = Array.from(minuteInterval._data , (x) => x == 0 ? '00' : `${x}`); 
let hoursArr = Array.from(hourInterval24._data , (x) => x < 10 ? `0${x}` : `${x}`); 
let hoursArr12 = Array.from(hourInterval12 , (x) => x < 10 ? `0${x}` : `${x}`);

function loadData(){  
    validateLoad();
    if(twentyFourHours.checked == true) {
        getDataFor24();
    } else if(twelveHours.checked == true) {
        getDataFor12();
    }

    displayBtn.disabled = false;
    displayBtn.style.border = "#000 1px solid";
};


function getDataFor24() {
    hoursArr.forEach((hr) => {
        minutuesArr.forEach((min) => {
            var option1 = document.createElement( "option" );
            option1.text = `${hr} : ${min}`;
            option1.value = `${hr} : ${min}`;
            startSelector.appendChild( option1 );

            option2 = document.createElement( "option" );
            option2.text = `${hr} : ${min}`;
            option2.value = `${hr} : ${min}`;
            endSelector.appendChild( option2 );
        })
    })
}

function getDataFor12() {
    for( i = 0 ; i < hoursArr.length ; i++){
        for( j = 0 ; j < minutuesArr.length ; j++) {
            if ( i < 12 ) {
                startSelector.innerHTML += `<option val = ${hoursArr12[i]} : ${minutuesArr[j]} AM>${hoursArr12[i]} : ${minutuesArr[j]} AM</option>`;
                endSelector.innerHTML += `<option val = ${hoursArr12[i]} : ${minutuesArr[j]} AM>${hoursArr12[i]} : ${minutuesArr[j]} AM</option>`;
            } else if( i >= 12) {
                startSelector.innerHTML += `<option val = ${hoursArr12[i]  } : ${minutuesArr[j]} PM>${hoursArr12[i]} : ${minutuesArr[j]} PM</option>`;
                endSelector.innerHTML += `<option val = ${hoursArr12[i] } : ${minutuesArr[j]} PM>${hoursArr12[i]} : ${minutuesArr[j]} PM</option>`;
            }                          
        }     
    }
}

function validateLoad() {
    if ((twelveHours.checked == false) && (twentyFourHours.checked == false)) {
        msg.innerHTML = `Please select Time Format`;
        return false;
    } else {
        msg.innerHTML = ``;
        return true;
    }
};

function clearData(){
    for( i = 0 ; i < elements.length ; i++ )
        elements[i].checked = false;

    startSelector.innerHTML = `<option value="">Please Select</option>`;
    endSelector.innerHTML = `<option value="">Please Select</option>`;
    msg.innerHTML = "";
    displayBtn.disabled = true;
    
};

function validateSelect(){
    if(startSelector.value == "" || endSelector.value == ""){             
        return false;
    } else {     
        return true;
    }
};

function displaySchedule() {
    let result = validateSelect();
    let startVal = startSelector.value;
    let endVal = endSelector.value;

    if(result){
        if(twelveHours.checked == true){
            msg.innerHTML = `You selected start time as ${startVal.substring(0,2)} hours and ${startVal.substring(5,7)} minutes ${startVal.substring(8,10)} and end time as ${endVal.substring(0,2)} hours and ${endVal.substring(5,7)} minutes ${endVal.substring(8,10)}` ;
        }else if(twentyFourHours.checked == true){
            msg.innerHTML = `You selected start time as ${startVal.substring(0,2)} hours and ${startVal.substring(5,7)} minutes and end time as ${endVal.substring(0,2)} hours and ${endVal.substring(5,7)} minutes` ;
        }      
    }else{
        msg.innerHTML = `Please select dropdown`;
    }
}