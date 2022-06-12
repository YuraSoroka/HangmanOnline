"use strict";

let currentSession;

// connecting to a signalR hub. 
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/hangmanhub")
    .build();


connection.start().then(function () {
    console.log("connection started");
}).catch(function (err) {
    return console.error(err.toString());
});


// Came from server, when connection established between multiple users
connection.on("RenderScene", function (recievedSession) {
    // start session from server-side
    renderScene(recievedSession);

    //Call hub methods from the client. Must call a name of method from Hub (server-side)
    connection.invoke("UpdateSessionToOthers", currentSession)
        .catch(function (err) {
            return console.error(err.toString());
        });
});




document.querySelector(".submit-btn").addEventListener("click", function (event) {
    checkLetter();
    
});


function checkLetter() {

    let letter = document.querySelector(".put-letter");
    let letterValue = letter.value;
    letter.value = "";

    var request;
    if (window.XMLHttpRequest) {
        //New browsers.
        request = new XMLHttpRequest();
    }
    else if (window.ActiveXObject) {
        //Old IE Browsers.
        request = new ActiveXObject("Microsoft.XMLHTTP");
    }
    if (request != null) {
        request.open("GET", "update/" + letterValue, true);
        request.onreadystatechange = function () {
            if (request.readyState == 4 && request.status == 200) {
                currentSession = JSON.parse(request.responseText);

            }
        };
        request.send();
    }
}

function renderWord(letter, word) {
    let letters = document.querySelectorAll(".letter");
    for (let i = 0; i < word.length; i++) {
        if (word[i] === letter) {
            letters[i].innerHTML = letter;
        }
    }
}

function renderScene(gameSession) {

    setPlayerOneName(gameSession.firstPlayerName);
    setPlayerTwoName(gameSession.secondPlayerName)
    updatePlayerOneHearths(gameSession.firstPlayerHearts);
    updatePlayerTwoHearths(gameSession.secondPlayerHearts);

    renderWord(gameSession.letter, gameSession.word);

    console.log(gameSession.word);
}

function updatePlayerOneHearths(hearths) {
    const playerOneHealth = document.querySelector("#playerOneHealth");
    playerOneHealth.innerHTML = hearths;
}

function updatePlayerTwoHearths(hearths) {
    const playerTwoHealth = document.querySelector("#playerTwoHealth");
    playerTwoHealth.innerHTML = hearths;
}

function setPlayerOneName(name) {
    const playerOneName = document.querySelector("#playerOneName");
    playerOneName.innerHTML = name;
}

function setPlayerTwoName(name) {
    const playerTwoName = document.querySelector("#playerTwoName");
    playerTwoName.innerHTML = name;
}